using UnityEngine;
using System.Collections;

public enum MenuButtonType{Start, Quit}

public class MenuScript : MonoBehaviour {

	public MenuButtonType buttonType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUpAsButton(){
		switch(buttonType){
		case MenuButtonType.Start:
			Application.LoadLevel(1);
			break;
		case MenuButtonType.Quit:
			Application.Quit();
			break;
		default:
			break;
		}
	}
}
