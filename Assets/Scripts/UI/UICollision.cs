using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollision : MonoBehaviour
{
    public RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        UICollisionMenager._instance.uIs.Add(this);
        rect = GetComponent<RectTransform>();
    }

    private void OnDestroy()
    {
        UICollisionMenager._instance.uIs.Remove(this);
    }
}
