﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthyhealth : MonoBehaviour {

//
    public GameObject heart1, heart2, heart3, star1, star2, star3, gameOver;
    public static int health, stars;

	void Start () {
        health = 3;
        stars = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(true);
        star3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        switch (health) {
        case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                gameOver.gameObject.SetActive(false);
                break;
        case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(false);
                break;
        case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(false);
                break;
        case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                if (stars == 0)
                {
                    break;
                }
                gameOver.gameObject.SetActive(true);
                break;
        }
		
	}
}
