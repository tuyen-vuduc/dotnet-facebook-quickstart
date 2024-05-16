using Android.Content;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Com.Facebook;
using Com.Facebook.Login;
using Com.Facebook.Login.Widget;
using AlertDialog = AndroidX.AppCompat.App.AlertDialog;

namespace Dotnet.Facebook.Android.QuickStart;

[Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
public partial class MainActivity : AppCompatActivity
{
    private static readonly string EMAIL = "email";

    ICallbackManager callbackManager;
    LoginButton loginButton;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        callbackManager = ICallbackManager.Factory.Create();

        loginButton = FindViewById<LoginButton>(Resource.Id.login_button);
        loginButton.SetPermissions(EMAIL);

        LoginManager.Instance.RegisterCallback(callbackManager, this);
    }

    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent? data)
    {
        callbackManager.OnActivityResult(requestCode, requestCode, data);
        base.OnActivityResult(requestCode, resultCode, data);
    }
}

partial class MainActivity : IFacebookCallback
{
    public void OnCancel()
    {
        ShowAlert("Warning", "You cancelled the login.");
    }

    public void OnError(FacebookException error)
    {
        ShowAlert("Error", "Error: " + error.Message);
    }

    public void OnSuccess(Java.Lang.Object? result)
    {
        var loginResult = result as LoginResult;

        ShowAlert("Success", "DONE: " + loginResult.AccessToken);
    }

    private void ShowAlert(string title, string message)
    {
        RunOnUiThread(() => {
            AlertDialog dialog = new AlertDialog.Builder(this)
                .SetTitle(title)
                .SetMessage(message)
                .SetPositiveButton("Ok", (IDialogInterfaceOnClickListener)null)
                .Create();
            dialog.Show();
        });
    }

}