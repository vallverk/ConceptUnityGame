using UnityEngine;
using System.Collections;

public class swarmControl : MonoBehaviour {


	Vector3 dir;
	Vector3 playerPos;

	public Vector3 homePos;

	float speed;
	float downPos;

	Transform body;
	bool rSide;
	bool goBack;


	void Start () {

		body = transform.Find("body");
		if(transform.position.x>0){
			rSide= true;
		}
		if(!rSide){
			body.transform.rotation = Quaternion.Euler(new Vector3(0,-180,0));
		}
		downPos = Random.Range(-9f,-6.5f);

		playerPos = new Vector3(Random.Range(-1f, 1f),downPos,-4);
		speed = Random.Range(0.5f, 2);
	}
	void FixedUpdate () {
		if(!goBack){
		dir = playerPos - transform.position;
		transform.Translate (dir * speed * Time.fixedDeltaTime);
		}
		else {
		
			dir = homePos - transform.position;
			transform.Translate (dir * speed * Time.fixedDeltaTime);
		}

		if(transform.position.x<playerPos.x+0.2f&&transform.position.y<playerPos.y+0.2f){
			//print ("track");
			goBack = true;
		}
	}


	void  OnTriggerEnter2D(Collider2D other) {
		//characterInQuicksand = true;
		if(other.name == "swarmCollider"){
		//print ("enter");
		}
	}
}
