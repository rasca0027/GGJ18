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

	public Dialog[] missions = new Dialog[6];
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
	private bool end = false;

	private string[] answers;
	private Dictionary<string, int> prices = new Dictionary<string, int>();
	
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
		
		prices.Add("Hope", 1000);
		prices.Add("Stress", 1);
		prices.Add("Anger", 100);
		prices.Add("Fear", 100);
		prices.Add("Desire", 10);
		prices.Add("Grief", 50);
		prices.Add("Joy", 10000000);
	}
	
	// Update is called once per frame
	void Update () {

		if ((curMissionNum) % 3 == 0 && !end)
		{
			end = !end;
			GetComponent<TimeController>().EndDay();
		}

		if (inMarket)
		{
			Debug.Log(progress);
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
				else if (progress >= 5) // end
				{
					// not die
					progress = 0;
					curMissionNum += 1;
					curMission = missions[curMissionNum];
					choiceGenerated = false;
					choicePanel.active = false;
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
							else if (key == "Decline")
							{
								choicePanel.transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
									() =>
									{
										progress += 1;
										customer.active = true;
										customer.transform.GetChild(0).GetComponent<Text>().text = curMission.choices[key];					
										choicePanel.active = false;
									}
								);
							}
							else
							{
								// normal handler

								choicePanel.transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
									() =>
									{
										
										if (GetComponent<InventoryController>().CheckCrop(key))
										{
											progress += 1;
											customer.active = true;
											choicePanel.active = false;
											customer.transform.GetChild(0).GetComponent<Text>().text = curMission.choices[key];
											// success
											string s = key.ToLower() + "_crop";
											GetComponent<InventoryController>().AddInv(s, -1);
											int p = prices[key];
											GetComponent<MoneyController>().ChangeMoney(p);
											choicePanel.active = false;
										}
									}
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
		mission2.opening = "Hi";
		mission2.request = "I am looking to grieve.";
		mission2.interrogation = new string[]
		{
			"Why?",
			"I took my twin to the Moonshine Festival on our birthday only to have her die in a freak accident. I want to feel the pain and sadness."
		};
		mission2.choices = new Dictionary<string, string>();
		mission2.choices.Add("Grief", "Thank you. Thank you.");
		mission2.choices.Add("Stress", "You are a monster.");
		mission2.choices.Add("Desire", "What use will this be to me.");
		mission2.choices.Add("Decline", "You have no heart!");
		missions[1] = mission2;
		
		// 3	
		Dialog mission3 = new Dialog();
		mission3.opening = " Hee-Haw! Out with your goods! ";
		mission3.request = "The forbidden fruit. My gateway to Valhalla. I want Joy!!!";
		mission3.interrogation = new string[]
		{
			"Calm down man. I don’t have it. It takes ages to grow.",
			"Out with it! Or I will kill you. You won’t be my first, and certainly not the last. I have killed 17 people. You don’t want to be the 18th."
		};
		mission3.choices = new Dictionary<string, string>();
		mission3.choices.Add("Stress", "Die");
		mission3.choices.Add("Fear", "Die");
		mission3.choices.Add("Grief", "**cries** What I have done? I didn’t mean to kill those people.");
		mission3.choices.Add("Decline", "Die");
		missions[3] = mission3;
		
		// 4
		Dialog mission4 = new Dialog();
		mission4.opening = "Hello Sir. How are you doing tonight?";
		mission4.request = "I want the liquid of desire.";
		mission4.interrogation = new string[]
		{
			"Why do you want it?",
			"Sir, I am a scavenger. I don’t have any money. I came across this movie called “Wall-E” from the olden times. I just want to feel what it’s like to desire someone."
		};
		mission4.choices = new Dictionary<string, string>();
		mission4.choices.Add("Stress", "Not what I wanted but thanks anyway kind Sir.");
		mission4.choices.Add("Anger", "Not what I wanted but thanks anyway kind Sir.");
		mission4.choices.Add("Desire", "Here is a gift. It’s a cop detector.");
		mission4.choices.Add("Decline", "Sorry for bothering you sir.");

		missions[4] = mission4;
		
		// 2		
		Dialog mission5 = new Dialog();
		mission5.opening = "Howdy soul farmer!";
		mission5.request = "My bedding, it sticks. My mouse it clicks. Could you please give me the feeling of a melting candle stick";
		mission5.interrogation = new string[]
		{
			"I don’t sell anything like that. ",
			"Life’s been hitting me in the britches and my cousin’s been getting stitches and my dog’s oxygen got left with his bone. Hit me up with some of that free-flight emotion."
		};
		mission5.choices = new Dictionary<string, string>();
		mission5.choices.Add("Stress", "Jorgi likes it. You are Jorgi’s only true friend.");
		mission5.choices.Add("Fear", "Jorgi likes it. You are Jorgi’s only true friend.");
		mission5.choices.Add("Grief", "Jorgi likes it. You are Jorgi’s only true friend.");
		mission5.choices.Add("Decline", "Why you do this to poor Jorgi!");
		missions[2] = mission5;
		
		// 3	
		Dialog mission6 = new Dialog();
		mission6.opening = " Hee-Haw! Out with your goods! ";
		mission6.request = "The forbidden fruit. My gateway to Valhalla. I want Joy!!!";
		mission6.interrogation = new string[]
		{
			"Calm down man. I don’t have it. It takes ages to grow.",
			"Out with it! Or I will kill you. You won’t be my first, and certainly not the last. I have killed 17 people. You don’t want to be the 18th."
		};
		mission6.choices = new Dictionary<string, string>();
		mission6.choices.Add("Stress", "Die");
		mission6.choices.Add("Fear", "Die");
		mission6.choices.Add("Grief", "**cries** What I have done? I didn’t mean to kill those people.");
		mission6.choices.Add("Decline", "Die");
		missions[5] = mission6;
		

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
