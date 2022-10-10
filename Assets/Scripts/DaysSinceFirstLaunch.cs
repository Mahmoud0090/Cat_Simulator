using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaysSinceFirstLaunch : MonoBehaviour
{
    System.DateTime startDate;
    System.DateTime today;

    private void Awake()
    {
        SetStartDate();
    }

    public void SetStartDate()
    {
        if (PlayerPrefs.HasKey("StartDate"))
        {
            startDate =  System.Convert.ToDateTime(PlayerPrefs.GetString("StartDate"));
        }
        else
        {
            startDate = System.DateTime.Now;
            PlayerPrefs.SetString("StartDate", startDate.ToString());
        }

        PlayerPrefs.SetInt("DaysPlayed", GetDaysPlayed());
    }

    public int GetDaysPlayed()
    {
        today = System.DateTime.Now;
        System.TimeSpan elapsed = today.Subtract(startDate);
        double days = elapsed.TotalDays;
        return int.Parse(days.ToString("0"));
    }
}
