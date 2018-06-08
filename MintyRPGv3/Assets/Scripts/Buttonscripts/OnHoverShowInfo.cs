using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverShowInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public string WhichButtonIsHovered;

	void Start(){
		WhichButtonIsHovered = this.name;
	}

	public void OnPointerEnter(){

	} 
}
 