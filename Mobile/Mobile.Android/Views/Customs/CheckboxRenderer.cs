using Android.Content;
using System;
using System.ComponentModel;
using Mobile.Droid.Views.Customs;
using Mobile;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Checkbox), typeof(CheckboxRenderer))]
namespace Mobile.Droid.Views.Customs
{
    /// <summary>
    /// Class CheckBoxRenderer.
    /// </summary>
    public class CheckboxRenderer : ViewRenderer<Checkbox, Android.Widget.CheckBox>
    {
        public CheckboxRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
            var temp = DateTime.Now;
        }

        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Checkbox> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null)
            {
                var checkBox = new Android.Widget.CheckBox(this.Context);
                if (Element.WidthRequest >= 0)
                {
                    checkBox.SetWidth((int)Element.WidthRequest);
                    checkBox.SetHeight((int)Element.WidthRequest);
                }
                checkBox.CheckedChange += CheckBoxCheckedChange;
                SetNativeControl(checkBox);
            }
            Control.Text = e.NewElement.Text;
            Control.SetSingleLine(false);
            if (e.NewElement != null)
            {
                if (e.NewElement.WidthRequest >= 0)
                {
                    Control.SetHeight((int)e.NewElement.WidthRequest);
                    Control.SetWidth((int)e.NewElement.WidthRequest);
                }
                Control.Checked = e.NewElement.Checked;
                Control.Enabled = e.NewElement.IsEnabled;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", e.PropertyName);
                    break;
            }
        }

        /// <summary>
        /// CheckBoxes the checked change.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Android.Widget.CompoundButton.CheckedChangeEventArgs"/> instance containing the event data.</param>
        void CheckBoxCheckedChange(object sender, Android.Widget.CompoundButton.CheckedChangeEventArgs e)
        {
            this.Element.Checked = e.IsChecked;
        }

    }
}