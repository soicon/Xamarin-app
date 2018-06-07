﻿using Xamarin.Forms;

namespace Mobile
{
    public class HtmlLabel : Label
    {
        /// <summary>
        /// Backing store for the MaxLines bindable property
        /// </summary>
        public static readonly BindableProperty MaxLinesProperty =
            BindableProperty.CreateAttached("MaxLines", typeof(int), typeof(HtmlLabel), default(int));

        public static int GetMaxLines(BindableObject view)
        {
            if (view == null) return default(int);
            return (int)view.GetValue(MaxLinesProperty);
        }

        public static void SetMaxLines(BindableObject view, int value)
        {
            view?.SetValue(MaxLinesProperty, value);
        }

        /// <summary>
        /// Backing store for the IsHtml bindable property
        /// </summary>
        public static readonly BindableProperty IsHtmlProperty =
            BindableProperty.CreateAttached("IsHtml", typeof(bool), typeof(HtmlLabel), true);

        public static bool GetIsHtml(BindableObject view)
        {
            if (view == null) return default(bool);
            return (bool)view.GetValue(IsHtmlProperty);
        }

        public static void SetIsHtml(BindableObject view, bool value)
        {
            view?.SetValue(IsHtmlProperty, value);
        }

        /// <summary>
        /// Backing store for the RemoveHtmlTags bindable property
        /// </summary>
        public static readonly BindableProperty RemoveHtmlTagsProperty =
            BindableProperty.CreateAttached("RemoveHtmlTags", typeof(bool), typeof(HtmlLabel), default(bool));

        public static bool GetRemoveHtmlTags(BindableObject view)
        {
            if (view == null) return default(bool);
            return (bool)view.GetValue(RemoveHtmlTagsProperty);
        }

        public static void SetRemoveHtmlTags(BindableObject view, bool value)
        {
            view?.SetValue(IsHtmlProperty, RemoveHtmlTagsProperty);
        }
    }
}
