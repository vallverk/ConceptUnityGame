using UnityEngine;
using System.Collections;

public class swarmDeath : MonoBehaviour {


	public Transform[] pos;
	public Transform[] bodyParts;
	public GameObject batPrefab;
	public GameObject bloodPrefab;

	float delay;
	int  amount;
	bool oneTime;

	bool partChek;

	int parts;
	int curPar = 0;
	void Start ()
	{
		amount = Random.Range(25,35);
		parts = bodyParts.Length;
	
	}
	void Update () {
		if(!oneTime){

//			audio.Play();
		for(int i = 0; i<amount; i++){
			int randy = Random.Range(0,9);
			

				GameObject swarmClone;
				swarmClone = Instantiate (batPrefab, pos[randy].position, pos[randy].rotation) as GameObject;
				swarmClone.GetComponent<swarmControl>().homePos = pos[randy].position;
	
		
		}
			oneTime = true;
		}

		if(partChek){
		
			partChek = false;
		}
	}

	void  OnTriggerEnter2D(Collider2D other) {

	/*	if(other.name == "swarmBat(Clone)"){
			//print ("bat");
			if(parts>0){
				bodyParts[curPar].parent = other.gameObject.transform;
				GameObject bloodClone;
				//bloodClone = Instantiate (bloodPrefab, bodyParts[curPar].position, bodyParts[curPar].rotation) as GameObject;

				parts--;
				curPar++;
			}
		}*/
	}
}
