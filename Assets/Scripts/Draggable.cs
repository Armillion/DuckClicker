using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Transform parent;
    private Vector3 pos;

    private void Start()
    {
        parent = transform.parent;
        pos = transform.localPosition;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Chceck if collision is with puzzle and act appropiatly
    }

    public void stop()
    {
        transform.position = pos;
        transform.parent = parent;
    }
}
