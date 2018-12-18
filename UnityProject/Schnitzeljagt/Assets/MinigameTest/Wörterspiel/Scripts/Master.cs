﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Master : MonoBehaviour
{

    public GameObject Sprechfeld;
    
    private float timer;
    private Transform ThrowingObject;
    private float randTimer;
    public Truhe Truhe;
    public Hoelderlin Hoelderlin;

    public SpriteRenderer FadeScreen;
    public GameObject EndScreen;

    private bool gameOver;
    

    void Start()
    {
        Vector2 position = new Vector2(Random.Range(-25.0f, 25.0f), 14.3f);
        //Instantiate(Sprechfeld, position, Quaternion.identity);
        randTimer = 1;
        ThrowingObject = GameObject.Find("shoutingMonkey").transform;
    }

    void Update()
    {
        Vector2 position;
        if (ThrowingObject == null)
            position = new Vector2(Random.Range(-15.0f, 15.0f), 14.3f);
        else
            position = ThrowingObject.position;
        if (!gameOver && timer > randTimer)
        {
            timer = 0;

            float randNumber = Random.Range(0.0f, 100.0f);
            var spr = Instantiate(Sprechfeld, position, Quaternion.identity).GetComponent<Sprechblase>();
            spr.TruhenWords = Truhe.UsedWords;
            Truhe.ExistingSpeechBubbles.Add(spr.transform);
            spr.GetComponent<Rigidbody2D>().gravityScale = 0;
            Hoelderlin.StartThrowing();
            Hoelderlin.SpeechBubble = spr.transform;
            randTimer = Random.Range(3f, 5f);
        }

        if(!gameOver && Truhe.UsedWords.Count >= 6)
        {
            gameOver = true;
            Hoelderlin.enabled = false;
            Truhe.enabled = false;
            StartCoroutine(EndGame());
        }

        timer += Time.deltaTime;
    }

    private IEnumerator EndGame()
    { 
        for(int i = 0; i < 100; i++)
        {
            FadeScreen.color = new Color(0, 0, 0, FadeScreen.color.a + 1 / 150f);
            yield return null;
        }
        var text = Instantiate(EndScreen, Vector3.zero, Quaternion.identity).GetComponentInChildren<Text>();
        text.text = "Hurra du hast gewonnen! \n Der coole Satz ist cool! \n " + Truhe.PointsText.text;
    }

}
