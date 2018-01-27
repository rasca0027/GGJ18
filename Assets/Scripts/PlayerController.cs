using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 1f;
	public Texture2D cursorDig;

	private bool clicked = false;
	private Vector3 mousePosition;
	private Texture2D cursor;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	private 
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked)
		{
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			//cursor.transform.position = Vector2.Lerp(cursor.transform.position, mousePosition, moveSpeed);
			//cursor.transform.position = new Vector2(mousePosition.x, mousePosition.y);
			Cursor.SetCursor(cursor, hotSpot, cursorMode);
		}

	}

	public void Dig()
	{
		clicked = true;
		Debug.Log("clicked");
		cursor = cursorDig;	
	}
	
	public void Sow()
	{
		clicked = true;
		Debug.Log("clicked");
		cursor = cursorDig;	
	}
	
	public void Water()
	{
		clicked = true;
		Debug.Log("clicked");
		cursor = cursorDig;	
	}
	
	public void Harvest()
	{
		clicked = true;
		Debug.Log("clicked");
		cursor = cursorDig;	
	}
	
	public void Store()
	{
		clicked = true;
		Debug.Log("clicked");
		cursor = cursorDig;	
	}
}
