using Android.Runtime;
using Com.Facebook;
using Com.Facebook.Appevents;

namespace Dotnet.Facebook.Android.QuickStart;

[Application]
public class QuickStartApp : Application
{
    public QuickStartApp(nint javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer)
    {

    }

    public override void OnCreate()
    { 
        base.OnCreate();

        FacebookSdk.SdkInitialize(this);
        AppEventsLogger.ActivateApp(this);
    }
}
