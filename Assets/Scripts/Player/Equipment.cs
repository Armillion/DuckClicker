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
            if (items[i] != null)
            {
                prefabs[i].GetComponent<Image>().sprite = items[i].sprite;
                int j = i;
                prefabs[i].GetComponent<Button>().onClick.RemoveAllListeners();
                prefabs[i].GetComponent<Button>().onClick.AddListener(() => onClick(j));
            }
            else
            {
                prefabs[i].GetComponent<Button>().onClick.RemoveAllListeners();
                prefabs[i].GetComponent<Image>().sprite = null;
            }
        }
    }

    public void onClick(int id)
    {
        
    }


    private void Update()
    {
        updateInventory();
    }
}
