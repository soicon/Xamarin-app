package md51bdd874b4d43ff2ff5f812ac64660031;


public class BottomTabbedRenderer
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer,
		android.support.design.widget.BottomNavigationView.OnNavigationItemSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onDetachedFromWindow:()V:GetOnDetachedFromWindowHandler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"n_onNavigationItemSelected:(Landroid/view/MenuItem;)Z:GetOnNavigationItemSelected_Landroid_view_MenuItem_Handler:Android.Support.Design.Widget.BottomNavigationView/IOnNavigationItemSelectedListenerInvoker, Xamarin.Android.Support.Design\n" +
			"";
		mono.android.Runtime.register ("Naxam.Controls.Platform.Droid.BottomTabbedRenderer, Naxam.BottomTabbedPage.Platform.Droid, Version=0.2.0.3, Culture=neutral, PublicKeyToken=null", BottomTabbedRenderer.class, __md_methods);
	}


	public BottomTabbedRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BottomTabbedRenderer.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Platform.Droid.BottomTabbedRenderer, Naxam.BottomTabbedPage.Platform.Droid, Version=0.2.0.3, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BottomTabbedRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BottomTabbedRenderer.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Platform.Droid.BottomTabbedRenderer, Naxam.BottomTabbedPage.Platform.Droid, Version=0.2.0.3, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public BottomTabbedRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BottomTabbedRenderer.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Platform.Droid.BottomTabbedRenderer, Naxam.BottomTabbedPage.Platform.Droid, Version=0.2.0.3, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


	public void onDetachedFromWindow ()
	{
		n_onDetachedFromWindow ();
	}

	private native void n_onDetachedFromWindow ();


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);


	public boolean onNavigationItemSelected (android.view.MenuItem p0)
	{
		return n_onNavigationItemSelected (p0);
	}

	private native boolean n_onNavigationItemSelected (android.view.MenuItem p0);

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
