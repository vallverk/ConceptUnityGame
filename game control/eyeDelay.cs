using UnityEngine;
using System.Collections;

public class eyeDelay : MonoBehaviour {



	float lastTime;
	float delay;
	bool flag;


	void Start () {
		lastTime = Time.time;
		delay = Random.Range(0.5f, 1.5f);
	}
	
	void Update () {
	if(Time.time>lastTime+delay){
			if(!animation.IsPlaying(animation.name)){
				animation.Play();
				lastTime = Time.time;
				delay = Random.Range(0.5f, 2.0f);
			}
		}
	}
}
