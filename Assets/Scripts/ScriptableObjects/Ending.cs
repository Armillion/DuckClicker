using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ending", menuName = "Ending", order = 1)]
public class Ending : ScriptableObject
{
    public bool unlocked = false;
    public Upgrade ending;
    public string flavorText;
    public Sprite image;
}
