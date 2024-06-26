using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Puzzles/Item", order = 1)]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public Vector2 coords;

    //If passwords of item and puzzle match the puzzle is solved
    public string password;
}
