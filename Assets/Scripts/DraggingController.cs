using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggingController : MonoBehaviour
{
    private bool isDragging = false;

    private Vector2 screenPos;
        
    private Draggable lastDragged;

    //for ui raycasting
    [SerializeField] private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    [SerializeField] private EventSystem m_EventSystem;
    [SerializeField] private Transform draggingParent;

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

        if(isDragging)
        {
            Drag();
        }
        else
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                Draggable draggable = result.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    lastDragged = draggable;
                    result.gameObject.transform.SetParent(draggingParent,false);
                    
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
        if(lastDragged)
            lastDragged.transform.position = screenPos;
    }

    private void drop()
    {
        isDragging = false;

        if(lastDragged)
            lastDragged.stop();
    }
}
