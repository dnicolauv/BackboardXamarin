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
    public class PressFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_press, container, false);

            new Actor.Builder(SpringSystem.Create(), rootView.FindViewById(Resource.Id.circle))
                    .AddMotion(new ToggleImitator(null, 1.0, 0.5), View.ScaleXs, View.ScaleYs)
                    .Build();

            return rootView;
        }
    }
}