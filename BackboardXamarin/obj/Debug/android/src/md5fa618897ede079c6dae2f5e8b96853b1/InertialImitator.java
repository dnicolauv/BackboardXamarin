package md5fa618897ede079c6dae2f5e8b96853b1;


public class InertialImitator
	extends md5fa618897ede079c6dae2f5e8b96853b1.ConstrainedMotionImitator
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
		mono.android.Runtime.register ("com.tumblr.backboard.InertialImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", InertialImitator.class, __md_methods);
	}


	public InertialImitator () throws java.lang.Throwable
	{
		super ();
		if (getClass () == InertialImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.InertialImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public InertialImitator (double p0, int p1, int p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == InertialImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.InertialImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Double, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}

	public InertialImitator (com.facebook.rebound.Spring p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == InertialImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.InertialImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Com.Facebook.Rebound.Spring, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	public InertialImitator (com.facebook.rebound.Spring p0, int p1, int p2) throws java.lang.Throwable
	{
		super ();
		if (getClass () == InertialImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.InertialImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Com.Facebook.Rebound.Spring, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}

	public InertialImitator (com.facebook.rebound.Spring p0, double p1, int p2, int p3) throws java.lang.Throwable
	{
		super ();
		if (getClass () == InertialImitator.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.InertialImitator, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Com.Facebook.Rebound.Spring, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:System.Double, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
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
