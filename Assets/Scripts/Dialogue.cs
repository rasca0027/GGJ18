using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;




public class Dialog
{
	public string opening;
	public string request;
	public string[] interrogation;
	public string[] choices;
	public int answer;
	/*
	 * Answer
	 * 0: All die
	 * 1: Hope
	 * 2: Stress
	 * 3: Anger
	 * 4: Fear
	 * 5: Desire
	 * 6: Grief
	 * 7: Joy
	 */

};


public class Dialogue : MonoBehaviour
{

	public Dialog[] missions = new Dialog[3];
	public GameObject myDia;
	public GameObject customer;
	public bool inMarket;
	
	private int progress;
	private int curMissionNum;
	private Dialog curMission;

	
	// Use this for initialization
	void Start () {
		init();
		progress = 0;
		curMissionNum = 0;
		curMission = missions[0];
		inMarket = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (inMarket)
		{
			if (Input.GetMouseButtonDown(0))
			{
				progress += 1;
				customer.active = false;
				myDia.active = false;
			}

			switch (progress)
			{
				case 0:
					customer.active = true;
					customer.GetComponent<Text>().text = missions[0].opening;
					break;
				case 1:
					myDia.active = true;
					myDia.GetComponent<Text>().text = "What do you want?";
					break;
			}
		}

	}
	
	

	private void init()
	{
		// TODO reead from json file
		Dialog mission1 = new Dialog();
		mission1.opening = "Hee-Haw! Out with your goods!";
		mission1.request = "The forbidden fruit. My gateway to Valhalla. I want Joy!!!";
		mission1.interrogation = new string[]
		{
			"Calm down man. I don’t have it. It takes ages to grow.",
			"Out with it! Or I will kill you. You won’t be my first, and certainly not the last. "
		};
		mission1.choices = new string[] { "Stress", "Decline" };
		mission1.answer = 6;
		missions[0] = mission1;
	}
}
