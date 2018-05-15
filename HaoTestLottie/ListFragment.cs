using System;
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
using Com.Airbnb.Lottie;

namespace HaoTestLottie
{
    public class ListFragment : BaseFragment
    {
        private RecyclerView recyclerView;
        private LottieAnimationView animationView1;
        private LottieAnimationView animationView2;
        private LottieAnimationView animationView3;
        private LottieAnimationView animationView4;
        private LottieAnimationView animationView5;
        public bool _isclick1 {get;set;}
        public bool _isclick2 {get;set;}
        public bool _isclick3 {get;set;}
        public bool _isclick4 {get;set;}
        public bool _isclick5 {get;set;}

        private readonly FileAdapter adapter = new FileAdapter();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_list, container, false);

            this.recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recycler_view);
            this.animationView1 = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view1);
            this.animationView2 = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view2);
            this.animationView3 = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view3);
            this.animationView4 = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view4);
            this.animationView5 = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view5);

            this.recyclerView.SetAdapter(adapter);
            adapter.ItemClick += Adapter_ItemClick;

            animationView1.Click += delegate
            {
                if (_isclick1)
                {
                    animationView1.PlayAnimation();
                    _isclick1 = false;
                }
                else
                {
                    animationView1.CancelAnimation();
                    _isclick1 = true;
                }
            };
            animationView2.Click += delegate
            {
                if (_isclick2)
                {
                    animationView2.PlayAnimation();
                    _isclick2 = false;
                }
                else
                {
                    animationView2.CancelAnimation();
                    _isclick2 = true;
                }
            };
            animationView3.Click += delegate
            {
                if (_isclick3)
                {
                    animationView3.PlayAnimation();
                    _isclick3 = false;
                }
                else
                {
                    animationView3.CancelAnimation();
                    _isclick3 = true;
                }
            };
            animationView4.Click += delegate
            {
                if (_isclick4)
                {
                    animationView4.PlayAnimation();
                    _isclick4 = false;
                }
                else
                {
                    animationView4.CancelAnimation();
                    _isclick4 = true;
                }
            };
            animationView5.Click += delegate
            {
                if (_isclick5)
                {
                    animationView5.PlayAnimation();
                    _isclick5 = false;
                }
                else
                {
                    animationView5.CancelAnimation();
                    _isclick5 = true;
                }
            };

            return view;

            
        }

        public override void OnStart()
        {
            base.OnStart();
            //this.animationView.Progress = 0f;
            //this.animationView.PlayAnimation();
        }

        public override void OnStop()
        {
            base.OnStop();
            //this.animationView.CancelAnimation();
        }

        void Adapter_ItemClick(object sender, string e)
        {
            if (FileAdapter.TagViewer.Equals(e))
            {
                //ShowFragment(new AnimationFragment());
            }
            else if (FileAdapter.TagTypography.Equals(e))
            {
                //this.StartActivity(new Intent(this.Context, typeof(FontActivity)));
            }
        }

        private void ShowFragment(Fragment fragment)
        {
            //FragmentManager.BeginTransaction()
            //               .AddToBackStack(null)
            //               .SetCustomAnimations(Resource.Animation.slide_in_right, Resource.Animation.hold, Resource.Animation.hold, Resource.Animation.slide_out_right)
            //               .Remove(this)
            //               .Replace(Resource.Id.content_2, fragment)
            //               .Commit();
        }
    }

    public class FileAdapter : RecyclerView.Adapter
    {
        public const string TagViewer = "viewer";
        public const string TagTypography = "typography";
        public const string TagAppIntro = "app_intro";

        public event EventHandler<string> ItemClick;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.view_holder_file, parent, false);
            return new StringViewHolder(view, OnClick);
            //return null;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {

            StringViewHolder vh = holder as StringViewHolder;

            switch (position)
            {
                case 0:
                    vh.Bind("Animation Viewer", TagViewer);
                    break;
                case 1:
                    vh.Bind("Animated Typography", TagTypography);
                    break;
                case 2:
                    vh.Bind("Animated App Tutorial", TagAppIntro);
                    break;
                default:
                    break;
            }
        }

        public override int ItemCount
        {
            get {
                return 2;
            }
        }

        private void OnClick(string tag)
        {
            if (ItemClick != null)
                ItemClick(this, tag);
        }
    }
}