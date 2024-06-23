using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UICollisionMenager : MonoBehaviour
{
    public static UICollisionMenager _instance;

    public List<UICollision> uIs;

    public static EventHandler<GameObject> onCollision;

    // Start is called before the first frame update
    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(UICollision b in uIs) 
        { 
            foreach(UICollision a in uIs)
            {
                if (a == b)
                {
                    continue;
                }

                if(GetWorldRect(a.rect).Overlaps(GetWorldRect(b.rect)))
                {
                    onCollision?.Invoke(this,a.gameObject);
                }
            }
        }
    }

    private Rect GetWorldRect(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        Vector2 bottomLeft = corners[0];
        Vector2 topRight = corners[2];

        return new Rect(bottomLeft, topRight - bottomLeft);
    }
}
