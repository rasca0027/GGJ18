using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

	public GameObject invPanel;
	public Dictionary<string, int> inventory = new Dictionary<string, int>();
	
	public GameObject hopeseed;
	public GameObject joyseed;
	public GameObject fearseed;
	public GameObject angerseed;
	public GameObject desireseed;
	public GameObject griefseed;
	public GameObject stressseed;
	
	public GameObject hopecrop;
	public GameObject joycrop;
	public GameObject fearcrop;
	public GameObject angercrop;
	public GameObject desirecrop;
	public GameObject griefcrop;
	public GameObject stresscrop;
	
	
	// Use this for initialization
	void Start () {
		
		inventory.Add("hope_seed", 0);
		inventory.Add("joy_seed", 0);
		inventory.Add("fear_seed", 1);
		inventory.Add("anger_seed", 1);
		inventory.Add("desire_seed", 1);
		inventory.Add("grief_seed", 1);
		inventory.Add("stress_seed", 1);
		
		inventory.Add("hope_crop", 0);
		inventory.Add("joy_crop", 0);
		inventory.Add("fear_crop", 0);
		inventory.Add("anger_crop", 0);
		inventory.Add("desire_crop", 0);
		inventory.Add("grief_crop", 0);
		inventory.Add("stress_crop", 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		// display
		// TODO!!
		
	}

	public void AddInv(string stock, int num)
	{
		inventory[stock] += num;
	}

	public void CloseInv()
	{
		invPanel.active = false;
	}

	public void OpenInv()
	{
		invPanel.active = true;
	}
}
