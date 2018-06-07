using Android.Content;
using Android.Graphics.Drawables;
using Mobile;
using Mobile.Droid.Views.Customs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace Mobile.Droid.Views.Customs
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            UpdateBorders();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null) return;

            if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)
                UpdateBorders();
        }

        void UpdateBorders()
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(0);

            if (((ExtendedEntry)this.Element).IsBorderErrorVisible)
            {
                shape.SetStroke(3, ((ExtendedEntry)this.Element).BorderErrorColor.ToAndroid());
            }
            else
            {
                shape.SetStroke(3, Android.Graphics.Color.LightGray);
                this.Control.SetBackground(shape);
            }

            this.Control.SetBackground(shape);
        }
    }
}