using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class missions : MonoBehaviour {
	public int[] circs;
	public string[] batQuest;
	public string[] owlQuest;
	public string[] ghostQuest;
	public string[] dogQuest;
	public string[] monsterQuest;


	public List<GameObject> taskObj = new List <GameObject>();

	public struct currentMission{
		public int missionNum;
		public bool setMission;
		public UILabel missionLabel;
		public UISprite check;
	}

	public currentMission Misiion1 = new currentMission();
	public currentMission Misiion2 = new currentMission();
	public currentMission Misiion3 = new currentMission();
	public currentMission Misiion4 = new currentMission();
	currentMission[] missionStack = new currentMission[4];
	missionLog logger ;



	float lastTimer;

	void Start(){

		logger = GameObject.Find("missionCollector").GetComponent<missionLog>();
	//	logger.saweLog();
		missionStack[0] = Misiion1;
		missionStack[1] = Misiion2;
		missionStack[2] = Misiion3;
		missionStack[3] = Misiion4;
		//missionStack[0].missionLabel = taskObj[0].GetComponent<UILabel>();
	//	questSelect();
	}


	public void questSelect(){
		for(int i=0; i<4; i++){
			missionStack[i].missionLabel = taskObj[i].GetComponent<UILabel>();
			missionStack[i].check =  taskObj[i].transform.Find("Sprite").GetComponent<UISprite>();

			selectQuestPanel();

			if(logger.monsterLog[num]>5){
				missionStack[i].check.spriteName = "check_a";
				missionStack[i].missionLabel.gameObject.animation.Play();


			}
			missionStack[i].missionLabel.text = texter;
		}
	}

	int num;


	string texter;

	int type;
	void selectQuestPanel(){
		num = Random.Range(0,5);
		switch (num)
		{
		case 0:
			type = 0;
			texter = batQuest[0];
			break;
		case 1:
			type = 1;
			texter = owlQuest[0];
			break;
		case 2:
			type = 2;
			texter = ghostQuest[0];
			break;
		case 3:
			type = 3;
			texter = dogQuest[0];
			break;
		case 4:
			type = 4;
			texter = monsterQuest[0];
			break;
		}
	}
}
