using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivTargetHeal : MonoBehaviour {

	public bool ActivatedAttackHeal = false;
	public string AttOrHeal = "None";

	void Awake(){
		gameObject.SetActive (false);
	}

	public void Toggle(string Deselect) {
		if (Deselect == AttOrHeal){
			ActivatedAttackHeal = false;
			gameObject.SetActive (ActivatedAttackHeal);
			AttOrHeal = "None";
		} else {
			AttOrHeal = Deselect;
			if (AttOrHeal == "HealingMove") {				
				ActivatedAttackHeal = true;
				gameObject.SetActive (ActivatedAttackHeal);
			}
		}
	}

	public void RootToggle() {
		ActivatedAttackHeal = false;
		gameObject.SetActive (ActivatedAttackHeal);
		AttOrHeal = "None";
	}
} 
