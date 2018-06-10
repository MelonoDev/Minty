using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHoverShowInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public static string WhichButtonIsHovered = "None";

	void Update(){
		print (WhichButtonIsHovered);

	}

	public void OnPointerEnter(PointerEventData pointerEventData){
		WhichButtonIsHovered = gameObject.name;
	} 

	public void OnPointerExit(PointerEventData pointerEventData){
		WhichButtonIsHovered = "None";
	}
}
 