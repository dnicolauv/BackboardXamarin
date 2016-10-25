
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
	//BUG
	public class ConstrainedFragment : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View rootView = inflater.Inflate(Resource.Layout.fragment_constrain, container, false);

			View constraintView = rootView.FindViewById(Resource.Id.constraint);

			View circle = rootView.FindViewById(Resource.Id.circle);

			InertialImitator motionImitatorX = new InertialImitator(MotionProperty.X, Imitator.TRACK_DELTA, Imitator.FOLLOW_SPRING, 0, 0);

			InertialImitator motionImitatorY = new InertialImitator(MotionProperty.Y, Imitator.TRACK_DELTA,	Imitator.FOLLOW_SPRING, 0, 0);

			new Actor.Builder(SpringSystem.Create(), circle)
			         .AddMotion(motionImitatorX, ViewHelper.TranslationX)
			         .AddMotion(motionImitatorY, ViewHelper.TranslationY)
					 .Build();

			EventHandler globalHandler = null;
			globalHandler += (sender, e) =>
			{
				motionImitatorX.SetMinValue(-constraintView.MeasuredWidth / 2 + circle.MeasuredWidth / 2);
				motionImitatorX.SetMaxValue(constraintView.MeasuredWidth / 2 - circle.MeasuredWidth / 2);
				motionImitatorY.SetMinValue(-constraintView.MeasuredHeight / 2 + circle.MeasuredWidth / 2);
				motionImitatorY.SetMaxValue(constraintView.MeasuredHeight / 2 - circle.MeasuredWidth / 2);
				rootView.ViewTreeObserver.GlobalLayout -= globalHandler;
			};

			rootView.ViewTreeObserver.GlobalLayout += globalHandler;

			return rootView;
		}
	}
}
