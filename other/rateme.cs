using UnityEngine;
using System.Collections;

public class rateme : MonoBehaviour {


	missionLog loger;
	public GameObject rateMeLabel;


	mainManager manager;

	bool flag;

	// Use this for initialization
	void Start () {

		manager = GameObject.Find("Manager").GetComponent<mainManager>();
		if(GameObject.Find("missionCollector")!=null){
			loger = GameObject.Find("missionCollector").GetComponent<missionLog>();
		}

		if(rateMeLabel!=null){
			NGUITools.SetActive(rateMeLabel, false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	if(loger != null){
		
		if(!PlayerPrefs.HasKey("cat_rateflag")){
			if(loger.monsterLog[5]==2){
				if(!flag){

				print ("rateme");
				if(rateMeLabel!=null){
					NGUITools.SetActive(rateMeLabel, true);

						Time.timeScale = 0;
				}

						PlayerPrefs.SetInt("cat_rateflag",1);
					flag = true;
				}
			}

			}
		
		}
	}


	public void openurl (){
	
		Application.OpenURL("http://play.google.com/store/apps/details?id=com.knubisoft.shootingcats");
		if(rateMeLabel!=null){
			NGUITools.SetActive(rateMeLabel, false);
			Time.timeScale = 1;
		}
	}

	public void close(){
		if(rateMeLabel!=null){
			NGUITools.SetActive(rateMeLabel, false);
			Time.timeScale = 1;
		}
	
	}
}
