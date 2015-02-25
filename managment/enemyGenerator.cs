using UnityEngine;
using System.Collections;

public class enemyGenerator : MonoBehaviour
{

		public Transform generationPos;
		public GameObject[] enemy;
		public bool gener;
		public float delay;
		public float endDelay;
		public float pos;
		public bool generate;
		public int enemiesCounter;
		

		public Transform neck;
		public GameObject playerHead;
		
		float lastTime;
		float mode;
		int botAmount;
		mainManager manager;
		missionLog loger;
		deathControl deathcontroller;
		bool rl;
		void Start ()
		{
				manager = GameObject.Find ("Manager").GetComponent<mainManager> ();
				deathcontroller = GameObject.Find ("Manager/deathController").GetComponent<deathControl> ();


		if(GameObject.Find("missionCollector")!= null){
		
			loger = GameObject.Find("missionCollector").GetComponent<missionLog>();
		}
	
		}
		
		void Update ()
		{

		if(manager.findEnemy == true){


		//	int temp = Random.Range (0, 2);
			
		
		
		}

		if(!manager.isPaused&&!manager.isDefeat&&!manager.isVictory){
				if (generate) {
				if (Time.time > lastTime + delay||manager.enemiesCounter == 0) {


								manager.findEnemy = false;
								Generate (enemySelectBalance());
								if (delay > endDelay) {
										delay = delay - 0.1f;
								}
								gener = false;
								lastTime = Time.time;
								int temp = Random.Range (0, 2);

								if (temp == 1) {
										pos = -pos;
								}

								generationPos.position = new Vector3 (pos, Random.Range (-3.0F, 8.0F), generationPos.position.z);
								if (pos > 0) {
										generationPos.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
										
								} else {
										generationPos.rotation = Quaternion.Euler (new Vector3 (0, -180, 0));
										
								}
				}
				}

		}
	}

		void Generate (int enemyType)
		{
				GameObject clone;

				++manager.enemiesCounter;
				
				clone = Instantiate (enemy [enemyType], generationPos.position, generationPos.rotation) as GameObject;
		if(enemyType!=2&&enemyType!=3){
			if(enemyType == 1){
				clone.GetComponent<enemy> ().speed = Random.Range (2.5f, 5.7f);
			} else if(enemyType == 2){
				clone.GetComponent<enemy> ().speed = Random.Range (2f, 4f);
			
			}
				clone.GetComponent<enemy> ().manager = manager;

				clone.GetComponent<enemy> ().logger = loger;
				clone.GetComponent<batClawDeath> ().player = playerHead;
				clone.GetComponent<batClawDeath> ().neck = neck;
				deathcontroller.curEnemy = clone;


				}else if(enemyType == 2){
					clone.transform.Find("ghost/enemy3").gameObject.GetComponent<enemy> ().speed = Random.Range (1.5F, 3.0F);
					clone.transform.Find("ghost/enemy3").gameObject.GetComponent<enemy> ().manager = manager;
				clone.transform.Find("ghost/enemy3").gameObject.GetComponent<enemy> ().logger = loger;
					clone.transform.Find("ghost/enemy3").gameObject.GetComponent<batClawDeath> ().player = playerHead;
					clone.transform.Find("ghost/enemy3").gameObject.GetComponent<batClawDeath> ().neck = neck;
		
		}else if(enemyType == 3){
			clone.transform.Find("dogPivot/enemy4").gameObject.GetComponent<enemy> ().speed = Random.Range (1.5F, 3.0F);
			clone.transform.Find("dogPivot/enemy4").gameObject.GetComponent<enemy> ().manager = manager;
			clone.transform.Find("dogPivot/enemy4").gameObject.GetComponent<enemy> ().logger = loger;
			clone.transform.Find("dogPivot/enemy4").gameObject.GetComponent<batClawDeath> ().player = playerHead;
			clone.transform.Find("dogPivot/enemy4").gameObject.GetComponent<batClawDeath> ().neck = neck;
		}
				float randy = Random.Range (0.0F, 0.25F);
				clone.transform.localScale += new Vector3 (randy, randy, 0);
		}

		int enemySelect ()
		{
		//int steep;
		int curSteep = 2;
		int posibl = 1;
		int monster = 0;
		bool get = false;

		if(enemiesCounter<4){
			curSteep = 1;
		}else if (enemiesCounter>=4&&enemiesCounter<7){
			curSteep = 2;
		} else if(enemiesCounter>=7&&enemiesCounter<12){
			curSteep = 3;
		} else if(enemiesCounter>=12){
			curSteep = 4;
		}

		while(!get){
		monster = Random.Range (0,curSteep);
		if(monster>0){
		int curPos;
				curPos = Random.Range(0,2);

				if(posibl == curPos){
					get = true;
				
				}
		}else{
				get = true;
			
			}
		}
		return (monster);
		}


	int bats = 4;
	int owls = 3;
	int ghosts = 2;
	int dogs = 1;
	
	int clickerCount = 10;
	
	int curBat = 4;
	int curOwls = 3;
	int curGhosts = 2;
	int curDogs= 1;

	int enemySelectBalance (){


		int curSteep = 1;

		if(enemiesCounter<4){
			curSteep = 1;
		}else if (enemiesCounter>=3&&enemiesCounter<7){
			curSteep = 2;
		} else if(enemiesCounter>=7&&enemiesCounter<12){
			curSteep = 3;
		} else if(enemiesCounter>=12){
			curSteep = 4;
		}

		int monster = 0;
		int randomer = 0;
		//int curSteep = 2;
		bool findMonster = false;

	
		while(!findMonster){



			randomer = Random.Range (0,4);
//			print (randomer);
			if(randomer == 0){
				if(curBat>0){
					monster = 0;
					--curBat;
					--clickerCount;
					findMonster = true;
				}

			} else if(randomer == 1){
				if(curOwls>0){
				if(curSteep>1){
					monster = 1;
					}else{
						monster = 0;
						findMonster = true;
					}

				--curOwls;
				--clickerCount;
				findMonster = true;
				}
			} else if(randomer == 2){
				if(curGhosts>0){
					if(curSteep>2){
				monster = 2;
					}else{
						monster = 0;
						findMonster = true;
					}
				--curGhosts;
				--clickerCount;
				findMonster = true;
				}
			} else if(randomer == 3){
				if(curDogs>0){
					if(curSteep>3&&generationPos.position.x>-1){
				monster = 3;
					}else{
						monster = 0;
						findMonster = true;
					}
				--curDogs;
				--clickerCount;
				findMonster = true;
				}
			}

	
			if((curBat==0||curOwls==0||curGhosts==0||curDogs==0)&&clickerCount==0){
			
				curBat = bats;
				curOwls = owls;
				curDogs = dogs;
				curGhosts = ghosts;
				clickerCount = 10;


			//	print ("BANG____BANG_____BANG");
			}
		
		
		
		
		}
		
		return(monster);
	}
	
















}
