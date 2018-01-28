using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 1f;
	public Texture2D cursorDig;
	public Texture2D cursorSow;
	public Texture2D cursorWater;
	public Texture2D cursorHarvest;
	public Texture2D cursorStore;
	public int currentAction = 0;
	public int chosenSeed;

	private bool clicked = false;
	private Vector3 mousePosition;
	private Texture2D cursor;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;
	
	
	
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
		}

		if (clicked)
		{
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			//cursor.transform.position = Vector2.Lerp(cursor.transform.position, mousePosition, moveSpeed);
			//cursor.transform.position = new Vector2(mousePosition.x, mousePosition.y);
			Cursor.SetCursor(cursor, hotSpot, cursorMode);

			if (Input.GetMouseButtonDown(1))
				clicked = false;
		}
		
		
		
	}

	public void Dig()
	{
		clicked = true;
		currentAction = 1;
		cursor = cursorDig;	
	}
	
	public void Sow()
	{
		clicked = true;
		currentAction = 2;
		cursor = cursorDig;	
	}
	
	public void Water()
	{
		clicked = true;
		currentAction = 3;
		cursor = cursorDig;	
	}
	
	public void Harvest()
	{
		clicked = true;
		currentAction = 4;
		cursor = cursorDig;	
	}
	
	public void Store()
	{
		clicked = true;
		currentAction = 5;
		cursor = cursorDig;	
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
