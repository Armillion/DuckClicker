using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public string password;
    public bool solved = false;
    public Upgrade upgrade;
    public Vector2 coords;

    public Sprite before;
    public Sprite after;
}
