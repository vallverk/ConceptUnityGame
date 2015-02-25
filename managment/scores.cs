using UnityEngine;
using System.Collections;

public class scores : MonoBehaviour {

	public UILabel[] title;
	public scoreCollector collector;
	mainManager manager;
	gameController controller;
	missionLog logger;
	int[] temp = new int[4];

	float timer;

	public UILabel score;
	public UILabel bestScore;

	public TextMesh num;

	bool once;
	void Start(){
		manager = GameObject.Find("Manager").GetComponent<mainManager>();
		controller = GameObject.Find("Manager").GetComponent<gameController>();
		if(GameObject.Find("missionCollector")!=null){
			logger = GameObject.Find("missionCollector").GetComponent<missionLog>();
		}
	}


	void Update () {
		if(manager.isDefeat){
			if(Time.time>timer){
				for (int i =0; i<4; i++){
					if(temp[i]!=collector.monstro[i]){
						++temp[i];
						title[i].text = ""+temp[i];
					}
				}
				timer = Time.time + 0.1f;
			}

			if(!once){
			score.text = ""+controller.enemiesCounter;
			if(logger!=null){
			bestScore.text = ""+logger.monsterLog[6];

			}else{
				bestScore.text = ""+controller.enemiesCounter;

			}
				if(logger!=null){
				if(controller.enemiesCounter>logger.monsterLog[6]){
					logger.monsterLog[6] = controller.enemiesCounter;
				}
				num.text = ""+logger.monsterLog[6];
				once = true;
				}
			}
		}
	}
}
