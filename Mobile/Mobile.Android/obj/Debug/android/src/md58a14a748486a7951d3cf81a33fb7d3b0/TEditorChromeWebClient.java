package md58a14a748486a7951d3cf81a33fb7d3b0;


public class TEditorChromeWebClient
	extends android.webkit.WebChromeClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onConsoleMessage:(Landroid/webkit/ConsoleMessage;)Z:GetOnConsoleMessage_Landroid_webkit_ConsoleMessage_Handler\n" +
			"";
		mono.android.Runtime.register ("TEditor.TEditorChromeWebClient, TEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TEditorChromeWebClient.class, __md_methods);
	}


	public TEditorChromeWebClient ()
	{
		super ();
		if (getClass () == TEditorChromeWebClient.class)
			mono.android.TypeManager.Activate ("TEditor.TEditorChromeWebClient, TEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onConsoleMessage (android.webkit.ConsoleMessage p0)
	{
		return n_onConsoleMessage (p0);
	}

	private native boolean n_onConsoleMessage (android.webkit.ConsoleMessage p0);

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
