using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public List<Item> items;
    public int backpackSize;
    public int itemCnt = 0;

    //UI
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private GameObject invPanel;
    [SerializeField] private List<GameObject> prefabs;

    private void Awake()
    {
        items = new List<Item>();

        for(int i = 0; i < backpackSize; i++ )
        {
            items.Add(null);
            GameObject a = Instantiate(itemSlotPrefab, invPanel.transform);
            prefabs.Add( a );
        }
    }


    public void updateInventory()
    {
        for(int i = 0; i < backpackSize; i++)
        {
            if (!prefabs[i])
                continue;

            var a = prefabs[i].GetComponent<ItemslotUI>();

            if (items[i] != null)
            {
                a.sprite.sprite = items[i].sprite;
                a.sprite.raycastTarget = true;
                a.draggable.password = items[i].password;
            }
            else
            {
                a.sprite.sprite = null;
                a.draggable.password = "";  
                a.sprite.raycastTarget = false;
            }
        }
    }

    private void Update()
    {
        updateInventory();
    }
}
