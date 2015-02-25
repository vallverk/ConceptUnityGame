using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameController : MonoBehaviour
{


		mainManager manager;
		guiManager uimanager;
		deathControl deathmanager;
		enemyGenerator generator;
		missionLog logger;
		public comersScript Comers;
		GameObject player;
		int levelTime;
		float lastTime;
		public slingshot sling;
		public slingOperator oper;
		public int enemiesCounter;
		int lastEnemies;
		public Animator characterHead;
		public bool shootMod;
		public Transform arrow;
		public Transform points;


		public Animator catAnimated;
		
		//
		Vector3 tapPos;
		Vector3 endTapPos;
		Vector3 startTapPos;

		//
		bool endFlag;
		bool deathFlag;
		bool startFlag;
		float rotator;
		float dist;
		public List<GameObject> breackSound = new List<GameObject> ();

		void Start ()
		{
				manager = gameObject.GetComponent<mainManager> ();
				uimanager = gameObject.GetComponent<guiManager> ();
				generator = gameObject.GetComponent<enemyGenerator> ();


				if (GameObject.Find ("missionCollector") != null) {
						logger = GameObject.Find ("missionCollector").GetComponent<missionLog> ();

				}
				if (Comers != null) {
				}
				Comers = GameObject.Find ("comers").GetComponent<comersScript> ();
				deathmanager = gameObject.transform.Find ("deathController").GetComponent<deathControl> ();
				levelTime = manager.levelTime;
				manager.isPaused = true;
				uimanager.startl ();

				NGUITools.SetActive (points.gameObject, false);
				
	
				
				if (GoogleAnalytics.instance) {
						GoogleAnalytics.instance.LogScreen ("Cat Game Menu");
				}
	
		}
	
		void Update ()
		{
				//внутриигровые штуки
				if (!manager.isDefeat && !manager.isPaused && !manager.isVictory) {
						generator.enemiesCounter = enemiesCounter;
						if (enemiesCounter > lastEnemies) {
								deathmanager.gameObject.animation.Play ("shake");


								lastEnemies = enemiesCounter;
						}
						if (!startFlag) {
								starter ();
								startFlag = true;
						}
						//время
						generator.generate = true;
						//стрельба 
						if (!shootMod) {
							/*	if (Input.GetButtonDown ("Fire1")) {
										if (Input.touchCount > 0) {
												tapPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 10));
												sling.openFire (tapPos, 0);
												oper.mover (tapPos);
												characterAnim ();
										} else {
												tapPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
												sling.openFire (tapPos, 0);
												oper.mover (tapPos);
										}


											



								}
								characterAnim ();
*/
		
							} else {
								if (Input.GetButtonDown ("Fire1")) {
										
										startTapPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
								}

								if (Input.GetButton ("Fire1")) {
										endTapPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
									
										//	if (endTapPos.x - startTapPos.x < -0.2 || endTapPos.y - startTapPos.y < -0.2) {
										dist = Vector3.Distance (endTapPos, startTapPos);
										if (dist > 0.3f) {
												NGUITools.SetActive (points.gameObject, true);
												tapPos = ((endTapPos - startTapPos) * -1);
												float angl;
												angl = Mathf.Atan2 (tapPos.x, tapPos.y) * Mathf.Rad2Deg;
						
												points.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, -angl));
						characterAnim (angl);
//						print (angl);

					//	characterHead.SetFloat("angle", angl);
												float dif = 0;
												//dif = ((endTapPos.x - startTapPos.x)+(endTapPos.y - startTapPos.y));
												//dif = dif *-1;
												//print (dif);
												dif = dist - 0.2f;
												if (dif < 0.9f) {
														points.localScale = new Vector3 (dif, dif, 0);
												} else {
														points.localScale = new Vector3 (0.9f, 0.9f, 0);
												}
										} else {
												NGUITools.SetActive (points.gameObject, false);
										}
				}
								if (Input.GetButtonUp ("Fire1")) {
										if (dist > 0.3f) {
												sling.openFire (tapPos, 1);
										}
										NGUITools.SetActive (points.gameObject, false);

				}
						}
				}
				//поражение
				if (manager.isDefeat) {
						if (!endFlag) {
								generator.generate = false;
								if (!manager.ghostAttak) {
										deathmanager.Death ();
								} else {
										deathmanager.ghostDeath ();
								}
								endFlag = true;
						}
						if (!deathFlag) {
								if (Input.GetButtonDown ("Fire1")) {
					if(logger!=null){
						++logger.monsterLog[5];
					}	
										foreach (GameObject sounder in breackSound) {
												Destroy (sounder, 1);
										}
					NGUITools.SetActive(uimanager.endPanel2, true);
					manager.endLevel = true;
										deathFlag = true;
								}
								if (deathmanager.endDeath) {
										++Comers.counter;
					NGUITools.SetActive(uimanager.endPanel2, true);
					manager.endLevel = true;
										deathFlag = true;
										if(logger!=null){
										++logger.monsterLog[5];
										}
										if (GoogleAnalytics.instance) {
												GoogleAnalytics.instance.LogScreen ("Cat End Game/Pause");
										}
								}

				if(!PlayerPrefs.HasKey("cat_score")){
				PlayerPrefs.SetInt("cat_score",enemiesCounter);
				}else if(PlayerPrefs.GetInt("cat_score")<enemiesCounter){
					PlayerPrefs.SetInt("cat_score",enemiesCounter);
				
				}
			}
				}
				//
				if (Input.GetKeyDown ("r")) {
						uimanager.restart ();
				}
				if (Input.GetKeyDown ("p")) {
						uimanager.paused ();
				}
				if (Input.GetKeyUp ("escape")) {
						//uimanager.ext ();
						if (!manager.isPaused) {
			
								uimanager.paused ();
						} else {
								//uimanager.ext ();
								uimanager.goToMenu ();
						}
				}
				uimanager.countEnemies ("" + enemiesCounter);
		}

	private float tempAngl;
	private float curAngl;
		void characterAnim (float anglus)
		{

		curAngl = Mathf.Lerp(anglus, tempAngl, Time.deltaTime * 5f);


			characterHead.SetFloat("angle", curAngl);


		}
	void starter ()
		{
				if (levelTime == 0) {
						levelTime = 60;
				}
				uimanager.levelTime ("" + levelTime);
		}
}

