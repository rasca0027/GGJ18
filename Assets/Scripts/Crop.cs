using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;



public class Crop
{
	public Emotion emotion;
	public int remainingDay;
	
	public int state; 
	/* 0 for nothing
	   1 for digged
	   2 for sowed
	   ...
	   5 for stored, back to 0
	*/
	
	public Crop()
	{
		state = 0;
	}

	public void AddSeed(Emotion emo)
	{
		emotion = emo;
		remainingDay = emotion.daysToGrow;
	}
}
