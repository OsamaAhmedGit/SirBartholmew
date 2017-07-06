using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {

    public Texture2D texture;

    public CursorMode cursorMode = CursorMode.Auto;

    public Vector2 hotSpot = Vector2.zero;

    public int cursorSize;

    private int sizeX, sizeY;


    void Awake()
    {
        sizeX = cursorSize;
        sizeY = cursorSize;
    }

    // Use this for initialization
    void Start () {

        //Cursor.SetCursor(texture, hotSpot, cursorMode);

        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        sizeX = cursorSize;
        sizeY = cursorSize;
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x - (cursorSize / 2), Event.current.mousePosition.y - (cursorSize / 2), sizeX, sizeY), texture);
    }
}
