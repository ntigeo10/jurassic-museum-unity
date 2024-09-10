using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthDrop: MonoBehaviour
{    
    Dropdown monthDropdown;    
    List<string> monthOptions = new List<string>();
    void Start()
    {
        setMonth();
    }

    public void setMonth()
    {
        monthDropdown = GetComponent<Dropdown>();
        monthDropdown.ClearOptions();
        for (int i = 1; i <= 12; i++)
        {
            monthOptions.Add(i.ToString());
        }
        monthDropdown.AddOptions(monthOptions);
    }

    
}
