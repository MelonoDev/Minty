using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
	StartBattle, 
	AllyBegin, 
	Ally1, 
	Ally2, 
	Ally3, 
	AllyRegen, 
	AllyPoison, 
	AllyEnd, 
	EnemyBegin, 
	Enemy1, 
	Enemy2, 
	Enemy3, 
	EnemyRegen, 
	EnemyPoison, 
	EnemyEnd, 
	EndBattle
}

public class TurnsStateMachine : MonoBehaviour {

	public SOCharacter Minty;
	public SOCharacter OldBro;
	public SOCharacter YoungBro;
	public SOCharacter Enemy1;
	public SOCharacter Enemy2;
	public SOCharacter Enemy3;

	public HealAttackObject healAttackObject;

	public State CurrentState;

	//for turn-tied dialogue etc
	public int TurnAmount = 0; 

	//seconds for poison and regen to take in the turn
	private float poisonTime = 1f;	private float regenTime	= 1f;
	private float attackTime = 2f;
  

	//Calling for a single action in a State.whatever
	private bool singleActionStartBattle = true; //for calling a single frame of action.
	private bool singleActionAllyBegin = true; //for calling a single frame of action.
	private bool singleActionAlly1 = true; //for calling a single frame of action.
	private bool singleActionAlly2 = true; //for calling a single frame of action.
	private bool singleActionAlly3 = true; //for calling a single frame of action.
	private bool singleActionAllyRegen = true; //for calling a single frame of action.
	private bool singleActionAllyPoison = true; //for calling a single frame of action.
	private bool singleActionAllyEnd = true; //for calling a single frame of action.
	private bool singleActionEnemyBegin = true; //for calling a single frame of action.
	private bool singleActionEnemy1 = true; //for calling a single frame of action.
	private bool singleActionEnemy2 = true; //for calling a single frame of action.
	private bool singleActionEnemy3 = true; //for calling a single frame of action.
	private bool singleActionEnemyRegen = true; //for calling a single frame of action.
	private bool singleActionEnemyPoison = true; //for calling a single frame of action.
	private bool singleActionEnemyEnd = true; //for calling a single frame of action.
	private bool singleActionEndBattle = true; //for calling a single frame of action.



	// Use this for initialization
	void Start () {
		CurrentState = State.StartBattle;
	}
	
	// Update is called once per frame
	void Update () {
		CheckState ();
	}

