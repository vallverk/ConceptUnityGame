using UnityEngine;
using System.Collections;

public class social : MonoBehaviour {


	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en"; 

	public void postToTwitter(){
	
		Application.OpenURL(TWITTER_ADDRESS +
		                    "?text=" + WWW.EscapeURL("I'm playing Shooting Cats Game! " +
		                    "" + "https://play.google.com/store/apps/details?id=com.knubisoft.shootingcats") +

		                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	
	}




	private const string FACEBOOK_APP_ID = "1788762361349231";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";


	public void postToFasebook(){


		//takescreen = true;

		string par1 = "https://play.google.com/store/apps/details?id=com.knubisoft.shootingcats";
		string par2 = "";
		string par3 = "";
		string par4 = "";
		string par5 = "http://habrastorage.org/files/a2b/10b/c2d/a2b10bc2d3194060906e2a7e38d01556.jpg";
		string par6 = "http://www.facebook.com/";

		ShareToFacebook(par1,par2,par3,par4,par5,par6);
	
	}

	
	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}


	private void TakeScreenshot()
	{
		var snap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		snap.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		snap.Apply();
		var screenshot = snap.EncodeToPNG();
		
		var wwwForm = new WWWForm();
		wwwForm.AddBinaryData("image", screenshot, "barcrawling.png");
		
	//	FB.API("me/photos", HttpMethod.POST, LogCallback, wwwForm);
	}

	/// dev Eg: samplepass   ga0RGNYHvNM5d0SLGQfpQWAPGJ8=
	/// relese Eg: 'zY00cczs2SG28RTn1bZQvsCftvI=
	/// 
	/// zY00cczs2SG28RTn1bZQvsCftvI=
	/// 
	/// 
	/// 

}
