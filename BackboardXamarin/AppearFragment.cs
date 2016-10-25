
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

namespace BackboardXamarin
{
	public class AppearFragment : Fragment
	{
		private static String TAG = "AppearFragment";

		protected View mRootView;
		protected View[] mCircles;
		protected SpringSystem springSystem;
		protected Spring[] springs;
		protected Actor[] actors;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			// Create your fragment here
		}

		public class CustomClickListener : AppearFragment, View.IOnClickListener
		{
			AppearFragment parent;
			public CustomClickListener(AppearFragment f) : base()
			{
				parent = f;
			}

			public void OnClick(View v)
			{
				Spring spring = (Spring)v.Tag;

				// get root location so we can compensate for it
				int[] rootLocation = new int[2];
				v.GetLocationInWindow(rootLocation);

				int[] location = new int[2];

				for (int i = 0; i < parent.mCircles.Length; i++)
				{
					parent.actors[i].SetTouchEnabled(false);

					foreach (Actor.Motion motion in parent.actors[i].GetMotions())
					{
						foreach (EventImitator imitator in motion.GetImitators())
						{
							if (imitator is MotionImitator)
							{
								MotionImitator motionImitator = (MotionImitator)imitator;
								if (motionImitator.GetProperty() == MotionProperty.Y)
								{
									// TODO: disable the y-motion because it is about to be animated
									// imitator.getSpring().deregister();
								}
								else {
									imitator.Release(null);
								}
							}
						}
					}

					parent.mCircles[i].GetLocationInWindow(location);

					if (parent.springs[i] == spring)
					{
						// goes to the top
						parent.springs[i].SetEndValue(-location[1] + rootLocation[1] - v.MeasuredHeight);
					}
					else {
						// go back to the bottom
						parent.springs[i].SetEndValue(parent.mRootView.MeasuredHeight - location[1] + rootLocation[1] + 2 * new Random().NextDouble() * parent.mCircles[i].MeasuredHeight);
					}
				}
			}
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			mRootView = inflater.Inflate(Resource.Layout.fragment_appear, container, false);

			// grab the circles
			mCircles = new View[6];
			mCircles[0] = mRootView.FindViewById(Resource.Id.circle0);
			mCircles[1] = mRootView.FindViewById(Resource.Id.circle1);
			mCircles[2] = mRootView.FindViewById(Resource.Id.circle2);
			mCircles[3] = mRootView.FindViewById(Resource.Id.circle3);
			mCircles[4] = mRootView.FindViewById(Resource.Id.circle4);
			mCircles[5] = mRootView.FindViewById(Resource.Id.circle5);

			springSystem = SpringSystem.Create();

			springs = new Spring[6];
			actors = new Actor[6];

			// attach listeners
			for (int i = 0; i < mCircles.Length; i++)
			{
				springs[i] = springSystem.CreateSpring();

				springs[i].AddListener(new Performer(mCircles[i], View.GetViewStaticProperty("TranslationY")));

				mCircles[i].Tag = springs[i];

				mCircles[i].SetOnClickListener(new CustomClickListener(this));

				actors[i] = new Actor.Builder(springSystem, mCircles[i])
						.AddTranslateMotion(MotionProperty.X)
						.AddTranslateMotion(MotionProperty.Y)
				        .Build();
			}


			mRootView.Touch += (sender, e) => {
					// grab location of root view so we can compensate for it
					int[] rootLocation = new int[2];
					((View)sender).GetLocationInWindow(rootLocation);

					int[] location = new int[2];

					for (int i = 0; i < mCircles.Length; i++)
					{

						if (springs[i].EndValue == 0)
						{ // hide
							mCircles[i].GetLocationInWindow(location);

							// if the end values are different, they will move at different speeds
							springs[i].SetEndValue(mRootView.MeasuredHeight - location[1] + rootLocation[1] + 2 * new Random().Next() * mCircles[i].MeasuredHeight);
						}
						else {
							actors[i].SetTouchEnabled(true);

							foreach (Actor.Motion motion in actors[i].GetMotions())
							{
								foreach (EventImitator imitator in motion.GetImitators())
								{
									if (imitator is MotionImitator)
									{
										MotionImitator motionImitator = (MotionImitator)imitator;
										imitator.GetSpring().SetCurrentValue(0);

										// TODO: re-enable the y motion.
										//	if (imitator.getProperty() == MotionProperty.Y && !imitator.getSpring().isRegistered()) {
										//	     imitator.getSpring().register();
										//	}
									}
								}
							}

							springs[i].SetEndValue(0); // appear
						}
					}

				 };

				return mRootView;
		}
	}
}
