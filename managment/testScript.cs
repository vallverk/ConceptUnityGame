using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour
{

	public int intpar;
	public string stpar;
	public bool click;
	public enum land
	{
		north,
		east,
		south,
		west
	}
	;
	//public int enem;
	public struct Horse
	{
		public int price;
		public float speed;
		public string name;
	}

	Horse heroHorse = new Horse();

	land territory; 

		void Start(){
		heroHorse.name = "plotwa";
		territory = land.north;
		StartCoroutine("Enemies");
		}
		
		void Update ()
		{	
				if (click) {
						print (heroHorse.name);
						landOperator ();
						lands ();
						click = false;
				}
		}
		

		
		void lands ()
		{
				switch (stpar) {

				case "myland":
				case "1":
						print ("Hello, sir!");
						break;
				case "enemyland":
				case "2":
						print ("You, boody bastard!");
						break;
				default:
						print ("unexplored lands, my lord!");
						break;
				}
		}
		
		void landOperator ()
		{
		if(territory == land.north){
			stpar = "myland";
		}
	
	
		}

		IEnumerator Enemies(){
		for(;;) {
			if(checkEnemies()){
				print ("enemyes near you, my lord!");

			}else{
				print ("all clear");
			}
			//yield return break;
			yield return new WaitForSeconds(5.1f);
		}
		}
		bool checkEnemies(){ 
		if(stpar == "enemyland"){
			return true;
		}else{
			return false;
		}
		}
}
