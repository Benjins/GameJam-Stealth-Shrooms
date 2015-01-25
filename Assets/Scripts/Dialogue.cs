using UnityEngine;
using System.Collections;

[System.Serializable]
public class DialogueLine{
	public string line = "";
	public float time = 0;
}

public class Dialogue : MonoBehaviour {

	public DialogueLine[] startLines = new DialogueLine[1];

	string currentDialog = "";

	// Use this for initialization
	void Start () {
		StartCoroutine(ExecuteDialogue(startLines));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 32;
		Rect rect = new Rect(Screen.width * 0.2f, Screen.height * 0.8f, Screen.width * 0.6f, Screen.height * 0.2f);
		GUI.Label(rect, currentDialog);
	}

	IEnumerator ExecuteDialogue(DialogueLine[] lines){
		float time = 0;
		for(int i = 0; i < lines.Length; i++){
			time = 0;
			DialogueLine currentLine = lines[i];
			while(time < currentLine.time){
				currentDialog = currentLine.line;
				time += Time.deltaTime;
				yield return null;
			}
		}

		currentDialog = "";
	}
}
