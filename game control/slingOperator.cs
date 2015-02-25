using UnityEngine;
using System.Collections;

public class slingOperator : MonoBehaviour {

	public float maxPos;
	float pos;

	float tragetPos;
	public void mover(Vector3 tapPos){
		if (tapPos.x>0){
			pos = maxPos*(tapPos.x/8);
		}else if(tapPos.x<0){
			pos = maxPos*(tapPos.x/8);
			
		}
		transform.position = new Vector3(pos, transform.position.y, transform.position.z);


	}

}
