using System;
using Android.App;
using Android.OS;
using Android.Views;
using Com.Facebook.Rebound;
using com.tumblr.backboard;

namespace BackboardXamarin
{
	public class MoveFragment : Fragment
	{


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
				View rootView = inflater.Inflate(Resource.Layout.fragment_move, container, false);

				new Actor.Builder(SpringSystem.Create(), rootView.FindViewById(Resource.Id.circle))
				                 .AddTranslateMotion(Imitator.TRACK_DELTA, Imitator.FOLLOW_EXACT, MotionProperty.X)
								.AddTranslateMotion(Imitator.TRACK_DELTA, Imitator.FOLLOW_EXACT, MotionProperty.Y)
								.Build();
		
			return rootView;
		}
	}
}
