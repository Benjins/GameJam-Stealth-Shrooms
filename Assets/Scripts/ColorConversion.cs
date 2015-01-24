using UnityEngine;
using System.Collections;

public class ColorConversion : MonoBehaviour {
	
	public float changeTime = 2.0f;
	public bool changeColor = false;
	//public float offset = 0.0f;

	Color targetColor = Color.white;
	bool changingColor = false;

	// Update is called once per frame
	void Update () {
		if(!changingColor && changeColor){
			float h = Random.value;
			float s = Random.Range(0.6f,0.9f);
			float v = Random.Range(0.6f,1.0f);
			StartCoroutine(ChangeCol(HSVToRGB(h, s, v)));
		}
	}

	IEnumerator ChangeCol(Color col){
		changingColor = true;
		targetColor = col;
		float currentTime = 0.0f;
		Color previousColor = renderer.material.color;

		while(currentTime < changeTime){
			renderer.material.color = Color.Lerp(previousColor, targetColor, currentTime/changeTime);
			currentTime += Time.deltaTime;
			yield return null;
		}

		changingColor = false;
	}

	public static Color HSVToRGB(float h, float s, float v){
		float hh, p, q, t, ff;
		long i;

		if(s <= 0.0){
			return new Color(v, v, v);
		}

		hh = h;
		if(hh >= 1){
			hh = 0;
		}
		hh *= 6;
		i = Mathf.FloorToInt(hh);
		ff = hh - i;
		p = v * (1 - s);
		q = v * (1 - (s * ff));
		t = v * (1 - (s * (1 - ff)));
		switch(i){
		case 0:
			return new Color(v, t, p);
		case 1:
			return new Color(q, v, p);
		case 2:
			return new Color(p, v, t);
		case 3:
			return new Color(p, q, v);
		case 4:
			return new Color(t, p, v);
		case 5:
			return new Color(v, p, q);
		default:
			return new Color(v, p, q);
		}
	}
}
