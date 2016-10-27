
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using com.tumblr.backboard;
using Com.Facebook.Rebound;
using Com.Facebook.Rebound.UI;

namespace BackboardXamarin
{
	public class OrigamiFragment : Fragment
	{
		  private static SpringConfig ORIGAMI_SPRING_CONFIG = SpringConfig.FromOrigamiTensionAndFriction(40, 7);

		  private Spring mSpring;
		  private View mSelectedPhoto;
		  private View mPhotoGrid;
		  private View mFeedbackBar;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
            View rootView = inflater.Inflate(Resource.Layout.origami_example, container, false);

            mPhotoGrid = rootView.FindViewById<View>(Resource.Id.grid);
            mSelectedPhoto = rootView.FindViewById<View>(Resource.Id.selection);
            mFeedbackBar = rootView.FindViewById<View>(Resource.Id.feedback);

            SpringSystem springSystem = SpringSystem.Create();
            mSpring = springSystem.CreateSpring().SetSpringConfig(ORIGAMI_SPRING_CONFIG);

            mSpring.AddListener(new MapPerformer(mSelectedPhoto, View.ScaleXs, 0f, 1f, 0.33f, 1));
            mSpring.AddListener(new MapPerformer(mSelectedPhoto, View.ScaleYs, 0f, 1f, 0.33f, 1));
            mSpring.AddListener(new MapPerformer(mSelectedPhoto, ViewHelper.TranslationX, 0, 1, Util.DpToPx(-106.667f, Resources), 0));
            mSpring.AddListener(new MapPerformer(mSelectedPhoto, ViewHelper.TranslationY, 0, 1, Util.DpToPx(46.667f, Resources), 0));
            mSpring.AddListener(new MapPerformer(mPhotoGrid, ViewHelper.Alpha, 0, 1, 1, 0));
            mSpring.AddListener(new MapPerformer(mPhotoGrid, View.ScaleXs, 0f, 1f, 1f, 0.95f));
            mSpring.AddListener(new MapPerformer(mPhotoGrid, View.ScaleYs, 0f, 1f, 1f, 0.95f));
           
            EventHandler globalHandler = null;
            globalHandler += (sender, e) =>
            {
                float barPosition = (float)SpringUtil.MapValueFromRangeToRange(mSpring.CurrentValue, 0, 1, mFeedbackBar.Height, 0);
                mFeedbackBar.TranslationY = barPosition;
                mSpring.AddListener(new MapPerformer(mFeedbackBar, ViewHelper.TranslationY, 0, 1, mFeedbackBar.Height, 0));
                rootView.ViewTreeObserver.GlobalLayout -= globalHandler;
            };

            rootView.ViewTreeObserver.GlobalLayout += globalHandler;           

            ToggleImitator imitator = new ToggleImitator(mSpring, 0, 1);
            rootView.SetOnTouchListener(imitator);

            mSpring.SetCurrentValue(0);

            return rootView;
		}
	}
}
