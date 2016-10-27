using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace BackboardXamarin
{
	[Activity(Label = "BackboardXamarin", MainLauncher = true, Icon = "@mipmap/icon")]
	public class BackboardActivity : Activity
	{
		int count = 1;
	
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_backboard);

			// Get our button from the layout resource,
			// and attach an event to it
			if (savedInstanceState == null)
			{
				this.FragmentManager.BeginTransaction().Add(Resource.Id.container, new MoveFragment()).Commit();
				SetTitle(Resource.String.action_move);
			}

			/*FragmentManager.BeginTransaction()
							.Replace(Resource.Id.container, new MoveFragment())
							.Commit();
			SetTitle(Resource.String.action_move);*/
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{			
			MenuInflater.Inflate(Resource.Menu.backboard, menu);
			return true;
			//return base.OnCreateOptionsMenu(menu);
		}


		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			// Handle action bar item clicks here. The action bar will
			// automatically handle clicks on the Home/Up button, so long
			// as you specify a parent activity in AndroidManifest.xml.
			int id = item.ItemId;

			switch (id)
			{
				case Resource.Id.action_move:
					FragmentManager.BeginTransaction()
							.Replace(Resource.Id.container, new MoveFragment())
							.Commit();
					SetTitle(Resource.String.action_move);
					return true;

				case Resource.Id.action_snap:
					FragmentManager.BeginTransaction()
							.Replace(Resource.Id.container, new SnapFragment())
							.Commit();
					SetTitle(Resource.String.action_snap);
					return true;

				case Resource.Id.action_scale:
					FragmentManager.BeginTransaction()
							.Replace(Resource.Id.container, new ScaleFragment())
							.Commit();
					SetTitle(Resource.String.action_scale);
					return true;


				case Resource.Id.action_bloom:
					FragmentManager.BeginTransaction()
							.Replace(Resource.Id.container, new BloomFragment())
							.Commit();
					SetTitle(Resource.String.action_bloom);
					return true;
					
				case Resource.Id.action_flower:
					FragmentManager.BeginTransaction()
							.Replace(Resource.Id.container, new FlowerFragment())
							.Commit();
					SetTitle(Resource.String.action_flower);
					return true;
					
				case Resource.Id.action_appear:
					FragmentManager.BeginTransaction()
							.Replace(Resource.Id.container, new AppearFragment())
							.Commit();
					SetTitle(Resource.String.action_appear);
					return true;

				case Resource.Id.action_constrained:
					FragmentManager.BeginTransaction()
							.Replace(Resource.Id.container, new ConstrainedFragment())
							.Commit();
					SetTitle(Resource.String.action_constrained);
					return true;

                case Resource.Id.action_follow:
                    FragmentManager.BeginTransaction()
                            .Replace(Resource.Id.container, new FollowFragment())
                            .Commit();
                    SetTitle(Resource.String.action_follow);
                    return true;
                /*

            case Resource.Id.action_explosion:
                FragmentManager.BeginTransaction()
                        .Replace(Resource.Id.container, new ExplosionFragment())
                        .Commit();
                SetTitle(Resource.String.action_explosion);
                return true;



            case Resource.Id.action_zoom:
                FragmentManager.BeginTransaction()
                        .Replace(Resource.Id.container, new ZoomFragment())
                        .Commit();
                SetTitle(Resource.String.action_zoom);
                return true;

            case Resource.Id.action_press:
                FragmentManager.BeginTransaction()
                        .Replace(Resource.Id.container, new PressFragment())
                        .Commit();
                SetTitle(Resource.String.action_press);
                return true;
                */

                //REBOUND EXAMPLES

                case Resource.Id.action_origami:
					FragmentManager.BeginTransaction()
					.Replace(Resource.Id.container, new OrigamiFragment())
							.Commit();
					SetTitle(Resource.String.action_origami);
					return true;
			}

			return base.OnOptionsItemSelected(item);
		}
	}
}

