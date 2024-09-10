using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaysDrop : MonoBehaviour
{

    Dropdown dayDropdown;
    public Dropdown monthDropdown;
    List<string> dayOptions = new List<string>();


    public void Start()
    {
        SetDay();
    }

    public void SetDay()
    {
        dayDropdown = GetComponent<Dropdown>();
        dayDropdown.ClearOptions();
        switch (monthDropdown.value)
        {
            case 0:
            case 2:
            case 4:
            case 6:
            case 7:
            case 9:
            case 11:
                for (int i = 1; i <= 31; i++)
                {
                    dayOptions.Add(i.ToString());
                }
                break;
            case 3:
            case 5:
            case 8:
            case 10:
                for (int i = 1; i <= 30; i++)
                {
                    dayOptions.Add(i.ToString());
                }
                break;
            case 1:
                for (int i = 1; i <= 28; i++)
                {
                    dayOptions.Add(i.ToString());
                }
                break;
            default:
                break;
        }
        dayDropdown.AddOptions(dayOptions);
        dayDropdown.RefreshShownValue();
    }
}
