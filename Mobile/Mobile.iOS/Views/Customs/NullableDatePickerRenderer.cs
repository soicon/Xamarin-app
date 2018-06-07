using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using System.Collections.Generic;
using Mobile;
using Mobile.iOS.Views.Customs;

[assembly: ExportRenderer(typeof(NullableDatePicker), typeof(NullableDatePickerRenderer))]
namespace Mobile.iOS.Views.Customs
{
    public class NullableDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && this.Control != null)
            {
                this.AddClearButton();

                this.Control.BorderStyle = UITextBorderStyle.Line;
                Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                Control.Layer.BorderWidth = 1;

                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    this.Control.Font = UIFont.SystemFontOfSize(25);
                }
            }

        }

        private void AddClearButton()
        {
            var originalToolbar = this.Control.InputAccessoryView as UIToolbar;

            if (originalToolbar != null && originalToolbar.Items.Length <= 2)
            {
                var clearButton = new UIBarButtonItem("Clear", UIBarButtonItemStyle.Plain, ((sender, ev) =>
                {
                    NullableDatePicker baseDatePicker = this.Element as NullableDatePicker;
                    this.Element.Unfocus();
                    this.Element.Date = DateTime.Now;
                    baseDatePicker.CleanDate();

                }));

                var newItems = new List<UIBarButtonItem>();
                foreach (var item in originalToolbar.Items)
                {
                    newItems.Add(item);
                }

                newItems.Insert(0, clearButton);

                originalToolbar.Items = newItems.ToArray();
                originalToolbar.SetNeedsDisplay();
            }

        }
    }
}