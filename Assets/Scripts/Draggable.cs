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

    private void OnEnable()
    {
        UICollisionMenager.onCollision += attemptToSolve;
    }

    private void OnDisable()
    {
        UICollisionMenager.onCollision -= attemptToSolve;
    }

    private void attemptToSolve(object sender, GameObject collider)
    {
        //Chceck if collision is with puzzle and act appropiatly
        var puzzle = collider.GetComponent<PuzzleUI>();
        if (puzzle != null) 
        {
            Debug.Log("moc nigas");
            if(password == puzzle.puzzle.password)
            {
                clicker._instance.solvePuzzle(puzzle.puzzle);
                puzzle.updateImage();
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
