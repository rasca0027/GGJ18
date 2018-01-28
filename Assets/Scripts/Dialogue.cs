using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class Dialog
{
	public string opening;
	public string request;
	public string[] interrogation;
	public Dictionary<string, string> choices;

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
	public GameObject choicePanel;
	public GameObject customerImage;
	public bool inMarket;

	
	private int progress;
	private int curMissionNum;
	private Dialog curMission;
	private bool toggle;
	private int interrogate;
	[SerializeField]
	private Sprite[] images;

	private bool choiceGenerated = false;

	private string[] answers;
	
	// TRY
	//private List<List<string>> allMissions = new List<List<string>>();
	
	
	// Use this for initialization
	void Start () {
		init();
		progress = 0;
		curMissionNum = 0;
		curMission = missions[0];
		inMarket = false;
		toggle = false; // me
		interrogate = 0;
		answers = new string[4];
	}
	
	// Update is called once per frame
	void Update () {

		if ((curMissionNum + 1) % 3 == 0)
		{
			inMarket = false;
			GetComponent<TimeController>().EndDay();
		}

		if (inMarket)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (progress == 3) // interrogate
				{
					toggle = !toggle;
					interrogate += 1;
					if (interrogate == curMission.interrogation.Length)
					{
						progress += 1; // to next level
						interrogate = 0;
						toggle = false;
					}					
				}
				else if (progress == 4) // choice
				{
					// do something
				}
				else if (progress == 5) // end
				{
					// not die
					progress = 0;
					curMissionNum += 1;
					curMission = missions[curMissionNum];
					choiceGenerated = false;
				}
				else
				{
					progress += 1;
					customer.active = false;
					myDia.active = false;
				}
				
			} // end mouse down

			
			switch (progress)
			{
				case 0:
					// change image
					customerImage.GetComponent<SpriteRenderer>().sprite = images[curMissionNum];
					customer.active = true;
					customer.transform.GetChild(0).GetComponent<Text>().text = curMission.opening;
					break;
				case 1:
					myDia.active = true;
					myDia.transform.GetChild(0).GetComponent<Text>().text = "What do you want?";
					break;
				case 2: // request
					customer.active = true;
					customer.transform.GetChild(0).GetComponent<Text>().text = curMission.request;
					break;		
				case 3: // interrogation
					if (toggle)
					{
						// customer
						myDia.active = false;
						customer.active = true;
						customer.transform.GetChild(0).GetComponent<Text>().text = curMission.interrogation[interrogate];
					}
					else
					{
						myDia.active = true;
						customer.active = false;
						myDia.transform.GetChild(0).GetComponent<Text>().text = curMission.interrogation[interrogate];
					}
					break;
				case 4:
					choicePanel.active = true;
					// display choice
					if (!choiceGenerated)
					{
						int i = 0;
						foreach (string key in curMission.choices.Keys)
						{
							
							choicePanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = key;

							if (curMission.choices[key] == "Die")
							{
								choicePanel.transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(DieHandler);
							}
							else
							{
								// normal handler

								choicePanel.transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
									() => Debug.Log(key)
								);
							}

							i += 1;
						}

						choiceGenerated = true;
					}

					break;

			} // end switch

			
			
		}

	}
	
	

	private void init()
	{
		
		// TODO reead from json file
		Dialog mission1 = new Dialog();
		mission1.opening = "What’s up farmer dude?";
		mission1.request = "I’ve got finals coming up and need some stress.";
		mission1.interrogation = new string[]
		{
			"Why would you want more stress in your life?",
			"I think that I can pass my finals without even studying and I want to feel the nagging sense of stress that would be appropriate for this situation."
		};
		mission1.choices = new Dictionary<string, string>();
		mission1.choices.Add("Stress", "Thanks homeboy!");
		mission1.choices.Add("Fear", "I think I will fail in life. I don’t want to live anymore.");
		mission1.choices.Add("Desire", "I am made to do great things. I will conquer the world.");
		mission1.choices.Add("Decline", "Gee, What a buzzturd.");

		missions[0] = mission1;
		
		// 2		
		Dialog mission2 = new Dialog();
		mission2.opening = "Hee-Haw! Out with your goods!";
		mission2.request = "The forbidden fruit. My gateway to Valhalla. I want Joy!!!";
		mission2.interrogation = new string[]
		{
			"Calm down man. I don’t have it. It takes ages to grow.",
			"Out with it! Or I will kill you. You won’t be my first, and certainly not the last. "
		};
		mission2.choices = new Dictionary<string, string>();
		


		missions[1] = mission2;
		missions[2] = mission2;

	}

	void DieHandler()
	{
		// change Scene
		Debug.Log("DIE");
		SceneManager.LoadScene("Die", LoadSceneMode.Single);
	}

	void handler(string emo, string reply)
	{
		Debug.Log(reply);
	}

}
