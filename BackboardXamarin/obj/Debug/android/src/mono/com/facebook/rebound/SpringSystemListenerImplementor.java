package mono.com.facebook.rebound;


public class SpringSystemListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.facebook.rebound.SpringSystemListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAfterIntegrate:(Lcom/facebook/rebound/BaseSpringSystem;)V:GetOnAfterIntegrate_Lcom_facebook_rebound_BaseSpringSystem_Handler:Com.Facebook.Rebound.ISpringSystemListenerInvoker, ReboundDroid\n" +
			"n_onBeforeIntegrate:(Lcom/facebook/rebound/BaseSpringSystem;)V:GetOnBeforeIntegrate_Lcom_facebook_rebound_BaseSpringSystem_Handler:Com.Facebook.Rebound.ISpringSystemListenerInvoker, ReboundDroid\n" +
			"";
		mono.android.Runtime.register ("Com.Facebook.Rebound.ISpringSystemListenerImplementor, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SpringSystemListenerImplementor.class, __md_methods);
	}


	public SpringSystemListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SpringSystemListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Facebook.Rebound.ISpringSystemListenerImplementor, ReboundDroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onAfterIntegrate (com.facebook.rebound.BaseSpringSystem p0)
	{
		n_onAfterIntegrate (p0);
	}

	private native void n_onAfterIntegrate (com.facebook.rebound.BaseSpringSystem p0);


	public void onBeforeIntegrate (com.facebook.rebound.BaseSpringSystem p0)
	{
		n_onBeforeIntegrate (p0);
	}

	private native void n_onBeforeIntegrate (com.facebook.rebound.BaseSpringSystem p0);

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
