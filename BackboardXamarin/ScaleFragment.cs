
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
	public class ScaleFragment : Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View rootView = inflater.Inflate(Resource.Layout.fragment_scale, container, false);

			View rect = rootView.FindViewById(Resource.Id.rect);

			SpringSystem springSystem = SpringSystem.Create();

			Spring spring = springSystem.CreateSpring();

			spring.AddListener(new Performer(rect, View.ScaleXs));
			spring.AddListener(new Performer(rect, View.ScaleYs));


			rootView.Touch += (sender, e) => {
				switch (e.Event.Action) {
					case MotionEventActions.Down:
						spring.SetVelocity(0);
						goto case MotionEventActions.Move;
						//break;
					case MotionEventActions.Move:
					// can't use Imitation here because there is no nice mapping from
					// an event property to a Spring
					float scaleX, scaleY;
						float delta = e.Event.GetX() - (rect.GetX() + rect.MeasuredWidth / 2);
						scaleX = Math.Abs(delta) / (rect.MeasuredWidth / 2);
						delta = e.Event.GetY() - (rect.GetY() + rect.MeasuredHeight / 2);
						scaleY = Math.Abs(delta) / (rect.MeasuredHeight / 2);
						float scale = Math.Max(scaleX, scaleY);
						spring.SetEndValue(scale);
						break;
					case MotionEventActions.Up:
						spring.SetEndValue(1f);
						break;
					}
				e.Handled = true;
				//return true;
			};

			return rootView;
		}
	}
}
