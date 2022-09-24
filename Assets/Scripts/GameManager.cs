using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public bool gameStarted = false;

    public GameObject[] rooms;
    public GameObject[] UICanvases;

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
        }
    }
}
