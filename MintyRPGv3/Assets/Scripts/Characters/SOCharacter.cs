using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "SOCharacter")]
public class SOCharacter : ScriptableObject {

	public string CharacterName;
	public int CharacterNumber;

	public int CharacterMaxHP;
	public int CharacterCurrentHP;

	public int CharacterAttack;
	public int CharacterHeal;

	public bool CharacterPoisonous;

	public bool CharacterAlive = true;
	public bool CharacterPoisoned;
	public bool CharacterRegen;

	public bool CharacterPermaDeath;

	public bool IsIdle;
	public bool IsHurt;	
	public bool IsAttacking;
	public bool IsHealing;

	public Material CharacterIdle;
	public Material CharacterHurt;
	public Material CharacterAttacking;
	public Material CharacterHealing;

	//public void AlterHP (int Damage) {
	//	CharacterCurrentHP += Damage;
	//}



	public void Print (){
		Debug.Log (CharacterCurrentHP);
	}

	public void ResetHP (){
		CharacterCurrentHP = CharacterMaxHP;
		CharacterPoisoned = false;
		CharacterRegen = false;
		CharacterAlive = true;

		IsIdle = true;
		IsHurt = false;	
		IsAttacking = false;
		IsHealing = false;
	}

	public void Attack(){
		
	}

}
