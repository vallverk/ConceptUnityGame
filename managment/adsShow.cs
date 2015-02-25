using UnityEngine;
using System.Collections;
using Prime31;


public class adsShow : MonoBehaviour {


	public comersScript comers;
	UILabel counter;

	// Use this for initialization
	void Start () {
	//	counter = GameObject.Find("UI Root/counter").GetComponent<UILabel>();
		comers = GameObject.Find("comers").GetComponent<comersScript>();

		AdMobAndroid.requestInterstital( "ca-app-pub-4603016145025872/4275007740");

	}
	
	// Update is called once per frame
	void Update () {


//		counter.text = "" ;


		if(comers.counter>2){
			AdMobAndroid.displayInterstital();

			comers.counter = 0;
			
			
		}

		var isReady = AdMobAndroid.isInterstitalReady();
	if(isReady){
			//counter.text = "";
		}
	}
}