	void CheckState (){
		switch (CurrentState) {		
		case State.StartBattle:

			if (singleActionStartBattle) {
				singleActionStartBattle = !singleActionStartBattle;
				print ("StartBattle");				
				//call entering the stage animations here
				NextState();

			}


			break;
		case State.AllyBegin:



			if (singleActionAllyBegin) {
				singleActionAllyBegin = !singleActionAllyBegin;
				print ("AllyBegin");
				TurnAmount += 1;
				//anything I might want at the start of the ally turns like dialogue or some kind of visuals like "Turn start! on sceren"
				NextState();

			}


			break;
		case State.Ally1:

			if (singleActionAlly1) {
				singleActionAlly1 = !singleActionAlly1;
				print ("Ally1");

				//first ally attacks
				Invoke ("AllyAtt1", attackTime);


			}

			break;

		case State.Ally2:

			if (singleActionAlly2) {
				singleActionAlly2 = !singleActionAlly2;
				print ("Ally2");
				Invoke ("AllyAtt2", attackTime);

				//second ally attacks

			}


			//moet nog: if(hasattacked){

			break;





			//EDIT THE CASES BELOW HERE STILL (and up too actually)

		case State.Ally3:

			if (singleActionAlly3) {
				singleActionAlly3 = !singleActionAlly3;
				print ("Ally3");
				//Your turn!
				NextState();

			}


			//moet nog: if(hasattacked){

			break;

		case State.AllyRegen:

			if (singleActionAllyRegen) {
				singleActionAllyRegen = !singleActionAllyRegen;
				print ("AllyRegen");
				//second ally attacks
				healAttackObject.RegenTurnAllies ();
				Invoke ("NextState", regenTime);
			}


			//moet nog: if(hasattacked){

			break;

		case State.AllyPoison:

			if (singleActionAllyPoison) {
				singleActionAllyPoison = !singleActionAllyPoison;
				print ("AllyPoison");
				healAttackObject.PoisonTurnAllies ();
				Invoke ("NextState", poisonTime);
			}


			//moet nog: if(hasattacked){

			break;

		case State.AllyEnd:

			if (singleActionAllyEnd) {
				singleActionAllyEnd = !singleActionAllyEnd;
				//reset the single actions of allies
				singleActionAllyBegin = true;
				singleActionAlly1 = true;
				singleActionAlly2 = true;
				singleActionAlly3 = true;
				singleActionAllyRegen = true;
				singleActionAllyPoison = true;
				singleActionEnemyEnd = true;

				print ("AllyEnd");

				NextState ();
			}


			break;

		case State.EnemyBegin:

			if (singleActionEnemyBegin) {
				singleActionEnemyBegin = !singleActionEnemyBegin;
				print ("EnemyBegin");
				NextState ();

			}


			break;

		case State.Enemy1:

			if ((singleActionEnemy1) && (Enemy1.CharacterAlive)) {
				singleActionEnemy1 = !singleActionEnemy1;
				print ("Enemy1");
				Invoke ("EnemyAtt1", attackTime);

			} 
			if (!(Enemy1.CharacterAlive)){
				NextState ();
			}

			break;

		case State.Enemy2:

			if ((singleActionEnemy2) && (Enemy2.CharacterAlive)) {
				singleActionEnemy2 = !singleActionEnemy2;
				print ("Enemy2");
				Invoke ("EnemyAtt2", attackTime); 

			} 
			if (!(Enemy2.CharacterAlive)){
				NextState ();
			}

			break;

		case State.Enemy3:

			if ((singleActionEnemy3) && (Enemy3.CharacterAlive)) {
				singleActionEnemy3 = !singleActionEnemy3;
				print ("Enemy3");
				Invoke ("EnemyAtt3", attackTime);

			} 
			if (!(Enemy3.CharacterAlive)){
				NextState ();
			}

			break;

		case State.EnemyRegen:

			if (singleActionEnemyRegen) {
				singleActionEnemyRegen = !singleActionEnemyRegen;
				print ("EnemyRegen");
				//second ally attacks
				healAttackObject.RegenTurnEnemies ();
				Invoke ("NextState", regenTime);
			}

			break;

		case State.EnemyPoison:

			if (singleActionEnemyPoison) {
				singleActionEnemyPoison = !singleActionEnemyPoison;
				print ("EnemyPoison");
				healAttackObject.PoisonTurnEnemies ();
				Invoke ("NextState", poisonTime);
			}

			break;

		case State.EnemyEnd:

			if (singleActionEnemyEnd) {
				singleActionEnemyBegin = !singleActionEnemyBegin;
				print ("EnemyEnd");

				//reset the single actions of enemies
				singleActionEnemyBegin = true;
				singleActionEnemy1 = true;
				singleActionEnemy2 = true;
				singleActionEnemy3 = true;
				singleActionEnemyRegen = true;
				singleActionEnemyPoison = true;
				singleActionAllyEnd = true;
				CurrentState = State.AllyBegin;

			}

			break;




		case State.EndBattle:

			if (singleActionEndBattle) {
				singleActionEnemyBegin = !singleActionEnemyBegin;
				print ("EndBattle");

			}

			break;


		}


	}


	//Automatic attacking enemies/allies
	void AllyAtt1(){
		healAttackObject.AllyAttack (1);
		NextState ();
	}
	void AllyAtt2(){
		healAttackObject.AllyAttack (2);
		NextState ();
	}
	void EnemyAtt1(){
		healAttackObject.EnemyAttack (1);
		NextState ();
	}
	void EnemyAtt2(){
		healAttackObject.EnemyAttack (2);
		NextState ();
	}
	void EnemyAtt3(){
		healAttackObject.EnemyAttack (3);
		NextState ();
	}

	//Changing the state 
	public void NextState(){
		CurrentState += 1; 
	}		

}
