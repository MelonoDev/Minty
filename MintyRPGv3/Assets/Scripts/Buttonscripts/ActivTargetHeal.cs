using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivTargetHeal : MonoBehaviour {

	public bool ActivatedHeal;

	void Awake(){
		gameObject.SetActive (false);
	}

	public void Toggle() {
		ActivatedHeal = !ActivatedHeal;
		gameObject.SetActive (ActivatedHeal);
	} 
} 
