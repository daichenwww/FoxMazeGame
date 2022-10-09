using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameOverCanvas : MonoBehaviour
{
    // public TextMeshProUGUI timerUI; 
    public TextMeshProUGUI timeText; 
    
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = GameObject.FindObjectOfType<gameOver>().timerUI.text;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
