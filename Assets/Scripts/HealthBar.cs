using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	GUIStyle healthStyle;
	GUIStyle backStyle;
	Combat combat;

	void Awake() {
		combat = GetComponent<Combat> ();	
	}

	void OnGUI() {
		InitStyles ();

		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);

		GUI.color = Color.gray;
		GUI.backgroundColor = Color.gray;
		GUI.Box (new Rect(pos.x - 26, Screen.height - pos.y + 20, combat.healthMax/2, 7), ".", backStyle);


		GUI.color = Color.green;
		GUI.backgroundColor = Color.green;
		GUI.Box (new Rect(pos.x - 25, Screen.height - pos.y + 21, combat.currHealth/2, 5), ".", healthStyle);
	}

	void InitStyles() {
		if (healthStyle == null) {
			healthStyle = new GUIStyle (GUI.skin.box);
			healthStyle.normal.background = MakeTex (2, 2, new Color(0, 1, 0, 1));
		}
		if (backStyle == null) {
			backStyle = new GUIStyle (GUI.skin.box);
			backStyle.normal.background = MakeTex (2, 2, new Color(0, 0, 0, 1));
		}
	}

	Texture2D MakeTex(int width, int height, Color col) {
		Color[] pix = new Color[width * height];
		for(int i = 0; i < pix.Length; i++) {
			pix[i] = col;
		}
		Texture2D result = new Texture2D(width, height);
		result.SetPixels (pix);
		result.Apply ();

		return result;
	}
}
