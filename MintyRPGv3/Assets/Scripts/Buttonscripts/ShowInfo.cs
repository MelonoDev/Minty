using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowInfo : MonoBehaviour {

	public BecomeSOCharacter MintySOC;
	public GameObject MintyObj;
	public GameObject InfoPanel;
	public Text InfoTextText;

	void Start(){
		MintyObj = GameObject.FindGameObjectWithTag ("Player");
		MintySOC = MintyObj.GetComponent<BecomeSOCharacter> ();
	}

	void Update () {
		if (OnHoverShowInfo.WhichButtonIsHovered != "None") {
			InfoPanel.SetActive (true);
		} else {
			InfoPanel.SetActive (false);
		}

		//Attacks Info
		if (OnHoverShowInfo.WhichButtonIsHovered == "AttackOverTime") {
			InfoTextText.text = "Poison an enemy, dealing 1 damage every turn.";
		}
		if (OnHoverShowInfo.WhichButtonIsHovered == "AttackSingleTarget") {
			InfoTextText.text = "Attack an enemy for " + MintySOC.soCharacter.CharacterAttack.ToString() + " damage.";
		}

		//Heals Info
		if (OnHoverShowInfo.WhichButtonIsHovered == "HealStatusEffect") {
			InfoTextText.text = "Remove an ally's bad status effects.";
		}
		if (OnHoverShowInfo.WhichButtonIsHovered == "HealAllTargets") {
			InfoTextText.text = "Heal all allies for " + MintySOC.soCharacter.CharacterHealAll.ToString() + " healthpoints.";
		}
		if (OnHoverShowInfo.WhichButtonIsHovered == "HealOverTime") {
			InfoTextText.text = "Regenerate an ally, healing 2 healthpoints every turn.";
		}
		if (OnHoverShowInfo.WhichButtonIsHovered == "HealSingleTarget") {
			InfoTextText.text = "Heal an ally for " + MintySOC.soCharacter.CharacterHeal.ToString() + " healthpoints.";
		}

	}
		
}
