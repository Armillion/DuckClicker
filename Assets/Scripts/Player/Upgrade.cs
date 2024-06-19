using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrade", order = 1)]
public class Upgrade : ScriptableObject
{
    public int perClick = 0;
    public float perSecond = 0f;

    public float clickMultiplier = 0f;
    public float realtimeMultiplier = 0f;
    public float allMultiplier = 0f;

    public float criticalMultiplier = 0f;
    public float criticalChance = 0f;

    [TextArea]
    public string description;
    public Sprite Image;
}
