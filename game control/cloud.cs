using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour {

	public bool direct;


	void Update () {




		if(!direct){
			transform.Translate (Vector3.left * 1.5f * Time.deltaTime);
		if(transform.position.x<-10){
				transform.position = new Vector3 (10, transform.position.y, transform.position.z);
		}
		}else{
			transform.Translate (Vector3.right * 1.5f * Time.deltaTime);
			if(transform.position.x>10){
				transform.position =new Vector3 (-10, transform.position.y, transform.position.z);
			}
		
		
		}
	}
}
