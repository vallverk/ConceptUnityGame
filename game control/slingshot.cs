using UnityEngine;
using System.Collections;

public class slingshot : MonoBehaviour
{

		public GameObject bullet;
		public float rotateSpeed;
		public float fireDelay;
		
		public GameObject shootSound;	
		float lastFire;
		mainManager manager; 
		gameController controller;
		//Vector3 tapPos;
		Transform generPos;

		void Start ()
		{
				generPos = transform.Find ("generPos");
				manager = GameObject.Find ("Manager").GetComponent<mainManager>();
				controller = GameObject.Find ("Manager").GetComponent<gameController>();
		}
	
		
		public void openFire(Vector3 tapPos, int shootMod)
		{
			

			if(shootMod == 0){
			rotateToTarget (tapPos);
			} else{
			rotateToTarget2 (tapPos);
			}
			if(tapPos.y>transform.position.y){
			if(Time.time>lastFire+fireDelay){
				bulletGenerate ();
				lastFire = Time.time;
			}
		}
		}
	
		void bulletGenerate ()
		{
				GameObject clone;
		if(manager.soundOn){
			if(shootSound!= null){
				Instantiate(shootSound,transform.position,transform.rotation);
			}
		}
				clone = Instantiate (bullet, generPos.position, transform.rotation) as GameObject;
				clone.GetComponent<bulletScript>().manager = manager;
				clone.GetComponent<bulletScript>().controller = controller;
		}

		void rotateToTarget (Vector3 tapPos)
		{
				Vector3 targetDir = new Vector3 (tapPos.x - transform.position.x, tapPos.y - transform.position.y, 0);
				float AngleRad = Mathf.Atan2 (targetDir.x, targetDir.y);
				float AngleDeg = (180 / Mathf.PI) * AngleRad;
				this.transform.rotation = Quaternion.Euler (0, 0, -AngleDeg);
		}
		public void rotateToTarget2(Vector3 tapPos){

				//this.transform.rotation = Quaternion.Euler(new Vector3 (tapPos.x - transform.position.x,0, tapPos.y - transform.position.x));
				float angl;
				angl = Mathf.Atan2(tapPos.x, tapPos.y) * Mathf.Rad2Deg;
				this.transform.rotation = Quaternion.Euler(new Vector3(0,0,-angl));

				
		}
}
