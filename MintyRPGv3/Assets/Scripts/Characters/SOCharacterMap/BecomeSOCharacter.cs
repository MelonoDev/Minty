using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeSOCharacter : MonoBehaviour {

	public SOCharacter soCharacter;
	public SimpleHealthBar HPBar;

	// Use this for initialization
	void Start () {
		Debug.Log (soCharacter.CharacterName);
		soCharacter.ResetHP();
		HPBar.UpdateBar(soCharacter.CharacterCurrentHP, soCharacter.CharacterMaxHP);

		GetComponent<Renderer> ().material = soCharacter.CharacterIdle;
	}


	//replace all with animations once you get there (HA!)
	void Update(){

		if (soCharacter.IsAttacking) {
			GetComponent<Renderer> ().material = soCharacter.CharacterAttacking;

			StartCoroutine (ReturnToIdle (1f)); //This is how long the material assignment is applied (which is the "animation")

		} else if (soCharacter.IsHealing) {
			GetComponent<Renderer> ().material = soCharacter.CharacterHealing;

			StartCoroutine (ReturnToIdle (1f)); //This is how long the material assignment is applied (which is the "animation")

		}	else if (soCharacter.IsIdle) {
			GetComponent<Renderer> ().material = soCharacter.CharacterIdle;
		
		}
	}

	void FixedUpdate (){
		if (soCharacter.CharacterCurrentHP > soCharacter.CharacterMaxHP) {
			soCharacter.CharacterCurrentHP = soCharacter.CharacterMaxHP;
		}
	}

	IEnumerator ReturnToIdle(float waitTime){

		yield return new WaitForSeconds (waitTime);

		soCharacter.IsAttacking = false;
		soCharacter.IsHealing = false;
		soCharacter.IsHurt = false;
		soCharacter.IsIdle = true;
	}
}
