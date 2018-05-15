using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivTargetAttack : MonoBehaviour {

	public bool ActivatedAttack;


	void Awake(){
		gameObject.SetActive (false);
	}

	public void Toggle() {
		ActivatedAttack = !ActivatedAttack;
		gameObject.SetActive (ActivatedAttack);
	}
}
