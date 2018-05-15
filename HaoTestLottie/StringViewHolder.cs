﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace HaoTestLottie
{
    public class StringViewHolder : RecyclerView.ViewHolder
    {
        private TextView titleView;

        public StringViewHolder(View view, Action<string> listener) : base(view)
        {
            this.titleView = view.FindViewById<TextView>(Resource.Id.title);
            view.Click += (sender, e) => listener(((TextView)((ViewGroup)sender).GetChildAt(0)).Tag.ToString());
        }

        public void Bind(String title, String tag)
        {
            titleView.Text = title;
            titleView.Tag = tag;
        }
    }
}