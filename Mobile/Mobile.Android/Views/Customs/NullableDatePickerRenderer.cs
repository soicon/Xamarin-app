using Android.App;
using Android.Content;
using Android.Widget;
using System;
using System.ComponentModel;
using Mobile;
using Mobile.Droid.Views.Customs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NullableDatePicker), typeof(NullableDatePickerRenderer))]

namespace Mobile.Droid.Views.Customs
{
    public class NullableDatePickerRenderer : ViewRenderer<NullableDatePicker, EditText>
    {
        DatePickerDialog _dialog;
        public NullableDatePickerRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<NullableDatePicker> e)
        {
            base.OnElementChanged(e);

            this.SetNativeControl(new EditText(Context));
            if (Control == null || e.NewElement == null)
                return;

            this.Control.Click += OnPickerClick;
            this.Control.Text = Element.Date.ToString(Element.Format);
            this.Control.KeyListener = null;
            this.Control.FocusChange += OnPickerFocusChange;
            this.Control.Enabled = Element.IsEnabled;

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Xamarin.Forms.DatePicker.DateProperty.PropertyName || e.PropertyName == Xamarin.Forms.DatePicker.FormatProperty.PropertyName)
                SetDate(Element.Date);
        }

        void OnPickerFocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                ShowDatePicker();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                this.Control.Click -= OnPickerClick;
                this.Control.FocusChange -= OnPickerFocusChange;

                if (_dialog != null)
                {
                    _dialog.Hide();
                    _dialog.Dispose();
                    _dialog = null;
                }
            }

            base.Dispose(disposing);
        }

        void OnPickerClick(object sender, EventArgs e)
        {
            ShowDatePicker();
        }

        void SetDate(DateTime date)
        {
            this.Control.Text = date.ToString(Element.Format);
            Element.Date = date;
        }

        private void ShowDatePicker()
        {
            CreateDatePickerDialog(this.Element.Date.Year, this.Element.Date.Month - 1, this.Element.Date.Day);
            _dialog.Show();
        }

        void CreateDatePickerDialog(int year, int month, int day)
        {
            NullableDatePicker view = Element;
            _dialog = new DatePickerDialog(Context, (o, e) =>
            {
                view.Date = e.Date;
                ((IElementController)view).SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
                Control.ClearFocus();

                _dialog = null;
            }, year, month, day);

            _dialog.SetButton("Done", (sender, e) =>
            {
                SetDate(_dialog.DatePicker.DateTime);
                this.Element.Format = this.Element._originalFormat;
                this.Element.AssignValue();
            });
            _dialog.SetButton2("Clear", (sender, e) =>
            {
                this.Element.CleanDate();
                Control.Text = this.Element.Format;
            });
        }
    }
}