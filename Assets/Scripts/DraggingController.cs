using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingController : MonoBehaviour
{
    private bool isDragging = false;

    private Vector2 screenPos;
    private Vector3 worldPos;
        
    private Draggable lastDragged;

    private void Awake()
    {
        DraggingController[] controllers = FindObjectsOfType<DraggingController>();
        if (controllers.Length > 1)
            Destroy(this);
    }

    void Update()
    {
        if (isDragging && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            drop();
            return;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPos = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            screenPos = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        if(isDragging)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            
            if(hit.collider != null)
            {
                Debug.Log(hit.transform.gameObject.name);
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    lastDragged = draggable;
                    hit.transform.parent = null;
                    initDrag();
                }
            }
        }
    }

    private void initDrag()
    {
        isDragging = true;
    }

    private void Drag()
    {
        lastDragged.transform.position = new Vector2(worldPos.z, worldPos.y);
    }

    private void drop()
    {
        isDragging = false;
        lastDragged.stop();
    }
}
