﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class TextChanger : MonoBehaviour {
 
	private Text[] GetText;
	public Font myFont;

 
	// Use this for initialization
	void Start () {
		GetText = Text.FindObjectsOfType<Text> ();
 
		foreach (Text go in GetText)
			go.font = myFont;


	}
}