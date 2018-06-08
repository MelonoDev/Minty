using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour {
	private bool hovering = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.SetActive (hovering);
		hovering = false;
	}

	public void ActivateInfo (string WhichAttack){
		hovering = true;
		print ("HOVERING");
	}
}
