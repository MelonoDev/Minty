using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MintysTurnButtonsActivating : MonoBehaviour {

	//Have the attack/heal menu only appear when it's actually the player's turn.

	public GameObject MenuButtons;
	public TurnsStateMachine turnStateMachine;

	//Scripts to root toggle the buttons
	public ActivTargetAttack activTargetAttack;
	public ActivTargetHeal activeTargetHeal;
	public ActivTargetAllies activeTargetAllies;
	public ActivTargetAllAllies activeTargetAllAllies;

	void Start () {
		MenuButtons.SetActive (false);
	}
	
	void Update () {
		if (turnStateMachine.CurrentState == State.Ally3) {
			MenuButtons.SetActive (true);
		} else {
			
			MenuButtons.SetActive (false);
		}
	}
}
