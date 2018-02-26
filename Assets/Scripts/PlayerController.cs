using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 1f;
	public Sprite cursorDig;
	public Sprite cursorSow;
	public Sprite cursorWater;
	public Sprite cursorHarvest;
	public Sprite cursorStore;
	public int currentAction = 0;
	public int chosenSeed;
	public GameObject cursorPrefab;

	private bool clicked = false;
	private Vector3 mousePosition;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;
	private GameObject cursorObj;
	
	
	// Use this for initialization
	void Start ()
	{
		chosenSeed = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentAction == 0)
		{
			clicked = false;
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			Destroy (cursorObj);
		}

		if (clicked)
		{
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			
			//cursorObj.transform.position = Vector2.Lerp(cursorObj.transform.position, mousePosition, moveSpeed);
			cursorObj.transform.position = new Vector3(mousePosition.x, mousePosition.y, -0.5f);
			//Cursor.SetCursor(cursor, hotSpot, cursorMode);

			if (Input.GetMouseButtonDown(1))
				currentAction = 0;
		}
		
		
		
	}

	public void Dig()
	{
		clicked = true;
		currentAction = 1;
		cursorObj = Instantiate(cursorPrefab);	
		cursorObj.transform.localScale = new Vector3 (0.6f, 0.6f);
	}
	
	public void Sow()
	{
		clicked = true;
		currentAction = 2;
		cursorObj = Instantiate(cursorPrefab);
		cursorObj.GetComponent<SpriteRenderer> ().sprite = cursorSow;
		cursorObj.transform.localScale = new Vector3 (0.6f, 0.6f);
	}
	
	public void Water()
	{
		clicked = true;
		currentAction = 3;
		cursorObj = Instantiate(cursorPrefab);
		cursorObj.GetComponent<SpriteRenderer> ().sprite = cursorWater;
		cursorObj.transform.localScale = new Vector3 (0.6f, 0.6f);
	}
	
	public void Harvest()
	{
		clicked = true;
		currentAction = 4;
		cursorObj = Instantiate(cursorPrefab);
		cursorObj.GetComponent<SpriteRenderer> ().sprite = cursorHarvest;
		cursorObj.transform.localScale = new Vector3 (0.6f, 0.6f);
	}
	
	public void Store()
	{
		clicked = true;
		currentAction = 5;
		cursorObj = Instantiate(cursorPrefab);
		cursorObj.GetComponent<SpriteRenderer> ().sprite = cursorStore;
		cursorObj.transform.localScale = new Vector3 (0.6f, 0.6f);
	}

	public void ChooseStress()
	{
		chosenSeed = 2;
	}

	public void ChooseHope()
	{
		chosenSeed = 1;
	}

	public void ChooseFear()
	{
		chosenSeed = 4;
	}

	public void ChooseAnger()
	{
		chosenSeed = 5;
	}

	public void ChooseDesire()
	{
		chosenSeed = 6;
	}

	public void ChooseGrief()
	{
		chosenSeed = 7;
	}
}
