using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandController : MonoBehaviour
{
	public Crop crop;
	public bool watered;
	private GameObject gameManager;
	

	void Awake()
	{
		gameManager = GameObject.FindGameObjectWithTag("Player");
	}

	private void Start()
	{
		crop = new Crop();
		watered = false;
	}

	void OnMouseOver() {
		
		if (Input.GetMouseButtonDown(0))
		{
			
			
			int cur = gameManager.GetComponent<PlayerController>().currentAction;
			
			Debug.Log(cur);
			
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
					crop.state = 3;
					crop.remainingDay -= 1;
					if (crop.remainingDay <= 0)
						crop.remainingDay = 0;
					gameManager.GetComponent<TimeController>().PassTime(0.5f);
				}
				else if (crop.state == 3)
				{
					
					watered = true;
					if (!watered)
					{
						Debug.Log("watering2");
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
					
					crop.state = 5;
					gameManager.GetComponent<TimeController>().PassTime(0.5f);
				}
			}

			gameManager.GetComponent<PlayerController>().currentAction = 0;
		}
	}
}
