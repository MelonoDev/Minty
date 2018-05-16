using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverShowInfo : MonoBehaviour 
     , IPointerEnterHandler
     , IPointerExitHandler
	 {

	public GameObject InfoPanel;
	private bool showPanel = false;

	void Awake (){
		InfoPanel = GameObject.Find("InfoParent");
	}

	void Update (){
		if (showPanel){
			showPanel = false;
			if (InfoPanel != null) {
				InfoPanel.SetActive(true);
			}
		}
	}

	public void OnPointerEnter (PointerEventData pointerEventData) {
		showPanel = true;
	}
	
	public void OnPointerExit (PointerEventData pointerEventData) {
		if (InfoPanel != null) {
			InfoPanel.SetActive(false);
		}
	}
}
 