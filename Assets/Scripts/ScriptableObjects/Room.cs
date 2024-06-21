using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "Room", order = 1)]
public class Room : ScriptableObject
{
    public List<Puzzle> puzzles;
    public List<Item> items;

    public Sprite Image;
}
