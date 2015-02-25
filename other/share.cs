using UnityEngine;
using System.Collections;

public class share : MonoBehaviour {





	public int counter;
	public GameObject sharegui;

	void Start () {
		NGUITools.SetActive(sharegui, false);
		if(!PlayerPrefs.HasKey("cat_entercounter")){
			PlayerPrefs.SetInt("cat_entercounter", 0);
			print ("track");
		}else{
			PlayerPrefs.SetInt("cat_entercounter", (PlayerPrefs.GetInt("cat_entercounter")+1));

			counter = PlayerPrefs.GetInt("cat_entercounter");

			print ("track2");
		}




		if(counter==2){
			shareAsk();
		}
	}
	void shareAsk(){

		NGUITools.SetActive(sharegui, true);

	}
}
