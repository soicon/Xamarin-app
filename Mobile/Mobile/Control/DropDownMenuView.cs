using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mobile
{
    public class DropDownMenuView : View
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(List<string>), typeof(DropDownMenuView));
        public static readonly BindableProperty ItemSelecetedEventProperty = BindableProperty.Create("ItemSelecetedEvent", typeof(Action<int>), typeof(DropDownMenuView));
        public static readonly BindableProperty SetItemSelectionProperty = BindableProperty.Create("SetItemSelection", typeof(Action<int>), typeof(DropDownMenuView));

        public List<string> ItemsSource
        {
            get { return (List<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public Action<int> ItemSelecetedEvent
        {
            get { return (Action<int>)GetValue(ItemSelecetedEventProperty); }
            set { SetValue(ItemSelecetedEventProperty, value); }
        }
        public Action<int> SetItemSelection
        {
            get { return (Action<int>)GetValue(SetItemSelectionProperty); }
            set { SetValue(SetItemSelectionProperty, value); }
        }
    }
}
