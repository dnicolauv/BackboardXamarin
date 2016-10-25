package md5fa618897ede079c6dae2f5e8b96853b1;


public class Performer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.facebook.rebound.SpringListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSpringActivate:(Lcom/facebook/rebound/Spring;)V:GetOnSpringActivate_Lcom_facebook_rebound_Spring_Handler:Com.Facebook.Rebound.ISpringListenerInvoker, ReboundDroid\n" +
			"n_onSpringAtRest:(Lcom/facebook/rebound/Spring;)V:GetOnSpringAtRest_Lcom_facebook_rebound_Spring_Handler:Com.Facebook.Rebound.ISpringListenerInvoker, ReboundDroid\n" +
			"n_onSpringEndStateChange:(Lcom/facebook/rebound/Spring;)V:GetOnSpringEndStateChange_Lcom_facebook_rebound_Spring_Handler:Com.Facebook.Rebound.ISpringListenerInvoker, ReboundDroid\n" +
			"n_onSpringUpdate:(Lcom/facebook/rebound/Spring;)V:GetOnSpringUpdate_Lcom_facebook_rebound_Spring_Handler:Com.Facebook.Rebound.ISpringListenerInvoker, ReboundDroid\n" +
			"";
		mono.android.Runtime.register ("com.tumblr.backboard.Performer, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Performer.class, __md_methods);
	}


	public Performer () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Performer.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.Performer, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public Performer (android.util.Property p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Performer.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.Performer, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Util.Property, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	public Performer (android.view.View p0, android.util.Property p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == Performer.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.Performer, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.Property, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public void onSpringActivate (com.facebook.rebound.Spring p0)
	{
		n_onSpringActivate (p0);
	}

	private native void n_onSpringActivate (com.facebook.rebound.Spring p0);


	public void onSpringAtRest (com.facebook.rebound.Spring p0)
	{
		n_onSpringAtRest (p0);
	}

	private native void n_onSpringAtRest (com.facebook.rebound.Spring p0);


	public void onSpringEndStateChange (com.facebook.rebound.Spring p0)
	{
		n_onSpringEndStateChange (p0);
	}

	private native void n_onSpringEndStateChange (com.facebook.rebound.Spring p0);


	public void onSpringUpdate (com.facebook.rebound.Spring p0)
	{
		n_onSpringUpdate (p0);
	}

	private native void n_onSpringUpdate (com.facebook.rebound.Spring p0);

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
