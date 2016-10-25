
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using com.tumblr.backboard;
using Com.Facebook.Rebound;

namespace BackboardXamarin
{
	public class FlowerFragment : Fragment
	{

		private static int DIAMETER = 50;
		private static int RING_DIAMETER = 7 * DIAMETER;

		private RelativeLayout mRootView;
		private static View mCircle;
		private static View[] mCircles;

		private static int OPEN = 1;
		private static int CLOSED = 0;

		private static double DistSq(double x1, double y1, double x2, double y2)
		{
			return Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2);
		}

		private static View Nearest(float x, float y, View[] views)
		{
			double minDistSq = Java.Lang.Double.MaxValue;
			View minView = null;

			foreach (View view in views)
			{
				double distSq = DistSq(x, y, view.GetX() + view.MeasuredWidth / 2, view.GetY() + view.MeasuredHeight / 2);

				if (distSq < Math.Pow(1.5f * view.MeasuredWidth, 2) && distSq < minDistSq)
				{
					minDistSq = distSq;
					minView = view;
				}
			}

			return minView;
		}

		/**
		 * Snaps to the nearest circle.
		 */
		//DNV REVIEW
		public class SnapImitator : MotionImitator
		{

			public SnapImitator(MotionProperty property) : base(property, 0, Imitator.TRACK_ABSOLUTE, Imitator.FOLLOW_SPRING)
			{
				//super(property, 0, Imitator.TRACK_ABSOLUTE, Imitator.FOLLOW_SPRING);
			}

			public override void Mime(float offset, float value, float delta, float dt, MotionEvent ev) {
				// find the nearest view
				View nearest = Nearest(ev.GetX() + mCircle.GetX(), ev.GetY() + mCircle.GetY(), mCircles);

				if (nearest != null) {
				// snap to it - remember to compensate for translatio
					if (mProperty == MotionProperty.X)
					{
						GetSpring().SetEndValue(nearest.GetX() + nearest.Width / 2 - mCircle.Left - mCircle.Width / 2);
					}
					else if (mProperty == MotionProperty.Y)
					{
						GetSpring().SetEndValue(nearest.GetY() + nearest.Height / 2 - mCircle.Top - mCircle.Height / 2);
					}
				}
				 else {
					// follow finger
					base.Mime(offset, value, delta, dt, ev);
				}

			}
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			mRootView = (RelativeLayout)inflater.Inflate(Resource.Layout.fragment_flower, container, false);

			mCircles = new View[6];
			mCircle = mRootView.FindViewById(Resource.Id.circle);

			float diameter = TypedValue.ApplyDimension(ComplexUnitType.Dip,  DIAMETER, Resources.DisplayMetrics);

			TypedArray circles = Resources.ObtainTypedArray(Resource.Array.circles);

			// layout params
			RelativeLayout.LayoutParams paramss = new RelativeLayout.LayoutParams((int)diameter,
					(int)diameter);
			paramss.AddRule(LayoutRules.CenterInParent);

			// create the circle views
			int colorIndex = 0;
			for (int i = 0; i < mCircles.Length; i++)
			{
				mCircles[i] = new View(Activity);

				mCircles[i].LayoutParameters = paramss;

				mCircles[i].SetBackgroundDrawable(Resources.GetDrawable(circles.GetResourceId(colorIndex, -1)));

				colorIndex++;
				if (colorIndex >= circles.Length())
				{
					colorIndex = 0;
				}

				mRootView.AddView(mCircles[i], 0);
			}

			circles.Recycle();

			/* Animations! */

			SpringSystem springSystem = SpringSystem.Create();

			// create spring
			Spring spring = springSystem.CreateSpring();

			// add listeners along arc
			double arc = 2 * Math.PI / mCircles.Length;

			for (int i = 0; i < mCircles.Length; i++)
			{
				View view = mCircles[i];

				// map spring to a line segment from the center to the edge of the ring
				spring.AddListener(new MapPerformer(view, View.GetViewStaticProperty("TranslationX"), 0, 1,	0, (float)(RING_DIAMETER * Math.Cos(i * arc))));

				spring.AddListener(new MapPerformer(view, View.GetViewStaticProperty("TranslationY"), 0, 1,	0, (float)(RING_DIAMETER * Math.Sin(i * arc))));

				spring.SetEndValue(CLOSED);
			}

			ToggleImitator imitator = new ToggleImitator(spring, CLOSED, OPEN);


			// move circle using finger, snap when near another circle, and bloom when touched
			new Actor.Builder(SpringSystem.Create(), mCircle)
			         .AddMotion(new SnapImitator(MotionProperty.X), View.GetViewStaticProperty("TranslationX"))
					 .AddMotion(new SnapImitator(MotionProperty.Y), View.GetViewStaticProperty("TranslationY"))
					 .OnTouchListener(imitator)
					 .Build();

			return mRootView;
		}
	}
}
