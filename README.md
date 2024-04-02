# Facebook SDK QuickStart for .NET

## .NET ANdroid

### Preparation

1. Get AppId and ClientToken as per [the official Facebook guide](https://developers.facebook.com/docs/facebook-login/android/)

2. Create a resource file under `values` folder: `facebook_dev.xml`

```bash
cp facebook_dev_xml_template ./DotnetAndroid.FacebookQs/Resources/values/facebook_dev.xml
```

3. Replace `YOUR_APP_ID` and `YOUR_CLIENT_TOKEN` with yours

### Keyhash

__Note__ Follow [the official guide from Facebook](https://developers.facebook.com/docs/facebook-login/android/) for additional info

**MacOS**

```
keytool -list -v -keystore ~/Library/Developer/Xamarin/Keystore/androiddebugkey/androiddebugkey.keystore -alias androiddebugkey -storepass android -keypass android  | openssl sha1 -binary | openssl base64
```