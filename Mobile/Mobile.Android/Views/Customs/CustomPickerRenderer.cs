using Android.Content;
using Android.Graphics.Drawables;
using System.ComponentModel;
using Mobile;
using Mobile.Droid.Views.Customs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace Mobile.Droid.Views.Customs
{
    public class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            SetControlStyle();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetControlStyle();
        }
        private void SetControlStyle()
        {
            if (Control != null)
            {
                Drawable imgDropDownArrow = Resources.GetDrawable(Resource.Drawable.ddarrow);
                imgDropDownArrow.SetBounds(5, 5, 5, 5);
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, imgDropDownArrow, null);
            }
        }
    }
}