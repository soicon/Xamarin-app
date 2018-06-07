package md5935a3886b35328993b958f3f6374c824;


public class MenuClickListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.MenuItem.OnMenuItemClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMenuItemClick:(Landroid/view/MenuItem;)Z:GetOnMenuItemClick_Landroid_view_MenuItem_Handler:Android.Views.IMenuItemOnMenuItemClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Plugin.Iconize.Droid.MenuClickListener, Plugin.Iconize.Droid", MenuClickListener.class, __md_methods);
	}


	public MenuClickListener ()
	{
		super ();
		if (getClass () == MenuClickListener.class)
			mono.android.TypeManager.Activate ("Plugin.Iconize.Droid.MenuClickListener, Plugin.Iconize.Droid", "", this, new java.lang.Object[] {  });
	}


	public boolean onMenuItemClick (android.view.MenuItem p0)
	{
		return n_onMenuItemClick (p0);
	}

	private native boolean n_onMenuItemClick (android.view.MenuItem p0);

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
