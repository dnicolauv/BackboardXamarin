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
using Android.Graphics;
using Com.Facebook.Rebound;
using com.tumblr.backboard;
using Android.Content.Res;

namespace BackboardXamarin
{
    public class PhotoGalleryFragment : Fragment
    {
        private static int ROWS = 5;
        private static int COLS = 4;

        private List<ImageView> mImageViews = new List<ImageView>();
        private List<Point> mPositions = new List<Point>();
        //private SpringChain mSpringChain = SpringChain.Create();
        private Spring mSpring = SpringSystem.Create().CreateSpring().SetSpringConfig(SpringConfig.FromOrigamiTensionAndFriction(40, 6));

        private int mActiveIndex;
        private int mPadding;

        private FrameLayout mRootView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        private static Color randomColor()
        {
            Random random = new Random();
            return Color.Rgb(random.Next(255), random.Next(255), random.Next(255));
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            mRootView = (FrameLayout)inflater.Inflate(Resource.Layout.photogallery_example, container, false);

            int viewCount = ROWS * COLS;

            for (int i = 0; i < viewCount; i++)
            {
                int j = i;

                // Create the View.
                ImageView imageView = new ImageView(this.Activity);
                mImageViews.Add(imageView);
                mRootView.AddView(imageView);
                imageView.Alpha = 1f;
                imageView.SetBackgroundColor(randomColor());
                imageView.SetLayerType(LayerType.Hardware, null);

                // Add an image for each view.
                int res = Resources.GetIdentifier("d" + (i % 11 + 1), "drawable", Activity.ApplicationContext.PackageName);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetImageResource(res);

                // Add a click listener to handle scaling up the view.
                imageView.Click += (sender, e) =>
                {
                    int endValue = mSpring.EndValue == 0 ? 1 : 0;
                    imageView.BringToFront();
                    mActiveIndex = j;
                    mSpring.SetEndValue(endValue);
                };
            }

                //mSpring.AddListener(new SpringImitator(mSpring));

                //mRootView.ViewTreeObserver.GlobalLayout += (sender, e) =>
                //{
                //    layout(mRootView);
                //    mRootView.ViewTreeObserver.GlobalLayout += null;
                //};

                float width = mRootView.Width;
                float height = mRootView.Height;

                // Determine the size for each image given the screen dimensions.
                mPadding = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 3, Resources.DisplayMetrics);
                int colWidth = (int)Math.Ceiling((width - 2 * mPadding) / COLS) - 2 * mPadding;
                int rowHeight = (int)Math.Ceiling((height - 2 * mPadding) / ROWS) - 2 * mPadding;

                // Determine the resting position for each view.
                int k = 0;
                int py = 0;
                for (int ii = 0; ii < ROWS; ii++)
                {
                    int px = 0;
                    py += mPadding * 2;
                    for (int jj = 0; jj < COLS; jj++)
                    {
                        px += mPadding * 2;
                        ImageView iv = mImageViews[k];
                        // imageView.LayoutParameters  = new ViewGroup.MarginLayoutParams(colWidth, rowHeight);
                        iv.LayoutParameters = new FrameLayout.LayoutParams(colWidth, rowHeight);
                        mPositions.Add(new Point(px, py));
                        px += colWidth;
                        k++;
                    }
                    py += rowHeight;
                }

            render();

                //            // Wait for layout.
                //            getViewTreeObserver().addOnGlobalLayoutListener(new ViewTreeObserver.OnGlobalLayoutListener() {
                //  @Override
                //  public void onGlobalLayout()
                //    {
                //        layout();
                //        getViewTreeObserver().removeOnGlobalLayoutListener(this);

                //        postOnAnimationDelayed(new Runnable() {
                //      @Override
                //      public void run()
                //    {
                //        mSpringChain.setControlSpringIndex(0).getControlSpring().setEndValue(1);
                //    }
                //}, 500);
                //  }
                //});

                // Add a spring to the SpringChain to do an entry animation.
                //      mSpringChain.addSpring(new SimpleSpringListener()
                //    {
                //        @Override
                //        public void onSpringUpdate(Spring spring)
                //    {
                //        render();
                //    }
                //});
           

            return mRootView;
        }

        private void render()
        {
            for (int i = 0; i < mImageViews.Count; i++)
            {
                ImageView imageView = mImageViews[i];
                if (mSpring.IsAtRest && mSpring.CurrentValue == 0)
                {
                    // Performing the initial entry transition animation.

                    //Spring spring = mSpringChain.getAllSprings().get(i);
                    Spring spring = SpringSystem.Create().CreateSpring();

                    float val = (float)spring.CurrentValue;
                    imageView.ScaleX = val;
                    imageView.ScaleY = val;
                    imageView.Alpha = val;
                    Point pos = mPositions[i];
                    imageView.TranslationX = pos.X;
                    imageView.TranslationY = pos.Y;
                }
                else
                {
                    // Scaling up a photo to fullscreen size.
                    Point pos = mPositions[i];
                    if (i == mActiveIndex)
                    {
                        float ww = imageView.Width;
                        float hh = imageView.Height;
                        float sx = imageView.Width / ww;
                        float sy = imageView.Height / hh;
                        float s = sx > sy ? sx : sy;
                        float xlatX = (float)SpringUtil.MapValueFromRangeToRange(mSpring.CurrentValue, 0, 1, pos.X, 0);
                        float xlatY = (float)SpringUtil.MapValueFromRangeToRange(mSpring.CurrentValue, 0, 1, pos.Y, 0);
                        imageView.PivotX = 0;
                        imageView.PivotY = 0;
                        imageView.TranslationX = xlatX;
                        imageView.TranslationY = xlatY;

                        float ss = (float)SpringUtil.MapValueFromRangeToRange(mSpring.CurrentValue, 0, 1, 1, s);
                        imageView.ScaleX = ss;
                        imageView.ScaleY = ss;
                    }
                    else
                    {
                        float val = (float)Math.Max(0, 1 - mSpring.CurrentValue);
                        imageView.Alpha = val;
                    }
                }
            }
        }

    }
}