using UnityEngine;
using System.Collections;
using Prime31;

public class comersScript : MonoBehaviour {


	public int counter;
	static bool isExist;


	bool flag;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	void Start () {
		if(isExist){
			Destroy(gameObject);
		}else{
			isExist = true;
		}
	}
}
//AdMobAndroid.requestInterstital( "ca-app-pub-4603016145025872/4275007740");

//var isReady = AdMobAndroid.isInterstitalReady();


//if(isReady){
	
//}

//	AdMobAndroid.displayInterstital();