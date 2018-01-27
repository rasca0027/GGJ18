using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
	public GameObject moneyText;
	private int money;
	
	// Use this for initialization
	void Start ()
	{
		money = 1000;
	}
	
	// Update is called once per frame
	void Update ()
	{
		moneyText.GetComponent<Text>().text = money.ToString();
	}

	public void ChangeMoney(int amount)
	{
		money += amount;
	}
}
