using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObject : MonoBehaviour
{
    public int points = 50;
    public int coins;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("coinsLevel", 1);
    }
}
