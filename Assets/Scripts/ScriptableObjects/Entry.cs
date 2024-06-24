using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entry", menuName = "Entry", order = 1)]
public class Entry : ScriptableObject
{
    public int placement;
    public string name;
    public int score;
}
