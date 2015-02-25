using UnityEngine;
using System.Collections;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;




public class googleAchiv : MonoBehaviour {

	public missionLog loger;


	bool notCompare;

	//bool getAchiv;
	void Start () {
		GooglePlayGames.PlayGamesPlatform.Activate();
		loger = gameObject.GetComponent<missionLog>();
		}
	void Update(){




		startAchiv ();
	}
	public void startAchiv (){
		if(!notCompare){
		Social.localUser.Authenticate((bool success) => {
			if(success){
					if(!notCompare){
					print ("track");

				if(loger.monsterLog[0]>=50){

				// bat kill1
				Social.ReportProgress("CgkIhuWe_eUGEAIQAQ", 100.0f, (bool success2) => {
				});
				}


				if(loger.monsterLog[0]>=250){

				//bat kill2
				Social.ReportProgress("CgkIhuWe_eUGEAIQCQ", 100.0f, (bool success3) => {
				});
				}


				if(loger.monsterLog[1]>=25){
				// owl kill
				Social.ReportProgress("CgkIhuWe_eUGEAIQAg", 100.0f, (bool success4) => {
				});
				}

				if(loger.monsterLog[1]>=150){

				// owl kill 2
				Social.ReportProgress("CgkIhuWe_eUGEAIQCg", 100.0f, (bool success5) => {
				});
				}

				if(loger.monsterLog[2]>=20){
				// ghost kill
				Social.ReportProgress("CgkIhuWe_eUGEAIQAw", 100.0f, (bool success6) => {
				});
				}


				if(loger.monsterLog[2]>=100){

				//ghost kill 2
				Social.ReportProgress("CgkIhuWe_eUGEAIQCw", 100.0f, (bool success7) => {
				});
				}

				if(loger.monsterLog[2]>=250){

				// ghost kill 3
				Social.ReportProgress("CgkIhuWe_eUGEAIQDA", 100.0f, (bool success8) => {
				});
				}


				if(loger.monsterLog[3]>=10){

				// dog kill 1
				Social.ReportProgress("CgkIhuWe_eUGEAIQBA", 100.0f, (bool success9) => {
				});

				}

				if(loger.monsterLog[3]>=25){
				// dog kill 2
				Social.ReportProgress("CgkIhuWe_eUGEAIQDQ", 100.0f, (bool success10) => {
				});
				}

				if(loger.monsterLog[4]>=50){

				// monster kiill 1
				Social.ReportProgress("CgkIhuWe_eUGEAIQDg", 100.0f, (bool success11) => {
				});
				}

				if(loger.monsterLog[4]>=250){

				// monster kill 2
				Social.ReportProgress("CgkIhuWe_eUGEAIQBQ", 100.0f, (bool success12) => {
				});
				}

				if(loger.monsterLog[4]>=500){

				// monster killl 3
				Social.ReportProgress("CgkIhuWe_eUGEAIQDw", 100.0f, (bool success13) => {
				});
				}



				if(loger.monsterLog[5]>=1){
				// first blood
				Social.ReportProgress("CgkIhuWe_eUGEAIQCA", 100.0f, (bool success14) => {
				});
				}

				if(loger.monsterLog[5]>=100){

				// blood 2
				Social.ReportProgress("CgkIhuWe_eUGEAIQEA", 100.0f, (bool success15) => {
				});
				}

				if(loger.monsterLog[5]>=250){
				// blood 3
				Social.ReportProgress("CgkIhuWe_eUGEAIQEQ", 100.0f, (bool success16) => {
				});
				}

				if(loger.monsterLog[0]>=250&&loger.monsterLog[4]>=500&&loger.monsterLog[1]>=150&&loger.monsterLog[2]>=250&&loger.monsterLog[3]>=25){

				// krazy killer
				Social.ReportProgress("CgkIhuWe_eUGEAIQEg", 100.0f, (bool success17) => {
				});
				}





					}
			}else{

					notCompare = true;
//				print ("other");
			}
		});

		}
	}
	public void setbool(){
	//	getAchiv = true;
	}
}
