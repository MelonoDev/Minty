using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivTargetAllAllies : MonoBehaviour {

	public bool ActivatedAlliesTarget = false;
	public string CurrentHeal = "None";

	void Awake(){
		gameObject.SetActive (false);
	}

	//Toggles between the existence of the All Targets
	public void Toggle(string Deselect) {
		if (Deselect == CurrentHeal){
			ActivatedAlliesTarget = false;
			gameObject.SetActive (ActivatedAlliesTarget);
			CurrentHeal = "None";
		} else {
			CurrentHeal = Deselect;
			if (CurrentHeal == "HealAllTargets") {				
				ActivatedAlliesTarget = true;
				gameObject.SetActive (ActivatedAlliesTarget);
			}
		}
	}

	public void RootToggle() {
		ActivatedAlliesTarget = false;
		gameObject.SetActive (ActivatedAlliesTarget);
		CurrentHeal = "None";
	}
}
