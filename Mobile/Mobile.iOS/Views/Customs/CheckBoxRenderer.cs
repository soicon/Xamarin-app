using CoreGraphics;
using System;
using System.ComponentModel;
using Mobile;
using Mobile.iOS.Views.Customs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Checkbox), typeof(CheckboxRenderer))]
namespace Mobile.iOS.Views.Customs
{
    /// <summary>
    /// Class CheckBoxRenderer.
    /// </summary>
    public class CheckboxRenderer : ViewRenderer<Checkbox, M13Checkbox>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public new static void Init()
        {
            var temp = DateTime.Now;
        }

        private CGRect _originalBounds;

        /// <summary>
        /// Handles the Element Changed event
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Checkbox> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            BackgroundColor = Element.BackgroundColor.ToUIColor();
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var width = (double)Constants.CheckboxDefaultHeight;
                    if (Element.WidthRequest >= 0)
                    {
                        width = Element.WidthRequest;
                    }
                    var checkBox = new M13Checkbox(new CGRect(0, 0, width, width));

					//checkBox.Bounds = new CGRect(0, 0, width, width);

					checkBox.LineBreakMode = UIKit.UILineBreakMode.WordWrap;
					Console.WriteLine("Txt" +e.NewElement.Text);
					checkBox.CheckedTitle = e.NewElement.Text;
					checkBox.UncheckedTitle =  e.NewElement.Text;
					//checkBox.CheckedChanged += (s, args) => Element.Checked = args.Checked;
					checkBox.CheckedChanged += CheckBoxCheckedChange;
                    SetNativeControl(checkBox);
                    // Issue with list rendering
                    _originalBounds = checkBox.Bounds;
					checkBox.SetCheckState(e.NewElement.Checked
                                ? CheckboxState.Checked : CheckboxState.Unchecked);
					checkBox.SetEnabled(e.NewElement.IsEnabled);
					checkBox.Bounds = _originalBounds;
                }

                Control.SetCheckState(e.NewElement.Checked
                    ? CheckboxState.Checked : CheckboxState.Unchecked);
                Control.SetEnabled(e.NewElement.IsEnabled);
                Control.Bounds = _originalBounds;

				//if (e.NewElement != null)
                //{
                //    if (e.NewElement.WidthRequest >= 0)
                //    {
                //        Control.SetHeight((int)e.NewElement.WidthRequest);
                //        Control.SetWidth((int)e.NewElement.WidthRequest);
                //    }
                //    Control.Checked = e.NewElement.Checked;
                //    Control.Enabled = e.NewElement.IsEnabled;
                //}
            }
        }
		void CheckBoxCheckedChange(object sender, CheckedChangedEventArgs e)
        {
			this.Element.Checked = e.Checked;
        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
			Console.WriteLine(e.PropertyName);
            switch (e.PropertyName)
            {
				//case "IsVisible":
				//    Control.Hidden = Element.IsVisible;
				//    break;

                case "IsEnabled":
                    Control.SetEnabled(Element.IsEnabled);
                    break;
                case "Checked":
                    Control.SetCheckState(Element.Checked ? CheckboxState.Checked : CheckboxState.Unchecked);
                    break;

            }
        }
    }
}