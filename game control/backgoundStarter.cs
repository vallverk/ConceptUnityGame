using UnityEngine;
using System.Collections;

public class backgoundStarter : MonoBehaviour {

	public Animation[] animationlist;
	void Start (){
		starter();
	
	}

	public void starter(){
	 foreach (Animation anim in animationlist){
			anim.Play();
		
		}
	
	
	}
}
