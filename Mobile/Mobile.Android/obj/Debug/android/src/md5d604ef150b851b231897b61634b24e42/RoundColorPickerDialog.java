package md5d604ef150b851b231897b61634b24e42;


public class RoundColorPickerDialog
	extends android.app.Dialog
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MonoDroid.ColorPickers.RoundColorPickerDialog, TEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RoundColorPickerDialog.class, __md_methods);
	}


	public RoundColorPickerDialog (android.content.Context p0)
	{
		super (p0);
		if (getClass () == RoundColorPickerDialog.class)
			mono.android.TypeManager.Activate ("MonoDroid.ColorPickers.RoundColorPickerDialog, TEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public RoundColorPickerDialog (android.content.Context p0, boolean p1, android.content.DialogInterface.OnCancelListener p2)
	{
		super (p0, p1, p2);
		if (getClass () == RoundColorPickerDialog.class)
			mono.android.TypeManager.Activate ("MonoDroid.ColorPickers.RoundColorPickerDialog, TEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Boolean, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:Android.Content.IDialogInterfaceOnCancelListener, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public RoundColorPickerDialog (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == RoundColorPickerDialog.class)
			mono.android.TypeManager.Activate ("MonoDroid.ColorPickers.RoundColorPickerDialog, TEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
