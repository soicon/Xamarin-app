package md58a14a748486a7951d3cf81a33fb7d3b0;


public class JavaScriptResult
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.webkit.ValueCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceiveValue:(Ljava/lang/Object;)V:GetOnReceiveValue_Ljava_lang_Object_Handler:Android.Webkit.IValueCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("TEditor.JavaScriptResult, TEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", JavaScriptResult.class, __md_methods);
	}


	public JavaScriptResult ()
	{
		super ();
		if (getClass () == JavaScriptResult.class)
			mono.android.TypeManager.Activate ("TEditor.JavaScriptResult, TEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceiveValue (java.lang.Object p0)
	{
		n_onReceiveValue (p0);
	}

	private native void n_onReceiveValue (java.lang.Object p0);

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
