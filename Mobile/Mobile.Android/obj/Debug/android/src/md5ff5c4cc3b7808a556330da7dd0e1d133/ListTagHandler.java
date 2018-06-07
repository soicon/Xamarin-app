package md5ff5c4cc3b7808a556330da7dd0e1d133;


public class ListTagHandler
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.text.Html.TagHandler
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_handleTag:(ZLjava/lang/String;Landroid/text/Editable;Lorg/xml/sax/XMLReader;)V:GetHandleTag_ZLjava_lang_String_Landroid_text_Editable_Lorg_xml_sax_XMLReader_Handler:Android.Text.Html/ITagHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Mobile.Droid.Views.Customs.CustomHtml.ListTagHandler, Mobile.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ListTagHandler.class, __md_methods);
	}


	public ListTagHandler ()
	{
		super ();
		if (getClass () == ListTagHandler.class)
			mono.android.TypeManager.Activate ("Mobile.Droid.Views.Customs.CustomHtml.ListTagHandler, Mobile.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void handleTag (boolean p0, java.lang.String p1, android.text.Editable p2, org.xml.sax.XMLReader p3)
	{
		n_handleTag (p0, p1, p2, p3);
	}

	private native void n_handleTag (boolean p0, java.lang.String p1, android.text.Editable p2, org.xml.sax.XMLReader p3);

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
