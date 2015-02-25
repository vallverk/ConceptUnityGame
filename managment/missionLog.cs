using UnityEngine;
using System.Collections;

public class missionLog : MonoBehaviour {

	public int[] monsterLog;
	int[] monsterLogBack = new int[7];


	static bool isExist;

	// 0 - bat
	// 2 - owl
	// 2 - ghost
	// 3 - dog
	// 4 - total monster
	// 5 - player die
	// 6 - score
	//
	//
	//
	public bool resetProgress;
	public bool[] isActive;

	bool level2Check;





	missions Mission;
	void Awake(){ 
		DontDestroyOnLoad(transform.gameObject);
	}


	// Use this for initialization
	void Start () {
		if(isExist){
			Destroy(gameObject);
		}else{
			isExist = true;
		}

		if(Application.loadedLevel == 0){
			if(GameObject.Find("missionsManager")!=null){
			Mission = GameObject.Find("missionsManager").GetComponent<missions>();
			}
		}


		monsterLog[0] = PlayerPrefs.GetInt("monsterlog_0");
		monsterLog[1] = PlayerPrefs.GetInt("monsterlog_1");
		monsterLog[2] = PlayerPrefs.GetInt("monsterlog_2");
		monsterLog[3] = PlayerPrefs.GetInt("monsterlog_3");
		monsterLog[4] = PlayerPrefs.GetInt("monsterlog_4");
		monsterLog[5] = PlayerPrefs.GetInt("monsterlog_5");
		monsterLog[6] = PlayerPrefs.GetInt("monsterlog_6");

		for (int i = 0; i < monsterLog.Length; i++)
		{
			monsterLogBack[i] = monsterLog[i];
		}

		if(Application.loadedLevel == 0){
		if(Mission!=null){
			Mission.questSelect();
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

		if(!level2Check){
			if(Application.loadedLevel == 1){
			
			
				level2Check=true;
			}
		
		
		}




		if(resetProgress){
			resProg();

			PlayerPrefs.DeleteAll();
			resetProgress = false;
			
		}
//		bool temp = false;
		for (int i = 0; i < monsterLog.Length; i++)
		{
			if(monsterLogBack[i]!= monsterLog[i]){
				
				
				monsterLogBack[i] = monsterLog[i];

				PlayerPrefs.SetInt("monsterlog_" + i, monsterLog[i]);
			}
		}

	}

	public void saweLog(){

//		print ("track");

	//	PlayerPrefs.SetInt("monsterlog_0", monsterLog[0]);
	//	PlayerPrefs.SetInt("monsterlog_1", monsterLog[1]);
	//	PlayerPrefs.SetInt("monsterlog_2", monsterLog[2]);
	//	PlayerPrefs.SetInt("monsterlog_3", monsterLog[3]);
	//	PlayerPrefs.SetInt("monsterlog_4", monsterLog[4]);
	}


	void resProg(){

		for (int i = 0; i < monsterLog.Length; i++)
		{
			monsterLog[i] = 0;
		}
		saweLog();
	}





}
