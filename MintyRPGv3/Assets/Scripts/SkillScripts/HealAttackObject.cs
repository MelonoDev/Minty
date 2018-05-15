﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAttackObject : MonoBehaviour {

	public GameObject SkillHealSingleTarget;

	//General targets for referencing which skill is to be used
	public GameObject targetAllies;
	public ActivTargetAllies activTargetAllies;

	//characters as object and their values
	public SOCharacter SOAlly1;
	public SOCharacter SOAlly2;
	public SOCharacter SOAlly3;

	public SOCharacter SOEnemy1;
	public SOCharacter SOEnemy2;
	public SOCharacter SOEnemy3;

	//HPbar to update
	public SimpleHealthBar HPBAlly3;
	public SimpleHealthBar HPBAlly2;
	public SimpleHealthBar HPBAlly1;

	public SimpleHealthBar HPBEnemy3;
	public SimpleHealthBar HPBEnemy2;
	public SimpleHealthBar HPBEnemy1;

	//Extra turn numbers so you only target those alive
	private int ExtraTurnDeadAlly = 0; //for Enemies to attack allies
	private int ExtraTurnDeadEnemy = 0; //for Allies to attack enemies

	//SKILLS amounts
	private int healAmount = 1;
	private int poisonAmount = 1;
	private int regenAmount = 2;

	//ref SKILLS amounts
	public SOCharacter allyMinty;

	public TurnsStateMachine turnsStateMachine;
	 
	// Use this for initialization
	void Awake () {
		healAmount = allyMinty.CharacterHeal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HealSingleAlly (string TargetPos){ //TargetPos gaat over de positie. Die verwijst naar CharaObject

		activTargetAllies = targetAllies.GetComponent<ActivTargetAllies> ();

		if (activTargetAllies.CurrentHeal == "HealSingleTarget"){
			healSingleTarget (TargetPos);
		}


	}

	public void HealAllAlly (){

	}

	public void AttackSingleEnemy (string TargetPos){

	}
		
	//Attacks
	public void healSingleTarget (string Trgt){

		if (Trgt == "Minty") {
			SOAlly3.CharacterCurrentHP += healAmount;
			allyMinty.IsHealing = true;
			UpdateHPBarAlly3 ();
		}
		if (Trgt == "YoungBro") {
			SOAlly2.CharacterCurrentHP += healAmount;
			allyMinty.IsHealing = true;
			UpdateHPBarAlly2 ();

		}
		if (Trgt == "OldBro") {
			SOAlly1.CharacterCurrentHP += healAmount;
			allyMinty.IsHealing = true;
			UpdateHPBarAlly1 ();

		}


	}


	public void EnemyAttack (int WhichEnemy){
	
		PlusTurnDeadAlly ();

		if (WhichEnemy == 1) {
			SOEnemy1.IsAttacking = true;
		} else if (WhichEnemy == 2) {
			SOEnemy2.IsAttacking = true;
		} else if (WhichEnemy == 3) {
			SOEnemy3.IsAttacking = true;
		} 

		Debug.Log (turnsStateMachine.TurnAmount);

		if ((WhichEnemy == 1) && (SOEnemy1.CharacterAlive)) {
			if ((turnsStateMachine.TurnAmount) % 3 == 1) { //Enemy attacks every turn someone else, and only different targets.
				Debug.Log ("Ally1Attacked");
			}
			if ((turnsStateMachine.TurnAmount) % 3 == 2) {
				Debug.Log ("Ally2Attacked");
			}
			if ((turnsStateMachine.TurnAmount) % 3 == 0) {
				Debug.Log ("Ally3Attacked");
			}
		}

	}


	public void PoisonTurnEnemies(){
		if (SOEnemy1.CharacterPoisoned == true) {
			SOEnemy1.CharacterCurrentHP -= poisonAmount;
			UpdateHPBarEnemy1 ();

		}
		if (SOEnemy2.CharacterPoisoned == true) {
			SOEnemy2.CharacterCurrentHP -= poisonAmount;
			UpdateHPBarEnemy2 ();

		}
		if (SOEnemy3.CharacterPoisoned == true) {
			SOEnemy3.CharacterCurrentHP -= poisonAmount;
			UpdateHPBarEnemy3 ();

		}
	}


	public void RegenTurnEnemies(){
		if (SOEnemy1.CharacterRegen == true) {
			SOEnemy1.CharacterCurrentHP += regenAmount;
			UpdateHPBarEnemy1 ();

		}
		if (SOEnemy2.CharacterRegen == true) {
			SOEnemy2.CharacterCurrentHP += regenAmount;
			UpdateHPBarEnemy2 ();

		}		
		if (SOEnemy3.CharacterRegen == true) {
			SOEnemy3.CharacterCurrentHP += regenAmount;
			UpdateHPBarEnemy3 ();

		}
	}


	public void PoisonTurnAllies(){
		if (SOAlly1.CharacterPoisoned == true) {
			SOAlly1.CharacterCurrentHP -= poisonAmount;
			UpdateHPBarAlly1 ();

		}
		if (SOAlly2.CharacterPoisoned == true) {
			SOAlly2.CharacterCurrentHP -= poisonAmount;
			UpdateHPBarAlly2 ();

		}
		if (SOAlly3.CharacterPoisoned == true) {
			SOAlly3.CharacterCurrentHP -= poisonAmount;
			UpdateHPBarAlly3 ();

		}
	}


	public void RegenTurnAllies(){
		if (SOAlly1.CharacterRegen == true) {
			SOAlly1.CharacterCurrentHP += regenAmount;
			UpdateHPBarAlly1 ();

		}
		if (SOAlly2.CharacterRegen == true) {
			SOAlly2.CharacterCurrentHP += regenAmount;
			UpdateHPBarAlly2 ();

		}		
		if (SOAlly3.CharacterRegen == true) {
			SOAlly3.CharacterCurrentHP += regenAmount;
			UpdateHPBarAlly3 ();

		}
	}


	//Have the HP bars change visually:
	void UpdateHPBarAlly1(){
		HPBAlly1.UpdateBar (SOAlly1.CharacterCurrentHP, SOAlly1.CharacterMaxHP);
	}
	void UpdateHPBarAlly2(){
		HPBAlly2.UpdateBar (SOAlly2.CharacterCurrentHP, SOAlly2.CharacterMaxHP);
	}
	void UpdateHPBarAlly3(){
		HPBAlly3.UpdateBar (SOAlly3.CharacterCurrentHP, SOAlly3.CharacterMaxHP);
	}

	void UpdateHPBarEnemy1(){
		HPBEnemy1.UpdateBar (SOEnemy1.CharacterCurrentHP, SOEnemy1.CharacterMaxHP);
	}
	void UpdateHPBarEnemy2(){
		HPBEnemy2.UpdateBar (SOEnemy2.CharacterCurrentHP, SOEnemy2.CharacterMaxHP);
	}
	void UpdateHPBarEnemy3(){
		HPBEnemy3.UpdateBar (SOEnemy3.CharacterCurrentHP, SOEnemy3.CharacterMaxHP);
	}



	void PlusTurnDeadAlly (){
		if (((turnsStateMachine.TurnAmount + ExtraTurnDeadAlly) % 3 == 0) && (!SOAlly3.CharacterAlive)) {
			ExtraTurnDeadAlly += 1;
		} else if (((turnsStateMachine.TurnAmount + ExtraTurnDeadAlly) % 3 == 1) && (!SOAlly1.CharacterAlive)) {
			ExtraTurnDeadAlly += 1;
		} else if (((turnsStateMachine.TurnAmount + ExtraTurnDeadAlly) % 3 == 2) && (!SOAlly2.CharacterAlive)) {
			ExtraTurnDeadAlly += 1;
		}
	}

	void PlusTurnDeadEnemy (){
		if (((turnsStateMachine.TurnAmount + ExtraTurnDeadAlly) % 3 == 0) && (!SOEnemy3.CharacterAlive)) {
			ExtraTurnDeadAlly += 1;
		} else if (((turnsStateMachine.TurnAmount + ExtraTurnDeadAlly) % 3 == 1) && (!SOEnemy1.CharacterAlive)) {
			ExtraTurnDeadAlly += 1;
		} else if (((turnsStateMachine.TurnAmount + ExtraTurnDeadAlly) % 3 == 2) && (!SOEnemy2.CharacterAlive)) {
			ExtraTurnDeadAlly += 1;
		}
	}
}