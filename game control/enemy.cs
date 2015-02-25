using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
		public float speed;
		public bool isAlive;
		public float size;
		public bool comboDeath;
		public mainManager manager;

		public missionLog logger;
		public bool rlDir;
		public bool isOwl;
		public bool isBat;
		public bool isGhost;
		public bool isDog;
	
		
		public GameObject deathSoundBat;
		public GameObject deathSoundGhost;
		public GameObject ghostSound1;
		public GameObject ghostSound2;


		GameObject rope;
		GameObject soundClone;
		
		float startPos;
		float startPosY;
		bool deathFlag;
		
		bool ghostFlag;

		float ghostDelayTime;

		bool dogFlag;
		float dogTemp;

		int num;
		void Start ()
		{
		startPos = transform.position.x;
		startPosY = transform.position.y;
		isAlive = true;

		rope = transform.Find("rope").gameObject;

		if(manager == null){
			manager = GameObject.Find("Manager").GetComponent<mainManager>();
		
		}

		if(transform.rotation.eulerAngles.y == 0){
			rlDir = true;
			//print ("track");
		}

		if(isGhost){
			num = 2;
			if(manager.soundOn){
				int selSound = 0;
				selSound = Random.Range(0,2);
				if(selSound == 0){
				if(ghostSound1!=null){
						soundClone = Instantiate (ghostSound1, transform.position, transform.rotation) as GameObject;
						soundClone.transform.parent = transform;
					}
				}else{
					if(ghostSound2!=null){
						soundClone = Instantiate (ghostSound2, transform.position, transform.rotation) as GameObject;
						soundClone.transform.parent = transform;
					}
				}
			}
		

			if(startPos<0){
				Transform coreGO = null;
				coreGO = transform.parent.parent;

				coreGO.rotation = Quaternion.Euler (new Vector3(0,0,0));
				speed = -speed;
			
			}
		
		}

		if(isDog){
			num = 3;

			//transform.rotation = Quaternion.Euler (new Vector3(0,0,0));
			Transform coreGO = null;
			coreGO = transform.parent.parent;
			
			coreGO.rotation = Quaternion.Euler (new Vector3(0,0,0));

		

			speed = speed *5;
			if(startPos<0){
				transform.rotation = Quaternion.Euler (new Vector3(0,180,0));
				dogFlag=true;
			}

			dogTemp = speed;
		}

		if(isBat){
			num = 0;
		
		}
		if(isOwl){
			speed = speed * 0.75f;
			num = 1;
		
		}

		}
	
		void Update ()
		{
				if (isAlive) {
			if(manager!=null){
			if(!manager.isPaused){
					if(!isDog){

						transform.Translate (Vector3.left * speed * Time.deltaTime);
					}else{

						transform.Translate (Vector3.left * speed * Time.deltaTime);
						if(startPos > 0){
						if(!dogFlag){
								if(transform.position.x < -11){
									transform.rotation = Quaternion.Euler (new Vector3(0,180,6));

									startPos = -10;
									dogFlag = true;
								}
							}
						}else{
							if(dogFlag){
								
								if(transform.position.x > 11){
								transform.rotation = Quaternion.Euler (new Vector3(0,0,6));
								startPos = 10;
								dogFlag = false;
								}
							}
						
						}
					}
			}
			}else{
				transform.Translate (Vector3.left * speed * Time.deltaTime);
			}
						
			if(!isDog){
			if (startPos > 0) {
								if (transform.position.x < -13) {
						--manager.enemiesCounter;
										manager.isDefeat = true;
										Destroy (gameObject);
								}
						} else {
								if (transform.position.x > 13) {
						--manager.enemiesCounter;
										Destroy (gameObject);
										manager.isDefeat = true;
								}
						}
			}
				
		
			if(isGhost){
				if (startPos > 0) {
				if(transform.position.x<4){


						if(!ghostFlag){
							transform.parent.animation.Play();
							ghostFlag = true;
							speed = 0;
							ghostDelayTime = Time.time;
						
						}
					}
				}else{
					if(transform.position.x>-4){
						if(!ghostFlag){

						transform.parent.animation.Play();
						speed = 0;
						ghostFlag = true;
						ghostDelayTime = Time.time;
						}
					}
				
				}
			if(ghostFlag){
				if(Time.time> ghostDelayTime + 5.5f){
						if(!manager.ghostAttak){
							if(!manager.isDefeat){
						manager.ghostAttak = true;
						manager.isDefeat = true;
						gameObject.GetComponent<batClawDeath>().attack = true;
							}
						}
					}
				
				}
			}

		
		} else {
					if(!deathFlag){
						Death ();
						deathFlag = true;
					}
				}

	
	if(isDog){



			speed = dogTemp + (startPosY-transform.position.y) ;
		
		}
	
	}
		void Death ()
		{
				gameObject.GetComponent<Animator> ().SetBool ("isDeath", true);
				rope.transform.parent = null;
				rope.GetComponent<rope>().isEnd = true;
				rigidbody2D.isKinematic = false;
				
			if(logger!=null){
			setToMissionLog();
		}
				if(isBat){
				if(manager.soundOn){
				if(deathSoundBat!=null){
			
					Instantiate(deathSoundBat, transform.position, transform.rotation);
				}
				}
				}
				if(isGhost){
				if(manager.soundOn){
				if(soundClone!=null){
					Destroy (soundClone);
				}
				if(deathSoundGhost!=null){
					Instantiate(deathSoundGhost, transform.position, transform.rotation);
				}
				}
				}
		if(isGhost){
			transform.parent.animation.Stop("ghostMove1");
		
		}
		if (isDog){
			transform.parent.animation.Stop("jump");
		
		}
		}
		void OnTriggerEnter2D (Collider2D trigger)
		{	
				if (trigger.gameObject.name == "dBarrier") {
			--manager.enemiesCounter;
			Destroy (gameObject);

				}

				if (comboDeath) {
						if (trigger.gameObject.tag == "enemy") {
								if (!isAlive) {
										trigger.gameObject.GetComponent<enemy> ().isAlive = false;
								}
						}
				}


		if(isDog){
			if(isAlive){
		if(trigger.gameObject.name == "dogCollider"){
				//print ("catch");

				if(!manager.ghostAttak){
					if(!manager.isDefeat){
					manager.ghostAttak = true;
					manager.isDefeat = true;
					gameObject.GetComponent<batClawDeath>().attack = true;
					}
				}
			}
		}


		}
		}

		void setToMissionLog(){
		switch (num)
		{
		case 0:

			//print ("track");
			if(logger!=null){
				++logger.monsterLog[0];
				++logger.monsterLog[4];
				++manager.gameObject.GetComponent<scoreCollector>().monstro[0];
//				print ("track");
			}
			
			break;
			
		case 1:
			if(logger!=null){
				++logger.monsterLog[1];
				++logger.monsterLog[4];
				++manager.gameObject.GetComponent<scoreCollector>().monstro[1];
			}
			
			break;
			
		case 2:
			if(logger!=null){
				++logger.monsterLog[2];
				++logger.monsterLog[4];
				++manager.gameObject.GetComponent<scoreCollector>().monstro[2];
			}
			
			break;
			
		case 3:
			if(logger!=null){
				++logger.monsterLog[3];
				++logger.monsterLog[4];
				++manager.gameObject.GetComponent<scoreCollector>().monstro[3];
			}
			
			break;
			
		}
		}

}
