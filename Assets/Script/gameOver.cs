 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameOver : MonoBehaviour
{
    public TextMeshProUGUI timerUI; 
    public GameObject gameOverCanvas;
    public GameObject gameWinCanvas;

    private int timeValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeValue = 0;
        Time.timeScale = 1f;
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.name.Contains("Burrow")) {
            Dead();
        }
        if (other.gameObject.name == "the END") {
            Win();
        }
    }
    
    void Timer() {  
        
            TimeSpan spanTime = TimeSpan.FromSeconds(timeValue);  
            if (spanTime.Minutes < 10)
            timerUI.text = "Time: " + spanTime.Minutes.ToString().PadLeft(2, '0') + ":" + spanTime.Seconds.ToString().PadLeft(2, '0');  
            timeValue++;  
            Invoke("Timer", 1.0f);  
         
    } 
    void Dead() {
        Destroy(GetComponentInChildren(typeof(Canvas)).GetComponentInChildren(typeof(RawImage)));
        Destroy(GetComponentInChildren(typeof(Canvas)).GetComponentInChildren(typeof(TextMeshProUGUI)));
        Instantiate(gameOverCanvas, Vector2.zero, Quaternion.identity);
        Time.timeScale = 0f;
    }
    void Win(){
        Destroy(GetComponentInChildren(typeof(Canvas)).GetComponentInChildren(typeof(RawImage)));
        Destroy(GetComponentInChildren(typeof(Canvas)).GetComponentInChildren(typeof(TextMeshProUGUI)));
        Instantiate(gameWinCanvas, Vector2.zero, Quaternion.identity);
        Time.timeScale = 0f;
    }
}

