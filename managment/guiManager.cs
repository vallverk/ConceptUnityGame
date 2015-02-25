using UnityEngine;
using System.Collections;

public class guiManager : MonoBehaviour
{


		public mainManager manager;
		public GameObject normalPanel;
		public GameObject pausePanel;
		public GameObject endPanel2;
		public UILabel timer;
		public UILabel enemiesCount;
		public GameObject startPanel;
		public Animation lPort;
		public Animation rPort;
		public Animation upPort;
		public Animation endPanel;

		public backgoundStarter starter;
		
		bool animFlag;
		bool animFlag2;
		bool animFlag3;
		bool animFlagEnd;

		void Start(){
		NGUITools.SetActive(pausePanel, false);
		NGUITools.SetActive(endPanel2, false);
		}

		void Update(){
			if(animFlag){
			if(!upPort.IsPlaying("upPort")&&!lPort.IsPlaying("lPortBack")){
			Application.LoadLevel(0);
			}
			}
			if(animFlag2){
			if(!endPanel.IsPlaying("endGameLevelBack")){
			Application.LoadLevel (Application.loadedLevel);
			}
			}
			if(animFlag3){
			if(!pausePanel.animation.IsPlaying("pausedGoUp")){
		
				Application.LoadLevel (Application.loadedLevel);
			}
			}

		if(animFlagEnd){
			if(!lPort.IsPlaying("lPortBack")){
				Application.LoadLevel (Application.loadedLevel);
			
			
			}
		
		}

		}
		public void levelTime (string timeLast)
		{
			//	timer.text = timeLast;
		}

		

		public void countEnemies (string text)
		{
				enemiesCount.text = text;
		}

		public void ext ()
		{
				Application.Quit ();
		}

		public void startl ()
		{
				startLevel ();
				manager.isPaused = false;
		}

		public void startLevel ()
		{
				lPort.Play ("lPort");
				rPort.Play ("rPort");
				upPort.Play ("upPort");
				starter.starter();
		}

		public void portierBack ()
		{
				lPort.Play ("lPortBack");
				rPort.Play ("rPortBack");
				upPort.Play ("upPortBack");
		}

		public void menuDown()
		{
				endPanel.Play("endGameLevel");
		}
		public void paused(){
		if(!manager.isDefeat){
			bool tempPause = manager.isPaused;

			tempPause = !tempPause;
			
		if(tempPause){
				print ("paused");
				Time.timeScale = 0;
			NGUITools.SetActive(pausePanel, true);
			NGUITools.SetActive(normalPanel, false);
			// pausePanel.animation.Play("endGameLevel");
		//	pausePanel.animation.Play("pausedGoDown");
			//lPort.Play ("lPortBack");
			//rPort.Play ("rPortBack");
			//upPort.Play ("upPortBack");
			manager.isPaused = !manager.isPaused;
		}else{
				print ("unpaused");
				Time.timeScale = 1;
			NGUITools.SetActive(pausePanel, false);
			NGUITools.SetActive(normalPanel, true);
			//pausePanel.animation.Play("endGameLevelBack");
			//pausePanel.animation.Play("pausedGoUp");
			//lPort.Play ("lPort");
			//rPort.Play ("rPort");
			//upPort.Play ("upPort");
			manager.isPaused = !manager.isPaused;
		}

		}
 		}

		public void goToMenu()
		{		

				if(!manager.isPaused){
				if(!animFlag){
				upPort.Play("upPort");
				endPanel.Play("endGameLevelBack");
				animFlag = true;
				}
		}else{
			if(!animFlag){
				Time.timeScale = 1;
				NGUITools.SetActive(pausePanel.transform.Find("shape").gameObject, false);
				lPort.Play ("lPortBack");
				rPort.Play ("rPortBack");

			pausePanel.animation.Play("pausedGoUp");
				//upPort.Play("upPort");
				animFlag = true;
			}
		}
		}
		public void restart ()
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		public void restartFromEnd()
		{
			if(!animFlag2){
			endPanel.Play("endGameLevelBack");
			animFlag2 = true;
			}
	
		}

	public void restartFromEnd2()
	{
		if(!animFlagEnd){
		lPort.Play ("lPortBack");
		rPort.Play ("rPortBack");
		upPort.Play ("upPortBack");
		animFlagEnd = true; 
		}

	}


	public void extFromEnd2()
	{
		if(!animFlag){
			lPort.Play ("lPortBack");
			rPort.Play ("rPortBack");
			upPort.Play ("upPortBack");
			animFlag = true; 
		}
		
	}
	public void restartFromPause()
	{
		if(!animFlag3){
			Time.timeScale = 1;
			pausePanel.animation.Play("pausedGoUp");
			NGUITools.SetActive(pausePanel.transform.Find("shape").gameObject, false);
			animFlag3 = true;
			lPort.Play ("lPortBack");
			rPort.Play ("rPortBack");
			upPort.Play ("upPortBack");
		}
		
	}
	
	public void nLevel()
		{		
				Application.LoadLevel(Application.loadedLevel+1);
		}
	
}
