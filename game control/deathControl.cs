using UnityEngine;
using System.Collections;

public class deathControl : MonoBehaviour {


	public GameObject curEnemy;
	public GameObject fireObj;
	public string deathPar;
 	public bool endDeath;
	public Transform neck;
	public GameObject playerHead;
	public GameObject swarm;

	float timeDelay;
	float lastTime;
	bool delay;

	mainManager manager;



	public GameObject deathSound1;
	public GameObject deathSound2;
	public GameObject deathSound3;
	public GameObject deathSound4;

	public GameObject deathSoundSwarm;

	bool startDeath;
	int randy;
	void Start () {
		manager = GameObject.Find("Manager").GetComponent<mainManager>();
	
	
	
	
	}
	void Update () {


		
		if(curEnemy==null){
			
			manager.findEnemy = true;
//			print ("look for enemy");
		}

		
		if(startDeath){
			//string temp = "death" + randy;
			if(randy == 1){
				if(!animation.IsPlaying("death1")){
					endDeath = true;
				//	print ("track");
					startDeath = false;
				}
			
			}
			if(randy == 2){
				if(!animation.IsPlaying("death2")){
					endDeath = true;
				//	print ("track");
					startDeath = false;
				}
				
			}

		}

		if(delay){
		if(Time.time>lastTime+timeDelay)
			{
				endDeath = true;
				delay = false;
			
			}
		
		
		}
	}
	public void deathFromFire(){
		animation.Play("death1");
		startDeath = true;
	}
	public void Death()
	{
		randy = Random.Range(1,7);

		deathPar = ""+randy;

		switch (deathPar){
		
		case "1":
			if(manager.soundOn){
				if(deathSound1!=null){
					Instantiate(deathSound3, transform.position, transform.rotation);
				}
			}
			animation.Play("death1");
			startDeath = true;
		break;
		
		case "2":
			if(manager.soundOn){
				if(deathSound2!=null){
					Instantiate(deathSound2, transform.position, transform.rotation);
				}
			}
			animation.Play("death2");
			//startDeath = true;
			delay = true;
			lastTime = Time.time;
			timeDelay = 6.7f;
		break;

		case "3":
			if(curEnemy!=null){
				if(manager.soundOn){
				if(deathSound3!=null){
						Instantiate(deathSound3, transform.position, transform.rotation);
				}
				}
				if(curEnemy.GetComponent<enemy>().rlDir){
			curEnemy.GetComponent<SpriteRenderer>().sortingOrder = 2;
			curEnemy.GetComponent<enemy>().enabled = false;
			curEnemy.GetComponent<batClawDeath>().player = playerHead;
			curEnemy.GetComponent<batClawDeath>().neck = neck;
			curEnemy.GetComponent<batClawDeath>().attack = true;
			//startDeath = true;
				delay = true;
				lastTime = Time.time;
				timeDelay = 2.5f;
			}else{
					Death();
				
				}
			}else{


			
					Death();
			
			}
		break;
		case "4":
			if(manager.soundOn){
				if(deathSound3!=null){
					Instantiate(deathSoundSwarm, transform.position, transform.rotation);
				}
			}
			swarm.GetComponent<swarmDeath>().enabled = true;
			delay = true;
			lastTime = Time.time;
			timeDelay = 2.8f;
		break;
		case "5":
			/*animation.Play("death3");
			delay = true;
			lastTime = Time.time;
			timeDelay = 2.5f;*/
			Death();

			break;

		case "6":
		

			animation.Play("death4");
			delay = true;
			lastTime = Time.time;
			timeDelay = 6f;
			break;
		}
	}
	public void ghostDeath(){
		delay = true;
		lastTime = Time.time;
		timeDelay = 2.5f;
	
	}

}
