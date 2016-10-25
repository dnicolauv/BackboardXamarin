
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
	public class SnapFragment : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			View rootView = inflater.Inflate(Resource.Layout.fragment_snap, container, false);

			View circle = rootView.FindViewById(Resource.Id.circle);

			MotionImitator motionImitator = new MotionImitator(MotionProperty.X);

			motionImitator.Release = (obj) =>
			{
				// snap to left or right depending on current location
				if (motionImitator.mSpring.CurrentValue  > rootView.MeasuredWidth / 2 - circle.MeasuredWidth / 2)
				{
					motionImitator.mSpring.SetEndValue(rootView.MeasuredWidth - circle.MeasuredWidth);
				}
				else {

					motionImitator.mSpring.SetEndValue(0);
				}
			};

			new Actor.Builder(SpringSystem.Create(), circle)
					.AddTranslateMotion(MotionProperty.Y)
			         .AddMotion(motionImitator, View.GetViewStaticProperty("TranslationX"))
			         .Build();

			return rootView;

			//return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}
