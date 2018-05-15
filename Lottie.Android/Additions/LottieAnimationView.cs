using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lottie.Android.Additions
{
    partial class LottieAnimationView
    {
        /// <summary>
        /// Delegate to handle the loading of bitmaps that are not packaged in the assets of your app.
        /// </summary>
        public void SetImageAssetDelegate(Func<LottieImageAsset, Bitmap> funcAssetLoad)
        {
            this.SetImageAssetDelegate(new ImageAssetDelegateImpl(funcAssetLoad));
        }

        internal sealed class ImageAssetDelegateImpl : Java.Lang.Object, IImageAssetDelegate
        {
            private readonly Func<LottieImageAsset, Bitmap> funcAssetLoad;

            public ImageAssetDelegateImpl(Func<LottieImageAsset, Bitmap> funcAssetLoad)
            {
                this.funcAssetLoad = funcAssetLoad;
            }

            public Bitmap FetchBitmap(LottieImageAsset asset)
            {
                return this.funcAssetLoad(asset);
            }
        }
    }
}