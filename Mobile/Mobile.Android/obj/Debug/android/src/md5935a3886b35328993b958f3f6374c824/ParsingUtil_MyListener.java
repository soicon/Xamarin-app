package md5935a3886b35328993b958f3f6374c824;


public class ParsingUtil_MyListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		java.lang.Runnable
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler:Java.Lang.IRunnableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Plugin.Iconize.Droid.ParsingUtil+MyListener, Plugin.Iconize.Droid", ParsingUtil_MyListener.class, __md_methods);
	}


	public ParsingUtil_MyListener ()
	{
		super ();
		if (getClass () == ParsingUtil_MyListener.class)
			mono.android.TypeManager.Activate ("Plugin.Iconize.Droid.ParsingUtil+MyListener, Plugin.Iconize.Droid", "", this, new java.lang.Object[] {  });
	}

	public ParsingUtil_MyListener (android.view.View p0)
	{
		super ();
		if (getClass () == ParsingUtil_MyListener.class)
			mono.android.TypeManager.Activate ("Plugin.Iconize.Droid.ParsingUtil+MyListener, Plugin.Iconize.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
