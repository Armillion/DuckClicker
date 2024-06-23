using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Transform parent;
    private Vector3 pos;
    public string password;

    private void Start()
    {
        parent = transform.parent;
        pos = transform.localPosition;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Chceck if collision is with puzzle and act appropiatly
        var puzzle = collision.GetComponent<PuzzleUI>();
        if (puzzle != null) 
        {
            if(password == puzzle.puzzle.password)
            {
                GameObject.FindObjectOfType<clicker>().solvePuzzle(puzzle.puzzle);
                Destroy(gameObject);
            }
        }
    }

    public void stop()
    {
        transform.position = pos;
        transform.SetParent(parent,false);
        transform.SetSiblingIndex(0);
    }
}
