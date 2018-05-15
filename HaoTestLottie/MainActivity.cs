using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace HaoTestLottie
{
    [Activity(Label = "HaoTestLottie", MainLauncher = true, Icon = "@mipmap/ic_launcher")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetTheme(Resource.Style.AppTheme);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ListFragment fsliderImage = new ListFragment();
            // Insert the fragment by replacing any existing fragment
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.content_1, fsliderImage).Commit();
        }
    }
}

