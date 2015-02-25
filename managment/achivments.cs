using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class achivments : MonoBehaviour {


	missionLog loger;

	mainManager manager;
	public GameObject acivList;

	public List <GameObject> achivsObj = new List<GameObject>();

	string[,] missionText = new string[,]{  
		{"Shoot 5 bats","Shoot 25 bats","Shoot 100 bats","Shoot 500 bats","Shoot 1000 bats"},
		{"Shoot 5 owls","Shoot 25 owls","Shoot 100 owls","Shoot 500 owls","Shoot 1000 owls"}, 
		{"Shoot 5 ghosts","Shoot 25 ghosts","Shoot 100 ghosts","Shoot 500 ghosts","Shoot 1000 ghosts"}, 
		{"Shoot 5 dogs","Shoot 25 dogs","Shoot 100 dogs","Shoot 500 dogs","Shoot 1000 dogs"},
		{"Shoot 5 mosnters","Shoot 25 mosnters","Shoot 100 mosnters","Shoot 500 mosnters","Shoot 1000 mosnters"},
		{"Die 5 times","Die 10 times","Die 50 times","Die 100 times"}
	};
	int[,] condition = new int[,]{
		{5,25,100,500,1000,9999999},{5,25,100,500,1000,9999999},{5,25,100,500,1000,9999999},{5,25,100,500,1000,9999999},{5,25,100,500,1000,9999999},{5,10,50,100,250,9999999}
	};
	int [] steep = new int[7];
	bool [] checker = new bool[7];
	bool achivFlag;
	bool[] animFlag = new bool[7];
	void Start () {
		manager = GameObject.Find("Manager").GetComponent<mainManager>();
		if(GameObject.Find("missionCollector")!=null){
		loger = GameObject.Find("missionCollector").GetComponent<missionLog>();
		}
		for (int b = 0; b <6; b++){
			NGUITools.SetActive(achivsObj[b], false);
		}
	
	
		for(int f = 0; f<6; f++){
		
			if(PlayerPrefs.HasKey("cat_steep_achiv"+f)){

				steep[f] = PlayerPrefs.GetInt("cat_steep_achiv"+f);

			}
		

		}
		StartCoroutine(achivCheck());
	
	}

	IEnumerator achivCheck(){
		for(;;) {
			if(achivFlag){
				if(manager.endLevel){
					for(int i = 0; i<6; i++){
						for (int a = 0; a<achivsObj.Count; a++){
							if(achivsObj[a].animation.isPlaying){
								animFlag[a] = true;
							} else{
								animFlag[a] = false;
							}
						}
						if(checker[i]){
							if(!animFlag[0]&&!animFlag[1]&&!animFlag[2]&&!animFlag[3]&&!animFlag[3]&&!animFlag[4]&&!animFlag[5]&&!animFlag[6]){
								NGUITools.SetActive(achivsObj[i], true);
								int temper = 0;
								if(steep[i]>0){
									temper = steep[i]-1;
								}else {
									temper = steep[i];
								}
								achivsObj[i].transform.Find("Label").GetComponent<UILabel>().text = missionText[i,temper];
							}
						}
					}
				}
			}
			if(GameObject.Find("missionCollector")!=null){
				for(int i = 0; i<5; i++){

				
					int curSteep = steep [i];


					int temp = condition[i,steep[i]];
					if(loger.monsterLog[i]>=temp){
						achivFlag = true;
						checker[i] = true;
						print (missionText[i,steep[i]]);
						++steep [i];
						PlayerPrefs.SetInt("cat_steep_achiv"+i, steep [i]);
						
						
					}
					}
				}



			yield return new WaitForSeconds(1f);

		}
	}

	void FixedUpdate () {

	}
}
