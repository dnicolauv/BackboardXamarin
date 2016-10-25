package md5fa618897ede079c6dae2f5e8b96853b1;


public class MapPerformer
	extends md5fa618897ede079c6dae2f5e8b96853b1.Performer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("com.tumblr.backboard.MapPerformer, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MapPerformer.class, __md_methods);
	}


	public MapPerformer () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MapPerformer.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.MapPerformer, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MapPerformer (android.util.Property p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MapPerformer.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.MapPerformer, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Util.Property, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	public MapPerformer (android.view.View p0, android.util.Property p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MapPerformer.class)
			mono.android.TypeManager.Activate ("com.tumblr.backboard.MapPerformer, BackboardLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.Property, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}

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
