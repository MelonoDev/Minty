using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivTargetEnemies : MonoBehaviour {

	public bool ActivatedEnemiesTarget = false;
	public string CurrentHeal = "None";

	void Awake(){
		gameObject.SetActive (false);
	}

	//Toggles between the existence of the Single Targets
	public void Toggle(string Deselect) {
		if (Deselect == CurrentHeal) {
			ActivatedEnemiesTarget = false;
			gameObject.SetActive (ActivatedEnemiesTarget);
			CurrentHeal = "None";
		} else {
			CurrentHeal = Deselect;
			if (CurrentHeal != "AttackAllTargets") {
				ActivatedEnemiesTarget = true;
				gameObject.SetActive (ActivatedEnemiesTarget);
			}
		}
	}

	public void RootToggle() {
		ActivatedEnemiesTarget = false;
		gameObject.SetActive (ActivatedEnemiesTarget);
		CurrentHeal = "None";
	}
}
