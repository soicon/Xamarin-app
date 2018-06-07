using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.ComponentModel;
using Mobile;
using Mobile.Droid.Views.Customs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DropDownMenuView), typeof(DropDownMenuRender_Android))]
namespace Mobile.Droid.Views.Customs
{
    public class DropDownMenuRender_Android : ViewRenderer<DropDownMenuView, Android.Views.View>, Spinner.IOnItemSelectedListener
    {
        Spinner _nativeView;
        Spinner.IOnItemSelectedListener _itemSelected;
        DropDownMenuView _dropDownView;
        SpinnerAdapter _adapter;
        public DropDownMenuRender_Android(Context context) : base(context)
        {
            AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<DropDownMenuView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                _dropDownView = (DropDownMenuView)e.NewElement;

                if (Control == null)
                {
                    Android.Widget.RelativeLayout wraper = new Android.Widget.RelativeLayout(Android.App.Application.Context);
                    ContextThemeWrapper theme = new ContextThemeWrapper(Android.App.Application.Context, Mobile.Droid.Resource.Style.Base_Widget_AppCompat_TextView_SpinnerItem);
                    _nativeView = new Spinner(theme);
                    _nativeView.OnItemSelectedListener = this;
                    if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M)
                        _nativeView.SetBackgroundResource(Mobile.Droid.Resource.Drawable.abc_btn_borderless_material);
                    else
                        wraper.SetBackgroundResource(Mobile.Droid.Resource.Drawable.abc_btn_borderless_material);
                    _nativeView.LayoutParameters = new Android.Widget.RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    _dropDownView.SetItemSelection = (i) =>
                    {
                        _nativeView.SetSelection(i);
                    };

                    ImageView downIcon = new ImageView(Android.App.Application.Context);
                    var param = new Android.Widget.RelativeLayout.LayoutParams(20, 20);
                    param.AddRule(LayoutRules.AlignParentRight);
                    param.AddRule(LayoutRules.CenterInParent);
                    param.SetMargins(0, 0, 14, 0);
                    downIcon.LayoutParameters = param;
                    downIcon.SetImageResource(Mobile.Droid.Resource.Drawable.abc_ic_arrow_drop_right_black_24dp);

                    wraper.AddView(_nativeView);
                    wraper.AddView(downIcon);
                    SetNativeControl(wraper);
                }

                if (_dropDownView.ItemsSource != null)
                    SetApdater();
            }
        }

        private void SetApdater()
        {
            if (_dropDownView.ItemsSource != null)
            {
                //ArrayAdapter<String> adapter = new ArrayAdapter<String>(Android.App.Application.Context,
                //        Android.Resource.Layout.SimpleSpinnerItem, _dropDownView.ItemsSource);
                //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleListItemSingleChoice);
                if (_adapter == null)
                {
                    _adapter = new SpinnerAdapter(_dropDownView.ItemsSource);
                    _nativeView.Adapter = _adapter;
                }
                else
                    _adapter.SetData(_dropDownView.ItemsSource);
            }
        }

        class SpinnerAdapter : BaseAdapter
        {
            private List<string> _datas;
            public SpinnerAdapter(List<string> datas)
            {
                _datas = datas;
            }

            public override int Count
            {
                get
                {
                    return _datas != null ? _datas.Count : 0;
                }
            }

            public void SetData(List<string> datas)
            {
                _datas = datas;
                NotifyDataSetChanged();
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return _datas[position];
            }

            public override long GetItemId(int position)
            {
                return 0;
            }

            public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
            {
                var item = (Android.Views.View)Android.Views.View.Inflate(Android.App.Application.Context, Resource.Layout.support_simple_spinner_dropdown_item, null);
                TextView text = item.FindViewById<TextView>(Mobile.Droid.Resource.Id.action_bar_spinner);
                text.Text = _datas[position];
                if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.M)
                {
                    item.SetBackgroundResource(Mobile.Droid.Resource.Drawable.abc_btn_borderless_material);
                    item.FindViewById(Mobile.Droid.Resource.Id.line1).Visibility = ViewStates.Gone;
                }
                return item;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetApdater();
        }

        public void OnItemSelected(AdapterView parent, Android.Views.View view, int position, long id)
        {
            if (_dropDownView.ItemSelecetedEvent != null)
            {
                _dropDownView.ItemSelecetedEvent.Invoke(position);
            }
        }

        public void OnNothingSelected(AdapterView parent)
        {
            if (_dropDownView.ItemSelecetedEvent != null)
            {
                _dropDownView.ItemSelecetedEvent.Invoke(-1);
            }
        }
    }
}