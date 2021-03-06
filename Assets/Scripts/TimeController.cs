﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	public GameObject warning;
	public GameObject timeText;
	public GameObject dayText;
	public GameObject dateText;
	public GameObject FarmScene;
	public GameObject MarketScene;
	public GameObject bg;
	public Sprite morning;
	public GameObject toolbar;
	
	
	private float hour;
	private int dateCount; // Day 1, 2, 3 etc
	private int dayCount; // Monday etc
	private string[] daysInWeek = new string[7] {
		"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"	
	};

	// Use this for initialization
	void Start ()
	{
		hour = 3f;
		dateCount = 0;
		dayCount = -1; // TODO 0
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (hour >= 8)
		{
			bg.GetComponent<SpriteRenderer>().sprite = morning;
		}
		*/

		// convert and display

		string convertedTime = "";
		string[] hourToString = hour.ToString().Split('.');
	
		if (hour < 10)
		{
			convertedTime += "0" + hourToString[0];
		}
		else
		{
			convertedTime += hourToString[0];
		}

		if (hourToString.Length >= 2)
		{
			// there is minutes
			convertedTime += ":30";
		}
		else
		{
			convertedTime += ":00";
		}

		timeText.GetComponent<Text>().text = convertedTime;
		
		// show date and day
		dayText.GetComponent<Text>().text = daysInWeek[dayCount];
		dateText.GetComponent<Text>().text = "DAYS " + dateCount.ToString();

	}

	public void PassTime (float workHour)
	{
		if ((hour + workHour) < 13.0f)
		{
			hour += workHour;
		}
		else if ((hour + workHour) == 13.0f)
		{
			hour += workHour;
			EndDay();
		}
		else
		{
			// raise warning
			Instantiate(warning);
		}
	}


	public void EndDay()
	{
		
		dateCount += 1;
		dayCount = (dayCount + 1) % 7;
		hour = 3f;
		foreach (var land in GameObject.FindGameObjectsWithTag("Land"))
		{
			land.GetComponent<LandController>().watered = false;
		}

		if (dayCount >= 5)
		{
			FarmScene.active = false;
			toolbar.active = false;
			MarketScene.active = true;
			GetComponent<Dialogue>().inMarket = true;
		}
		else
		{
			GetComponent<Dialogue>().inMarket = false;
			FarmScene.active = true;
			MarketScene.active = false;
			toolbar.active = true;
			GetComponent<Dialogue>().inMarket = false;
		}

	}
}
