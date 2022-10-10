using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI nbCoinsText;
    int playerNbCoins;

    int initialPrice = 10;
    int coinsLevel;
    int coinsActualPrice;
    public TextMeshProUGUI coinsPriceText;
    public TextMeshProUGUI coinsLevelText;

    private void Awake()
    {
        playerNbCoins = PlayerPrefs.GetInt("nbCoins", 0);
        nbCoinsText.text = playerNbCoins.ToString();
        coinsLevel = PlayerPrefs.GetInt("coinsLevel", 1);
        coinsActualPrice = initialPrice * coinsLevel;
        coinsPriceText.text = coinsActualPrice + "PO";
        coinsLevelText.text = "LEVEL " + PlayerPrefs.GetInt("coinsLevel", 1);
    }

    public void IncreaseCoinLevel()
    {
        if(playerNbCoins >= coinsActualPrice)
        {
            playerNbCoins -= coinsActualPrice;
            PlayerPrefs.SetInt("nbCoins", playerNbCoins);
            nbCoinsText.text = playerNbCoins.ToString();
            PlayerPrefs.SetInt("coinsLevel", PlayerPrefs.GetInt("coinsLevel", 1) + 1);
            coinsLevelText.text = "LEVEL " + PlayerPrefs.GetInt("coinsLevel", 1);
            coinsActualPrice = initialPrice * coinsLevel;
            coinsPriceText.text = coinsActualPrice + "PO";
        }
    }

    public void IncreaseSpeedLevel()
    {
        //TODO
    }

    public void IncreaseTimeLevel()
    {
        //TODO
    }
}
