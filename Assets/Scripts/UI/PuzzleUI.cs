using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleUI : MonoBehaviour
{
    public Image Image;

    public Puzzle puzzle;

    private void Awake()
    {
        updateImage();
    }

    public void updateImage()
    {
        if (puzzle.solved)
            Image.sprite = puzzle.after;
        else
            Image.sprite = puzzle.before;
    }
}
