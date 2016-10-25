package md5fa618897ede079c6dae2f5e8b96853b1;


public class ToggleImitator
	extends md5fa618897ede079c6dae2f5e8b96853b1.EventImitator
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnTouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("com.tumblr.backboard.ToggleImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ToggleImitator.class, __md_methods);
	}


	public ToggleImitator () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ToggleImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.ToggleImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public ToggleImitator (double p0, int p1, int p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == ToggleImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.ToggleImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Double, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}

	public ToggleImitator (com.facebook.rebound.Spring p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == ToggleImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.ToggleImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Com.Facebook.Rebound.Spring, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	public ToggleImitator (com.facebook.rebound.Spring p0, int p1, int p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == ToggleImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.ToggleImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Com.Facebook.Rebound.Spring, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}

	public ToggleImitator (com.facebook.rebound.Spring p0, double p1, int p2, int p3) throws java.lang.Throwable
	{
		super ();
		if (getClass () == ToggleImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.ToggleImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Com.Facebook.Rebound.Spring, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:System.Double, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public boolean onTouch (android.view.View p0, android.view.MotionEvent p1)
	{
		return n_onTouch (p0, p1);
	}

	private native boolean n_onTouch (android.view.View p0, android.view.MotionEvent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
