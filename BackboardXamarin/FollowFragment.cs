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
using Com.Facebook.Rebound;
using com.tumblr.backboard;

namespace BackboardXamarin
{
    public class FollowFragment : Fragment
    {
        private static String TAG = "FollowFragment";

        private static int DIAMETER = 80;

        private ViewGroup mRootView;
        private View mCircle;
        private View[] mFollowers;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            

            mRootView = (ViewGroup) inflater.Inflate(Resource.Layout.fragment_follow, container, false);

		    mCircle = mRootView.FindViewById(Resource.Id.circle);

            FrameLayout.LayoutParams leaderParams = (FrameLayout.LayoutParams)mCircle.LayoutParameters;

            mFollowers = new View[4];

		    float diameter = TypedValue.ApplyDimension(ComplexUnitType.Dip, DIAMETER, Resources.DisplayMetrics);

            Android.Content.Res.TypedArray circles = Resources.ObtainTypedArray(Resource.Array.circles);

            // create the circle views
            int colorIndex = 1;
            for (int i = 0; i < mFollowers.Length; i++)
            {
                mFollowers[i] = new View(this.Activity);

                FrameLayout.LayoutParams par = new FrameLayout.LayoutParams((int)diameter, (int)diameter);
			    par.Gravity = leaderParams.Gravity;
                mFollowers[i].LayoutParameters = par;

                mFollowers[i].SetBackgroundDrawable(Resources.GetDrawable(circles.GetResourceId(colorIndex, -1)));

                colorIndex++;
                if (colorIndex >= circles.Length())
                {
                    colorIndex = 0;
                }

                mRootView.AddView(mFollowers[i]);
            }

            circles.Recycle();

            /* Animation code */

            SpringSystem springSystem = SpringSystem.Create();

            // create the springs that control movement
            Spring springX = springSystem.CreateSpring();
            Spring springY = springSystem.CreateSpring();

            // bind circle movement to events
            new Actor.Builder(springSystem, mCircle).AddMotion(springX, MotionProperty.X).AddMotion(springY, MotionProperty.Y).Build();

            // add springs to connect between the views
            Spring[] followsX = new Spring[mFollowers.Length];
            Spring[] followsY = new Spring[mFollowers.Length];

            Random rnd = new Random();

            for (int i = 0; i < mFollowers.Length; i++)
            {
                // create spring to bind views
                followsX[i] = springSystem.CreateSpring();
                followsY[i] = springSystem.CreateSpring();
                //followsX[i] = springSystem.CreateSpring().SetSpringConfig(new SpringConfig(rnd.Next(300), rnd.Next(22)));
                //followsY[i] = springSystem.CreateSpring().SetSpringConfig(new SpringConfig(rnd.Next(300), rnd.Next(22)));
                followsX[i].AddListener(new Performer(mFollowers[i], ViewHelper.TranslationX));
				followsY[i].AddListener(new Performer(mFollowers[i], ViewHelper.TranslationY));

                // imitates another character
                SpringImitator followX = new SpringImitator(followsX[i]);
                SpringImitator followY = new SpringImitator(followsY[i]);

                //  imitate the previous character
                if (i == 0)
                {
                    springX.AddListener(followX);
                    springY.AddListener(followY);
                }
                else
                {
                    followsX[i - 1].AddListener(followX);
                    followsY[i - 1].AddListener(followY);
                }
            }

            return mRootView;
        }
    }
}