using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade", order = 1)]
public class Upgrade : ScriptableObject
{
    public float realTiemeBonus = 0;

    public int amount = 0;
    public int cost = 0;
    public bool unlocked = false;

    public Sprite Image;
}
