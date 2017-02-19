﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitRoom : MonoBehaviour {

	public int sceneToGo;
	public string varName;
	public bool valueToExit;
	public IState state;

	public GameObject panel;
	public string file;

	// Use this for initialization
	void Start () {
		StreamReader sr = new StreamReader(Application.dataPath + "/Texts/" + file);
		string fileContents = sr.ReadToEnd();
		sr.Close();

		panel.GetComponentInChildren<Text>().text = fileContents;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseUp()
	{
		Type t = state.GetType();
		if(valueToExit == (bool)t.GetProperty(varName).GetValue(state, null))
		{
			SceneManager.LoadScene(sceneToGo);
		} else
		{
			panel.SetActive(true);
		}
	}
}
