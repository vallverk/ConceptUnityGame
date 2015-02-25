using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour
{
		public mainManager manager;
		public gameController controller;
		public float speed;
		public bool isRotate;
		public bool invisibleForDeath;
		public float rotateSpeed;
		public bool ifPhis;
		public float impuls;

		public GameObject explode;
		public GameObject hitSound;
		
		Transform body;
		Vector3 rotator;
		

		float startPos;

		void Start ()
		{
				rotator = transform.rotation.eulerAngles;
				startPos = transform.position.x;


				if(ifPhis){
					rigidbody2D.AddForce(transform.up * impuls, ForceMode2D.Impulse);
				}
		}

		void Update ()
		{
				transform.Translate (Vector3.up * speed * Time.deltaTime);
				body = transform.Find ("body");
				
				body.localScale *= 0.992f;			
			

				if (isRotate) {
						rotator += new Vector3 (0, 0, rotateSpeed * Time.deltaTime);
						Quaternion temp = Quaternion.Euler (rotator);
						body.transform.rotation = temp;
				}
		}

		void OnTriggerEnter2D (Collider2D trigger)
		{		
				if (trigger.gameObject.tag == "enemy") {
						if (invisibleForDeath) {
								if (trigger.gameObject.GetComponent<enemy> ().isAlive) {
					if(manager.soundOn){
					if(hitSound!=null){
						
							Instantiate(hitSound,transform.position,transform.rotation);
						}
					
					
					}
								if(!trigger.gameObject.GetComponent<enemy> ().isOwl){
										trigger.gameObject.GetComponent<enemy> ().isAlive = false;
										if (controller != null) {
												++controller.enemiesCounter;
										}
										}else{
										trigger.gameObject.GetComponent<enemy> ().isOwl = false;
					
										}
										if(explode!=null){
										Instantiate(explode,transform.position,transform.rotation);
					
										}
										Destroy (gameObject);
								
				}
				}
				} else if (trigger.tag == "barrier") {
						if (manager != null) {
								manager.isDefeat = true;
						}
						Destroy (gameObject);
				}
		}
}
