using UnityEngine;
using System.Collections;

public class soundPush : MonoBehaviour {


	gameController controller;


	void Start () {
		controller = GameObject.Find("Manager").GetComponent<gameController>();
	}
	
	// Update is called once per frame
	void Update () {
		controller.breackSound.Add(gameObject);
	}
}
