using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWhenPoisoned : MonoBehaviour {

	public SOCharacter soCharacter; //the ally/enemy that has effects

	public Text AttackDamage;

	public GameObject Poisoned;
	public GameObject Regen;
	public GameObject Poisonous;


	// Use this for initialization
	void Awake (){
		Poisoned = this.transform.Find ("PoisonedEffect").gameObject;
		Regen = this.transform.Find ("RegenEffect").gameObject;
		Poisonous = this.transform.Find ("PoisonousEffect").gameObject;
		AttackDamage = this.transform.Find ("AttackDamageText").GetComponent<Text>();
	}

	void Start () {
		Poisoned.SetActive (false);
		Regen.SetActive (false);
		Poisonous.SetActive (false);
		AttackDamage.text = soCharacter.CharacterAttack.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		if (soCharacter.CharacterPoisoned) {
			Poisoned.SetActive (true);
		} else {
			Poisoned.SetActive (false);
		}
		if (soCharacter.CharacterPoisonous) {
			Poisonous.SetActive (true);
		} else {
			Poisonous.SetActive (false);
		}
		if (soCharacter.CharacterRegen) {
			Regen.SetActive (true);
		} else {
			Regen.SetActive (false);
		}
	}
}
