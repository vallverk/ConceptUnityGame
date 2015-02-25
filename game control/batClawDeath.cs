using UnityEngine;
using System.Collections;

public class batClawDeath : MonoBehaviour {


	Vector3 dir;
	Vector3 playerPos = new Vector3(0, -7.5f, 0);
	Vector3 extPos = new Vector3(-10,6,0);
	bool isCatch;
	bool catchFlag;

	public bool attack;
	public GameObject blood;
	public GameObject player;
	public Transform neck;


	void Update(){
		if(attack){
		if(transform.position.y<=-6.75f){
			isCatch = true;
//			print ("track");
		
		}


		if(!isCatch){
		dir = playerPos - transform.position;
		transform.Translate (dir * 2 * Time.deltaTime);


		}else{
		dir = extPos - transform.position;

		if(!catchFlag){
				player.transform.parent = transform;
				//Instantiate(blood, neck.position, neck.rotation);
				blood.transform.position = neck.position;
				blood.GetComponent<ParticleSystem>().Play();
				catchFlag = true;
			}

		transform.Translate (dir * 2 * Time.deltaTime);
		}
	}
	}
}
