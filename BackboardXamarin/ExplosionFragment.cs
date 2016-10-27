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
using Android.Content.Res;
using Java.Lang;
using Com.Facebook.Rebound;
using Android.Graphics.Drawables;
using com.tumblr.backboard;

namespace BackboardXamarin
{

    public class ExplosionFragment : Fragment
    {
        private static int DIAMETER = 80;

        private RelativeLayout mRootView;

        private int colorIndex;
        private TypedArray mCircles;

        private Handler mHandler;
        private IRunnable mRunnable;
        private bool mTouching;

        private SpringSystem mSpringSystem;

        private SpringConfig mCoasting;
        private SpringConfig mGravity;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            mHandler = new Handler();
            mSpringSystem = SpringSystem.Create();

            mCoasting = SpringConfig.FromOrigamiTensionAndFriction(0, 0);
            mCoasting.Tension = 0;

            // this is very much a hack, since the end value is set to 9001 to simulate constant
            // acceleration.
            mGravity = SpringConfig.FromOrigamiTensionAndFriction(0, 0);
            mGravity.Tension = 1;

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mRootView = (RelativeLayout)inflater.Inflate(Resource.Layout.fragment_bloom, container, false);

            mCircles = Resources.ObtainTypedArray(Resource.Array.circles);
            mRunnable = new CircleSpawn(this);

            mRootView.Touch += (sender, e) =>
            {
                switch (e.Event.Action) {
                    case MotionEventActions.Down:
					    // create circles as long as the user is holding down
					    mTouching = true;
                        mHandler.Post(mRunnable);
                        break;
				    case MotionEventActions.Up:
					    mTouching = false;
                         break;
                }

                e.Handled = true;
            };

            return mRootView;
        }

        class CircleSpawn : Java.Lang.IRunnable
        {
            ExplosionFragment _fragment;

            public CircleSpawn(ExplosionFragment fragment) { _fragment = fragment; }
            public IntPtr Handle
            {
                get
                {
                    return new IntPtr();
                }
            }

            public void Run()
            {
                if (_fragment.mTouching)
                {

                    _fragment.colorIndex++;
                    if (_fragment.colorIndex >= _fragment.mCircles.Length())
                    {
                        _fragment.colorIndex = 0;
                    }

                    float diameter = TypedValue.ApplyDimension(ComplexUnitType.Dip, DIAMETER, _fragment.Resources.DisplayMetrics);

                    Drawable drawable = _fragment.Resources.GetDrawable(_fragment.mCircles.GetResourceId(_fragment.colorIndex, -1));

                    createCircle(_fragment.Activity, _fragment.mRootView, _fragment.mSpringSystem, _fragment.mCoasting, _fragment.mGravity,
                            (int)diameter, drawable);

                    _fragment.mHandler.PostDelayed(this, 100);
                }
            }

            private static void createCircle(Context context, ViewGroup rootView, SpringSystem springSystem, SpringConfig coasting, SpringConfig gravity, int diameter, Drawable backgroundDrawable)
            {

                Spring xSpring = springSystem.CreateSpring().SetSpringConfig(coasting);
                Spring ySpring = springSystem.CreateSpring().SetSpringConfig(gravity);

                // create view
                View view = new View(context);

                RelativeLayout.LayoutParams paramss = new RelativeLayout.LayoutParams(diameter, diameter);
                paramss.AddRule(LayoutRules.CenterInParent);
                view.LayoutParameters = paramss;
                view.SetBackgroundDrawable(backgroundDrawable);

                rootView.AddView(view);

                // generate random direction and magnitude
                double magnitude = new Random().Next() * 1000 + 3000;
                double angle = new Random().Next() * System.Math.PI / 2 + System.Math.PI / 4;

                xSpring.SetVelocity(magnitude * System.Math.Cos(angle));
                ySpring.SetVelocity(-magnitude * System.Math.Sin(angle));

                int maxX = rootView.MeasuredWidth / 2 + diameter;
                xSpring.AddListener(new Destroyer(rootView, view, -maxX, maxX));

                int maxY = rootView.MeasuredHeight / 2 + diameter;
                ySpring.AddListener(new Destroyer(rootView, view, -maxY, maxY));

                xSpring.AddListener(new Performer(view, ViewHelper.TranslationX));
                ySpring.AddListener(new Performer(view, ViewHelper.TranslationY));

                // set a different end value to cause the animation to play
                xSpring.SetEndValue(2);
                ySpring.SetEndValue(9001);
            }

            public void Dispose()
            {
            }
        }

        /**
        * Destroys the attached {@link com.facebook.rebound.Spring}.
        */
        public class Destroyer : Java.Lang.Object, ISpringListener
        {
            public int mMin, mMax;

            protected ViewGroup mViewGroup;
            protected View mViewToRemove;

            public IntPtr Handle
            {
                get
                {
                    return new IntPtr();///throw new NotImplementedException();
                }
            }

            public Destroyer(ViewGroup viewGroup, View viewToRemove, int min, int max)
            {
                mViewGroup = viewGroup;
                mViewToRemove = viewToRemove;

                mMin = min;
                mMax = max;
            }

            public bool ShouldClean(Spring spring)
            {
                // these are arbitrary values to keep the view from disappearing before it is
                // fully off the screen
                return spring.CurrentValue < mMin || spring.CurrentValue > mMax;
            }

            public void clean(Spring spring)
            {
                if (mViewGroup != null && mViewToRemove != null)
                {
                    mViewGroup.RemoveView(mViewToRemove);
                }
                if (spring != null)
                {
                    spring.Destroy();
                }
            }
            public void OnSpringUpdate(Spring spring)
            {
                if (ShouldClean(spring))
                {
                    clean(spring);
                }
            }

            public void OnSpringAtRest(Spring spring)
            {
            }
            public void OnSpringActivate(Spring spring)
            {
            }
            public void OnSpringEndStateChange(Spring spring)
            {
            }

            public void Dispose()
            {
                //throw new NotImplementedException();
            }
        }
    }
}