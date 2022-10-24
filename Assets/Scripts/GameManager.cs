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
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScoreFinal;
    public TextMeshProUGUI bestScore;
    public AIPlayer[] aIPlayers;
    public TextMeshProUGUI[] finalScoresText;
    public string[] finalScores;

    private void Awake()
    {
        for(int i = 1; i<=rooms.Length; i++)
        {
            if(i<= level)
            {
                rooms[i-1].SetActive(true);
            }
        }
        bestScore.text = "Best: " + PlayerPrefs.GetInt("maxScore", 0);
    }
    private void Update()
    {
        
    }
    public void StartGame()
    {
        gameStarted = true;
        UICanvases[0].SetActive(false);
        InvokeRepeating("SetTimer", 1, 1);
        foreach(AIPlayer ai in aIPlayers)
        {
            ai.StartGame();
        }
    }

    public void SetTimer()
    {
        timerVal--;
        textTimer.text = timerVal.ToString();
        if (timerVal == 0)
        {
            gameEnded = true;
            CancelInvoke();
            screenEnd.SetActive(true);
            textScoreFinal.text = "Score: " + textScore.text;

            finalScores[0] = "Player 1 : " + textScore.text;
            finalScores[1] = aIPlayers[0].gameObject.name + " : " + aIPlayers[0].score;
            finalScores[2] = aIPlayers[1].gameObject.name + " : " + aIPlayers[1].score;

            for (int i = 0; i <= 2; i++)
            {
                finalScoresText[i].text = finalScores[i];
            }
        } 
    }

    public void RestartGame()
    {
        int actualScore = int.Parse(textScore.text);
        int maxScore = PlayerPrefs.GetInt("maxScore",0);
        if (actualScore > maxScore)
        {
            PlayerPrefs.SetInt("maxScore",actualScore);
        }
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
        timerVal = 5 + PlayerPrefs.GetInt("timeLevel" , 1);
        textTimer.text = timerVal.ToString();
        InvokeRepeating("SetTimer", 1, 1);
        gameEnded = false;
        screenEnd.SetActive(false);
    }
}
