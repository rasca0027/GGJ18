using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	public GameObject warning;
	public GameObject timeText;
	public GameObject dayText;
	public GameObject dateText;
	
	
	private float hour;
	private int dateCount; // Day 1, 2, 3 etc
	private int dayCount; // Monday etc
	private string[] daysInWeek = new string[7] {
		"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"	
	};

	// Use this for initialization
	void Start ()
	{
		hour = 6f;
		dateCount = 1;
		dayCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
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
		if ((hour + workHour) < 17.0f)
		{
			hour += workHour;
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
		
	}
}
