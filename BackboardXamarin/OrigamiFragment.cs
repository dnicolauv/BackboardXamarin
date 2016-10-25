
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
		  private SpringConfiguratorView mSpringConfiguratorView;

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


			var sys = SpringSystem.Create();
			mSpring = sys.CreateSpring();
			mSpring.SetSpringConfig(ORIGAMI_SPRING_CONFIG);

			var a = new Actor.Builder(sys, mSelectedPhoto).AddTranslateMotion(MotionProperty.X).AddTranslateMotion(MotionProperty.Y).Build();

			rootView.Touch += (sender, e) =>
			{
				if (mSpring.EndValue == 0)
				{
					mSpring.SetEndValue(1);
				}
				else {
					mSpring.SetEndValue(0);
				}
			};

			mPhotoGrid = rootView.FindViewById<View>(Resource.Id.grid);
			mSelectedPhoto = rootView.FindViewById<View>(Resource.Id.selection);
			mFeedbackBar = rootView.FindViewById<View>(Resource.Id.feedback);
			mSpringConfiguratorView = rootView.FindViewById<SpringConfiguratorView>(Resource.Id.spring_configurator);

			mSelectedPhoto.SetOnTouchListener(new ToggleImitator(mSpring, 0.5, 10.5));



			return rootView;
		}
	}
}
