using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicker : MonoBehaviour
{
    public int currentAmount = 0;

    public int perClick = 1;
    public float perSecond = 0f;

    public float clickMultiplier = 1f;
    public float realtimeMultiplier = 1f;
    public float allMultiplier = 1f;

    public float criticalMultiplier = 2f;
    public float criticalChance = 2f;

    private float cnterToAdd = 0;

    public void click()
    {
        int toAdd = (int)(perClick*allMultiplier*clickMultiplier);

        if (Random.Range(0, 100) < criticalChance)
            toAdd = (int)(toAdd*criticalMultiplier);
    }

    private void Update()
    {
        cnterToAdd += perSecond * allMultiplier * realtimeMultiplier * Time.deltaTime;
        
        if(cnterToAdd > 1)
        {
            currentAmount += (int)cnterToAdd;
            cnterToAdd = 0;
        }
    }

    public void applyUpgrade(Upgrade upgrade)
    {
        perClick += upgrade.perClick;
        perSecond += upgrade.perSecond;

        clickMultiplier += upgrade.clickMultiplier;
        realtimeMultiplier += upgrade.realtimeMultiplier;
        allMultiplier += upgrade.allMultiplier;

        criticalMultiplier += upgrade.criticalMultiplier;
        criticalChance += upgrade.criticalChance;
    }
}
