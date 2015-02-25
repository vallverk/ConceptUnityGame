using UnityEngine;
using System.Collections;

public class rope : MonoBehaviour {

	public bool isEnd;

		
	// Update is called once per frame
	void Update () {
	if(isEnd){

			transform.Translate (Vector3.up * 8 * Time.deltaTime);
			if(transform.position.y>20){
				Destroy (gameObject);
			
			}
		}
	}
}
