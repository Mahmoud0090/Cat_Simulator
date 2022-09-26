using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public bool gameStarted = false;
    public bool gameEnded = false;
    public GameObject[] rooms;
    public GameObject[] UICanvases;
    public GameObject screenEnd;
    public int timerVal = 30;
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        for(int i = 1; i<=rooms.Length; i++)
        {
            if(i<= level)
            {
                rooms[i-1].SetActive(true);
            }
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            UICanvases[0].SetActive(false);
            InvokeRepeating("SetTimer", 1, 1);
        }
    }

    public void SetTimer()
    {
        timerVal--;
        if (timerVal == 0)
        {
            gameEnded = true;
            CancelInvoke();
            screenEnd.SetActive(true);
        }
        timerText.text = timerVal.ToString();
    }

    public void RestartGame()
    {
        timerVal = 30;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WatchExtraTimeVideo()
    {
        // display video
        GetExtraTime();
    }

    public void GetExtraTime()
    {
        timerVal = 5;
        timerText.text = timerVal.ToString();
        InvokeRepeating("SetTimer", 1, 1);
        gameEnded = false;
        screenEnd.SetActive(false);
    }
}
