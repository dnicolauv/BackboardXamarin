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
using static Android.Views.ScaleGestureDetector;

namespace BackboardXamarin
{
    public class ZoomFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

  
        class OnScaleGestureListener : Java.Lang.Object, IOnScaleGestureListener
        {
            Spring spring;
            public OnScaleGestureListener(Spring _spring)
            {
                spring = _spring;
            }

            public bool OnScale(ScaleGestureDetector detector)
            {
                spring.SetCurrentValue(spring.CurrentValue * detector.ScaleFactor);
                return true;
            }

            public bool OnScaleBegin(ScaleGestureDetector detector)
            {
                return true;
            }

            public void OnScaleEnd(ScaleGestureDetector detector)
            {
                spring.SetEndValue(1.0f);
            }
        }
        

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_scale, container, false);

            View rect = rootView.FindViewById(Resource.Id.rect);

            SpringSystem springSystem = SpringSystem.Create();
            Spring spring = springSystem.CreateSpring();

            spring.AddListener(new Performer(rect, View.ScaleXs));
            spring.AddListener(new Performer(rect, View.ScaleYs));

            spring.SetCurrentValue(1.0f);

            ScaleGestureDetector scaleGestureDetector = new ScaleGestureDetector(this.Activity, new OnScaleGestureListener(spring));

            rootView.Touch += (sender, e) =>
            {
                e.Handled = scaleGestureDetector.OnTouchEvent(e.Event);
            };

		    return rootView;
        }
    }
}