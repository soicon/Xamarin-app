package md5cc28a13ec9786609168463ab72eb4034;


public class DropDownMenuRender_Android
	extends md51558244f76c53b6aeda52c8a337f2c37.ViewRenderer_2
	implements
		mono.android.IGCUserPeer,
		android.widget.AdapterView.OnItemSelectedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onItemSelected:(Landroid/widget/AdapterView;Landroid/view/View;IJ)V:GetOnItemSelected_Landroid_widget_AdapterView_Landroid_view_View_IJHandler:Android.Widget.AdapterView/IOnItemSelectedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onNothingSelected:(Landroid/widget/AdapterView;)V:GetOnNothingSelected_Landroid_widget_AdapterView_Handler:Android.Widget.AdapterView/IOnItemSelectedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Mobile.Droid.Views.Customs.DropDownMenuRender_Android, Mobile.Android", DropDownMenuRender_Android.class, __md_methods);
	}


	public DropDownMenuRender_Android (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == DropDownMenuRender_Android.class)
			mono.android.TypeManager.Activate ("Mobile.Droid.Views.Customs.DropDownMenuRender_Android, Mobile.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public DropDownMenuRender_Android (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == DropDownMenuRender_Android.class)
			mono.android.TypeManager.Activate ("Mobile.Droid.Views.Customs.DropDownMenuRender_Android, Mobile.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public DropDownMenuRender_Android (android.content.Context p0)
	{
		super (p0);
		if (getClass () == DropDownMenuRender_Android.class)
			mono.android.TypeManager.Activate ("Mobile.Droid.Views.Customs.DropDownMenuRender_Android, Mobile.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onItemSelected (android.widget.AdapterView p0, android.view.View p1, int p2, long p3)
	{
		n_onItemSelected (p0, p1, p2, p3);
	}

	private native void n_onItemSelected (android.widget.AdapterView p0, android.view.View p1, int p2, long p3);


	public void onNothingSelected (android.widget.AdapterView p0)
	{
		n_onNothingSelected (p0);
	}

	private native void n_onNothingSelected (android.widget.AdapterView p0);

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
