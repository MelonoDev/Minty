using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMinty : MonoBehaviour {
	
	public int FullHP = 7;
	public int CurrentHP = 4;
	public int Attack = 5;
	public int Heal = 5;

	// Use this for initialization
	void Start () {
		print (FullHP);
		print (CurrentHP);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AlterHP (int Damage) {
		CurrentHP += Damage;
	}
}
