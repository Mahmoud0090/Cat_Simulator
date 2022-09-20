using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Obstacle : MonoBehaviour
{
    public float speed = 10f;
    public TextMeshProUGUI text;
    public GameObject winParticle;
    public Transform winParticlePos;
    public GameObject loseParticle;


    void Start()
    {
        try
        {
            winParticlePos = GameObject.Find("WinParticlePos").transform;
        }

        catch(Exception e)
        {
            print(e.Message);
        }
       
        text = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Instantiate(loseParticle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Invoke("ReloadScene", 2);
        }
        if(collision.gameObject.name == "Out")
        {
            if (winParticlePos == null)
            {
                ReloadScene();
                return;
            }
            Instantiate(winParticle, winParticlePos.position, Quaternion.identity);
            int newScore = int.Parse(text.text) + 1;
            text.text = newScore.ToString();
            Destroy(gameObject);
        }

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
