using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesTargetAll : MonoBehaviour {

	void Update () {
		ActivTargetAllies AllOrSingle = gameObject.GetComponentInParent<ActivTargetAllies>();

		if ((AllOrSingle.CurrentHeal != "HealAllTargets") && (AllOrSingle.ActivatedAlliesTarget)) { 
			gameObject.SetActive (false);
		} else {
			gameObject.SetActive (true);
//			print ("HEEEY");
		}
	}

}
