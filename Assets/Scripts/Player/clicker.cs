using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class clicker : MonoBehaviour
{
    public class UpgradeButton
    {
        public string lvl;
        public string perS;
        public Image image;
        public Button button;
    }

    public ulong currentAmount = 0;

    public int perClick = 1;
    int toAdd = 0;

    [SerializeField] private List<Upgrade> upgrades = new List<Upgrade>();
    [SerializeField] private List<GameObject> upgradeUI = new List<GameObject>();
    [SerializeField] private List<Ending> endings = new List<Ending>();
    [SerializeField] private List<GameObject> endingUI = new List<GameObject>();
    [SerializeField] private Equipment equipment;
    [SerializeField] private GameObject currentRoom;

    //UI
    [SerializeField] private GameObject upgradePrefab;
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject endingPrefab;
    //[SerializeField] private GameObject puzzlePrefab;


    [SerializeField] private GameObject upgradeSlot;
    [SerializeField] private GameObject endingSlot;
    [SerializeField] private TMPro.TextMeshProUGUI Resource;
    [SerializeField] private Transform roomParent;
    [SerializeField] private GameObject endingScreen;

    //Animators
    [SerializeField] private Animator inventoryAnimator;
    [SerializeField] private Animator upgradesAnimator;
    public RoomUI roomUI;

    public static clicker _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }

        buildUpgradeUI();
        buildEndingUI();
    }

    public void click()
    {
        currentAmount += (ulong)(perClick);
    }

    private void Update()
    {
        Resource.text = currentAmount.ToString();

        foreach(Upgrade upgrade in upgrades)
        {
            toAdd += (int)(upgrade.amount * upgrade.realTiemeBonus);
        }

        if (toAdd * Time.deltaTime > 1f)
        {
            currentAmount += (ulong)(toAdd*Time.deltaTime);
            toAdd = 0;
        }
    }

    private void applyUpgrade(Upgrade upgrade)
    {
        if (upgrade.unlocked && currentAmount >= (ulong)upgrade.cost)
        {
            upgrade.amount++;
            currentAmount -= (ulong)upgrade.cost;
            upgrade.cost *= 2;
        }

        updateUpgradeUI();
    }

    private void buildEndingUI()
    {
        foreach (Ending end in endings)
        {
            var a = Instantiate(endingPrefab, endingSlot.transform);
            endingUI.Add(a);
        }

        updateEndingUI();

        for (int i = 0; i < endings.Count; i++)
        {
            int index = i;
            var ui = endingUI[index].GetComponent<EndingUI>();

            ui.flavorText.text = endings[index].flavorText;

            ui.image.sprite = endings[index].image;
        }
    }

    private void updateEndingUI()
    {
        for (int i = 0; i < endings.Count; i++)
        {
            int index = i;
            var ui = endingUI[index].GetComponent<EndingUI>();

            if (ui) Debug.Log(index);

            ui.image.sprite = endings[index].image;
            ui.flavorText.text = endings[index].flavorText;
        }
    }

    private void buildUpgradeUI()
    {
        foreach(Upgrade up in upgrades)
        {
            var a = Instantiate(upgradePrefab, upgradeSlot.transform);
            upgradeUI.Add(a);
        }

        updateUpgradeUI();

        for (int i = 0; i < upgrades.Count; i++)
        {
            int index = i;
            var ui = upgradeUI[index].GetComponent<UpgradeUI>();

            ui.room = upgrades[index].room;

            ui.enterButton.onClick.AddListener(() => enterUpgrade(upgrades[index]));

            ui.applyButton.onClick.AddListener(() => applyUpgrade(upgrades[index]));
        }
    }

    private void updateUpgradeUI()
    {
        for (int i = 0; i < upgrades.Count; i++)
        {
            int index = i;
            var ui = upgradeUI[index].GetComponent<UpgradeUI>();

            ui.sprite.sprite = upgrades[index].Image;
            
            ui.lvl.text = upgrades[index].amount.ToString() + " lvl";
            ui.perS.text = (upgrades[index].realTiemeBonus * upgrades[i].amount).ToString() + " /s";
            ui.cost.text = upgrades[index].cost.ToString();

            upgradeUI[index].SetActive(upgrades[index].unlocked); 
        }
    }


    private void enterUpgrade(Upgrade upgrade)
    {
        upgradesAnimator.SetTrigger("Close");
        var room = Instantiate(roomPrefab, roomParent);
        Debug.Log(room);
        currentRoom = room;
        roomUI = room.GetComponent<RoomUI>();
        Debug.Log(roomUI);
        roomUI.image.sprite = upgrade.room.Image;

        // trigger animacji pokoju
        for (int i = 0; i < upgrade.room.items.Count; i++)
        {
            var current = i;
            var a = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, room.transform);
            a.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width * upgrade.room.items[current].coords.x, Screen.height * upgrade.room.items[current].coords.y);
            var itemek = a.GetComponent<ItemUI>();
            itemek.image.sprite = upgrade.room.items[current].sprite;
            itemek.button.onClick.AddListener(() => pickUpItem(upgrade.room.items[current], upgrade.room, a));
        }

        for (int i = 0; i < upgrade.room.items.Count; i++)
        {
            //Instantiate(puzzlePrefab, upgrade.room.items[i].coords, Quaternion.identity, room.transform);
        }
    }

    private void exitUpgrade()
    {
        if (currentRoom != null)
        {
            Destroy(currentRoom);
        }
        currentRoom = null;
        //animacja zamkniecia pokoju
    }

    public void openInventory()
    {
        inventoryAnimator.SetTrigger("Open");
    }

    public void closeInventory()
    {
        inventoryAnimator.SetTrigger("Close");
    }

    public void openUpgrades()
    {
        upgradesAnimator.SetTrigger("Open");
    }


    public void closeUpgrades()
    {
        upgradesAnimator.SetTrigger("Close");
    }

    public void pickUpItem(Item item, Room room, GameObject itemek)
    {
        equipment.items.Add(item);
        room.items.Remove(item);
        itemek.GetComponent<Button>().onClick.RemoveAllListeners();
        Destroy(itemek);
    }

    public void solvePuzzle(Puzzle puzzle)
    {
        puzzle.solved = true;
        puzzle.upgrade.unlocked = true;
        updateUpgradeUI();
    }

    public void endingActive()
    {
        endingScreen.SetActive(!endingScreen.activeInHierarchy);
    }
}
