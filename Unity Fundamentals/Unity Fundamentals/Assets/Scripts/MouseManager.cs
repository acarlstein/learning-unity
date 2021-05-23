using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class MouseManager : MonoBehaviour
{

    // 1. Know what Objects are clickable
    
    // Making it public so we can edit it with the editor
    public LayerMask clickableLayer;


    // 2. Swap cursors per object. 
    //   What the cursor looks like if we are not able to click anything,
    //   when we wish to click on a doorway, on an item, the world or enemy?
    public Texture2D pointer; // Normal pointer,  when we can't click on anything.
    public Texture2D target;  // Cursor for clickable objects like the world
    public Texture2D doorway; // Cursor for doorway
    public Texture2D combat;  // Cursor for combat actions

    public EventsVector3 onClickEnvironment;

    // 3. We want to be able to have our mouse hover over an object
    // and tell if its clickable or not.
    private RaycastHit hit;

    private enum GameObjectSelected
    {
        None, Doorway, Item, World
    }

    private GameObjectSelected gameObjectSelected;

    // Update is called once per frame
    void Update()
    {
        changeCursorIfClickable();
        doMouseAction();
    }

    private void changeCursorIfClickable()
    {

        var origin = Camera.main.ScreenPointToRay(Input.mousePosition);
        int lengthOfTheRay = 50; //Max distance

        // Check our mouse interactions
        if (Physics.Raycast(origin, out hit, lengthOfTheRay, clickableLayer.value))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "Doorway":
                    Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                    gameObjectSelected = GameObjectSelected.Doorway;
                    break;
                case "Item":
                    Cursor.SetCursor(combat, new Vector2(16, 16), CursorMode.Auto);
                    gameObjectSelected = GameObjectSelected.Item;
                    break;
                default:
                    // Using target because we want to check in the world
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    gameObjectSelected = GameObjectSelected.World;
                    break;
            }
        }
        else
        {
            // If anything is not clickable, set the cursor mode to the normal cursor `pointer`
            // We use Vector2.zero because there's no hotspot for it.
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
            gameObjectSelected = GameObjectSelected.None;
        }
    }

    private void doMouseAction()
    {
        int leftButtonIndex = 0;
        if (Input.GetMouseButtonDown(leftButtonIndex))
        {
            switch (gameObjectSelected)
            {
                case GameObjectSelected.Doorway:
                    Debug.Log("Click Doorway");
                    Transform transformDoorway = hit.collider.gameObject.transform;
                    //onClickEnvironment.Invoke(transformDoorway.position);
                    onClickEnvironment.Invoke(transformDoorway.position + transform.forward * 10);
                    break;
                case GameObjectSelected.Item:
                    Debug.Log("Click Item");
                    Transform transformItem = hit.collider.gameObject.transform;
                    onClickEnvironment.Invoke(transformItem.position);
                    break;
                case GameObjectSelected.World:
                    Debug.Log("Click World");
                    onClickEnvironment.Invoke(hit.point);
                    break;
                default:
                    Debug.Log("Click nothing");
                    break;
            }
        }
    }
}


[System.Serializable]
public class EventsVector3 : UnityEvent<Vector3>
{
}