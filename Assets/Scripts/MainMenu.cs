﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public Texture backgroundTexture;

	void OnGUI() {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
	}
}
