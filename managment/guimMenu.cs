using UnityEngine;
using System.Collections;


//using UnityEditor;



public class guimMenu : MonoBehaviour {

	public Animation portier;
	bool playFlag;


	public UILabel label;
	bool sounder = true;



	public GameObject volume_on;
	public GameObject volume_off;
	void Start(){


		if(PlayerPrefs.HasKey("cat_sound")){
		
			bool temp = false;



			if(PlayerPrefs.GetInt("cat_sound") == 1){
				AudioListener.volume = 0;
				temp = false;

				NGUITools.SetActive(volume_on, false);
				NGUITools.SetActive(volume_off, true);
			
			} else{
				AudioListener.volume = 1;
				temp = true;
			//	volume.spriteName = "sound_off";
				NGUITools.SetActive(volume_on, true);
				NGUITools.SetActive(volume_off, false);
			
			}

			sounder = temp;
		
		} else{
			AudioListener.volume = 1;
			//temp = true;
			//	volume.spriteName = "sound_off";
			NGUITools.SetActive(volume_on, true);
			NGUITools.SetActive(volume_off, false);
			
		}


		//PlayerSettings.statusBarHidden(true);


		if (GoogleAnalytics.instance){
			GoogleAnalytics.instance.LogScreen("Cat Main Menu");

		//	label.text = ("ANALITICS");
		
		
		}
	
	}
		
	void Update () {
	//	print (PlayerPrefs.GetInt("cat_sound"));
		if(playFlag){
			if(!portier.IsPlaying("mainClosePortier")){
				Application.LoadLevel(Application.loadedLevel+1);
			
			}
		
		}
		if (Input.GetKey ("escape")) {
			Application.Quit();
		
		}



	}


	public void Playz()
	{
		if(!playFlag){
		portier.Play("mainClosePortier");
		
		playFlag = true;
		
		}
	}


	public void soundSvichToOff (){
			AudioListener.volume = 0;
			PlayerPrefs.SetInt("cat_sound", 1);
	}
	
	public void soundSvichToOn (){
		AudioListener.volume = 1;
		PlayerPrefs.SetInt("cat_sound", 0);
	}


}
