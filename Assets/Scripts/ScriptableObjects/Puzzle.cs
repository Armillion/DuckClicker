using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Puzzle", menuName = "Puzzles/Puzzle", order = 1)]
public class Puzzle : ScriptableObject
{
    public string password;

    public bool solved = false;
    public Upgrade upgrade;
    public Vector2 coords;

    public Sprite before;
    public Sprite after;
}
