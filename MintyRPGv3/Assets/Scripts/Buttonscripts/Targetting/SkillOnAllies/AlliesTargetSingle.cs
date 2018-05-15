using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesTargetSingle : MonoBehaviour {

	void Update () {
		ActivTargetAllies AllOrSingle = gameObject.GetComponentInParent<ActivTargetAllies>();


		if (AllOrSingle.CurrentHeal != "HealAllTargets") {
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive (false);

		}
	}

}
