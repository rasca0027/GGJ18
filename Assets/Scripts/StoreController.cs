using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{


	public GameObject store;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenStore()
	{
		store.active = true;
	}

	public void CloseStore()
	{
		store.active = false;
	}

	public void BuyHope()
	{
		if (GetComponent<MoneyController>().money - 500 >= 0)
		{
			GetComponent<MoneyController>().ChangeMoney(-500);
			GetComponent<InventoryController>().AddInv("hope_seed", 1);
		}
	}
	
	public void BuyStress()
	{
		GetComponent<InventoryController>().AddInv("stress_seed", 1);

	}
	
	public void BuyAnger()
	{
		if (GetComponent<MoneyController>().money - 70 >= 0)
		{
			GetComponent<MoneyController>().ChangeMoney(-70);
			GetComponent<InventoryController>().AddInv("anger_seed", 1);
		}
	}
	
	public void BuyFear()
	{
		if (GetComponent<MoneyController>().money - 50 >= 0)
		{
			GetComponent<MoneyController>().ChangeMoney(-50);
			GetComponent<InventoryController>().AddInv("fear_seed", 1);
		}
	}
	
	public void BuyDesire()
	{
		if (GetComponent<MoneyController>().money - 5 >= 0)
		{
			GetComponent<MoneyController>().ChangeMoney(-5);
			GetComponent<InventoryController>().AddInv("desire_seed", 1);
		}
	}
	
	public void BuyGrief()
	{
		if (GetComponent<MoneyController>().money - 20 >= 0)
		{
			GetComponent<MoneyController>().ChangeMoney(-20);
			GetComponent<InventoryController>().AddInv("grief_seed", 1);
		}
	}
	

}
