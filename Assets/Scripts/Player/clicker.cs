using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clicker : MonoBehaviour
{
    public ulong currentAmount = 0;

    public int perClick = 1;

    [SerializeField] private List<Upgrade> upgrades = new List<Upgrade>();
    [SerializeField] private List<GameObject> upgradeUI = new List<GameObject>();

    [SerializeField] private GameObject upgradePrefab;
    [SerializeField] private GameObject upgradeSlot;

    private void Awake()
    {
        buildUpgradeUI();
    }

    public void click()
    {
        int toAdd = (int)(perClick);
    }

    private void Update()
    {
        foreach(Upgrade upgrade in upgrades)
        {
            currentAmount += (ulong)(upgrade.amount * upgrade.realTiemeBonus);
        }
    }

    private void applyUpgrade(Upgrade upgrade)
    {
        upgrade.amount++;

        updateUpgradeUI();
    }

    private void buildUpgradeUI()
    {
        foreach(Upgrade up in upgrades)
        {
            var a = Instantiate(upgradePrefab, upgradeSlot.transform);
            upgradeUI.Add(a);
        }

        for(int i = 0; i < upgrades.Count; i++ )
        {
            foreach(Transform child in upgradeUI[i].transform)
            {
                if (child.gameObject.TryGetComponent<TMPro.TextMeshProUGUI>(out var comp1) && child.name == "Level")
                {
                    comp1.text = upgrades[i].amount.ToString() + " lvl";
                }
                else if (child.gameObject.TryGetComponent<TMPro.TextMeshProUGUI>(out var comp2) && child.name == "perS")
                {
                    comp2.text = (upgrades[i].amount * upgrades[i].realTiemeBonus).ToString() + " /s";
                }
                else if (child.gameObject.TryGetComponent<Image>(out var comp3) && child.name == "Image")
                {
                    int index = i;
                    Debug.Log("nigga");
                    comp3.sprite = upgrades[index].Image;
                    child.gameObject.GetComponent<Button>().onClick.AddListener(() => enterUpgrade(upgrades[index]));
                }
                else if (child.gameObject.TryGetComponent<Button>(out var comp4) && child.name != "Image")
                {
                    int index = i;
                    comp4.onClick.AddListener(() => applyUpgrade(upgrades[index]));
                }
            }
        }
    }

    private void updateUpgradeUI()
    {
        for (int i = 0; i < upgrades.Count; i++)
        {
            foreach (Transform child in upgradeUI[i].transform)
            {
                if (child.gameObject.TryGetComponent<TMPro.TextMeshProUGUI>(out var comp1) && child.name == "Level")
                {
                    comp1.text = upgrades[i].amount.ToString() + " lvl";
                }
                else if (child.gameObject.TryGetComponent<TMPro.TextMeshProUGUI>(out var comp2) && child.name == "perS")
                {
                    comp2.text = (upgrades[i].amount * upgrades[i].realTiemeBonus).ToString() + " /s";
                }
            }
        }
    }

    //TODO: Michal ogarnie
    private void enterUpgrade(Upgrade upgrade)
    {
        Debug.Log("nigga");
    }
}
