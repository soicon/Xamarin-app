using System;
using Mobile.Control;
using Xamarin.Forms;

namespace Mobile
{
    public class Checkbox : View
    {
        /// <summary>
        /// The checked state property.
        /// </summary>
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create("Checked",
                typeof(bool),
                typeof(Checkbox),
                false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);

#if DEBUG
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text",
                typeof(string),
                typeof(Checkbox),
                string.Empty,
                defaultBindingMode: BindingMode.TwoWay
                );
        public string Text
        {
            get
            {
                return (string)this.GetValue(TextProperty);
            }
            set
            {
                this.SetValue(TextProperty, value);
            }
        }

        //public static readonly BindableProperty LineBreakMode =
        //    BindableProperty.Create("LineBreakMode",
        //        typeof(string),
        //        typeof(Checkbox),
        //        string.Empty,
        //        defaultBindingMode: BindingMode.TwoWay
        //        );
        //public string BreakMode
        //{
        //    get
        //    {
        //        return (string)this.GetValue(LineBreakMode);
        //    }
        //    set
        //    {
        //        this.SetValue(LineBreakMode, value);
        //    }
        //}
        /// <summary>
        /// The checked state property.
        /// </summary>
        public static readonly BindableProperty TestProperty =
            BindableProperty.Create("Test",
                typeof(string),
                typeof(Checkbox),
                "Test", BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public string Test
        {
            get
            {
                return (string)GetValue(TestProperty);
            }

            set
            {
                SetValue(TestProperty, value);
            }
        }
#endif

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get
            {
                return (bool)GetValue(CheckedProperty);
            }

            set
            {
                if (this.Checked != value)
                {
                    SetValue(CheckedProperty, value);
                    if (CheckedChanged != null)
                        CheckedChanged.Invoke(this, new CheckedChangedEventArgs(value));
                }
            }
        }

        /// <summary>
        /// The checked changed event.
        /// </summary>
        public event EventHandler<CheckedChangedEventArgs> CheckedChanged;

        /// <summary>
        /// Called when [checked property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldvalue">if set to <c>true</c> [oldvalue].</param>
        /// <param name="newvalue">if set to <c>true</c> [newvalue].</param>
        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var checkBox = (Checkbox)bindable;
            checkBox.Checked = (bool)newvalue;
        }
    }
}
