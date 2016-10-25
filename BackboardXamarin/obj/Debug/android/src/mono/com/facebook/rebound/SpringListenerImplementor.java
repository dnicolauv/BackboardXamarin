package mono.com.facebook.rebound;


public class SpringListenerImplementor
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
		mono.android.Runtime.register ("Com.Facebook.Rebound.ISpringListenerImplementor, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SpringListenerImplementor.class, __md_methods);
	}


	public SpringListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SpringListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Facebook.Rebound.ISpringListenerImplementor, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
