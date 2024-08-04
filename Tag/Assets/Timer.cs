using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public GameManager gameManager;

    public TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = string.Format("{0:00}:{01:00}", Mathf.Floor(gameManager.timer / 60), Mathf.Floor(gameManager.timer % 60));
    }
}
