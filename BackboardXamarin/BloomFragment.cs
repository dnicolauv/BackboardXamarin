
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
	public class BloomFragment : Fragment
	{

		private static int DIAMETER = 80;
		private static int RING_DIAMETER = 5 * DIAMETER;

		private static int OPEN = 1;
		private static int CLOSED = 0;

		private RelativeLayout mRootView;
		private View[] mCircles;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			mRootView = (RelativeLayout)inflater.Inflate(Resource.Layout.fragment_bloom, container, false);

			mCircles = new View[6];

			float diameter = TypedValue.ApplyDimension(ComplexUnitType.Dip, DIAMETER,	Resources.DisplayMetrics);

			TypedArray circles = Resources.ObtainTypedArray(Resource.Array.circles);

			// layout params
			RelativeLayout.LayoutParams paramss = new RelativeLayout.LayoutParams((int)diameter, (int)diameter);
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

				mRootView.AddView(mCircles[i]);
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

				spring.AddListener(new MapPerformer(view, View.GetViewStaticProperty("TranslationY"), 0, 1, 0, (float)(RING_DIAMETER * Math.Sin(i * arc))));

				spring.SetEndValue(CLOSED);
			}

			mRootView.SetOnTouchListener(new ToggleImitator(spring, CLOSED, OPEN));

			return mRootView;
		}
	}
}
