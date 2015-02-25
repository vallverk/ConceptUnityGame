using UnityEngine;
using System.Collections;

public class missionShell : MonoBehaviour {

	public int number;

	UILabel label;
	UISprite check;
	missionLog loger;


	public int missionType;

	public int[] missionCondition; 

	public bool isActive;

	public Transform[] pos;

	public int missionSteep;
	int currentMissionCondition;
	bool currentMissionCheck;



	bool clicker;

	string[,] missionText = new string[,]{  
		{"Shoot 5 bats","Shoot 25 bats","Shoot 100 bats","Shoot 500 bats","Shoot 1000 bats"},
		{"Shoot 5 owls","Shoot 25 owls","Shoot 100 owls","Shoot 500 owls","Shoot 1000 owls"}, 
		{"Shoot 5 ghosts","Shoot 25 ghosts","Shoot 100 ghosts","Shoot 500 ghosts","Shoot 1000 ghosts"}, 
		{"Shoot 5 dogs","Shoot 25 dogs","Shoot 100 dogs","Shoot 500 dogs","Shoot 1000 dogs"},
		{"Shoot 5 monsters","Shoot 25 monsters","Shoot 100 monsters","Shoot 500 monsters","Shoot 1000 monsters"}
	};




	void Start () {
		label = transform.Find ("missionText").gameObject.GetComponent<UILabel>();
		check = transform.Find ("check").gameObject.GetComponent<UISprite>();
		loger = GameObject.Find("missionCollector").GetComponent<missionLog>();
		
		setProperties();
		if(PlayerPrefs.HasKey("mission_steep"+gameObject.name)){
		
			missionSteep = PlayerPrefs.GetInt("mission_steep"+gameObject.name);
			setProperties();
		}
	}
	
	void Update () {
		if(currentMissionCondition <= loger.monsterLog[missionType]){
		
			currentMissionCheck = true;


		}


		if(currentMissionCheck){
			++missionSteep;
			if(missionSteep<5){
			currentMissionCondition = missionCondition[missionSteep];
			}else{
//				currentMissionCondition = missionCondition[missionSteep-1];
				currentMissionCondition = missionCondition[4];
			
			}
			animation.Play();
			clicker = true; 
			currentMissionCheck = false;
			check.spriteName = "check_a";
		}else{
		

		
		
		}

		if(clicker){
			if(!animation.isPlaying){
				setProperties();
				check.spriteName = "check_na";

				PlayerPrefs.SetInt(("mission_steep"+gameObject.name), missionSteep);

//				print ("track");
				clicker = false;
			}
		}

	}

	void setProperties(){
		currentMissionCondition = missionCondition[missionSteep];
		label.text = missionText[missionType,missionSteep];
	}
}
