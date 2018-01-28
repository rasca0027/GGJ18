﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LandController : MonoBehaviour
{
	public Crop crop;
	public bool watered;
	private GameObject gameManager;
	private Sprite[] spritesNight;
	

	void Awake()
	{
		gameManager = GameObject.FindGameObjectWithTag("Player");
	}

	private void Start()
	{
		crop = new Crop();
		watered = false;
		spritesNight = Resources.LoadAll<Sprite>("NightCrops");

	}

	private void Update()
	{
		
		
		if (crop.state == 0 || crop.state == 5)
		{
			GetComponent<SpriteRenderer>().sprite = spritesNight[6];
		} else if (crop.state == 1)
		{
			GetComponent<SpriteRenderer>().sprite = spritesNight[0];
		} else if (crop.state == 2)
		{
			GetComponent<SpriteRenderer>().sprite = spritesNight[2];
		} else if (crop.state == 3)
		{
			if (crop.remainingDay == 0)
			{
				GetComponent<SpriteRenderer>().sprite = spritesNight[4];
			}
			else if (!watered)
			{
				//Debug.Log("not waterrrrrrrrrrrrrrr");
				GetComponent<SpriteRenderer>().sprite = spritesNight[2];
			}
			else
			{
				GetComponent<SpriteRenderer>().sprite = spritesNight[5];
			}
		} else if (crop.state == 4)
		{
			GetComponent<SpriteRenderer>().sprite = spritesNight[1];
		}
	}

	void OnMouseOver() {
		
		if (Input.GetMouseButtonDown(0))
		{

			int cur = gameManager.GetComponent<PlayerController>().currentAction;

			if (cur == 1) // dig
			{
				Debug.Log("digging");	
				// if land is 0 stage
				if (crop.state == 0)
				{
					crop.state = 1;
					gameManager.GetComponent<TimeController>().PassTime(1f);
					
				}
				// change stage to 1

			}
			else if (cur == 2) // sow
			{
				if (crop.state == 1)
				{
					Debug.Log("sowed");
					crop.state = 2;
					// add emotion
					

					Hope hope = new Hope();
					crop.AddSeed(hope);
					// TODO!!
					gameManager.GetComponent<TimeController>().PassTime(0.5f);
					
					
				}
			}
			else if (cur == 3) // water
			{
				if (crop.state == 2)
				{
					Debug.Log("watering");
					watered = true;
					// change image to watered
					crop.state = 3;
					crop.remainingDay -= 1;
					if (crop.remainingDay <= 0)
						crop.remainingDay = 0;
					gameManager.GetComponent<TimeController>().PassTime(0.5f);
					
				}
				else if (crop.state == 3)
				{

					if (!watered)
					{
						Debug.Log("watering2");
						watered = true;
						// change image to watered
						gameManager.GetComponent<TimeController>().PassTime(0.5f);
						crop.remainingDay -= 1;
						if (crop.remainingDay <= 0)
							crop.remainingDay = 0;
						Debug.Log(crop.remainingDay);
						
					}
					else
					{
						Debug.Log("already watered today");
						//TODO
					}

				}

			}
			else if (cur == 4) // harvest
			{
				if (crop.state == 3)
				{
					// check times up!!
					if (crop.remainingDay == 0)
					{
						Debug.Log("harvesting");
						crop.state = 4;
						gameManager.GetComponent<TimeController>().PassTime(1f);
						
					}
					else
					{
						Debug.Log("not ready");
						//TODO!
						// warning: not ready to harvest
					}
				}
			}
			else if (cur == 5) // store
			{
				if (crop.state == 4)
				{
					GetComponent<SpriteRenderer>().sprite = spritesNight[0];
					
					
					if (crop.emotion.name == "Hope")
					{
					
						gameManager.GetComponent<InventoryController>().AddInv("hope_crop", 1);
					}
					else if (crop.emotion.name == "Stress")
					{
						gameManager.GetComponent<InventoryController>().AddInv("stress_crop", 1);
					}
					else if (crop.emotion.name == "Anger")
					{
						gameManager.GetComponent<InventoryController>().AddInv("anger_crop", 1);
					}
					else if (crop.emotion.name == "Fear")
					{
						gameManager.GetComponent<InventoryController>().AddInv("fear_crop", 1);
					}
					else if (crop.emotion.name == "Desire")
					{
						gameManager.GetComponent<InventoryController>().AddInv("desire_crop", 1);
					}
					else if (crop.emotion.name == "Grief")
					{
						gameManager.GetComponent<InventoryController>().AddInv("grief_crop", 1);
					}
					else
					{
						gameManager.GetComponent<InventoryController>().AddInv("joy_crop", 1);
					}
					
					crop.state = 0;
					gameManager.GetComponent<TimeController>().PassTime(0.5f);


				}
			}

			gameManager.GetComponent<PlayerController>().currentAction = 0;
		}
	}
}
