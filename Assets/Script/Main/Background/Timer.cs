using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private GameManager gameManager;
    private TextMeshProUGUI secondTimer;
    public float secondTime = 50f;
    private float deltaTime;

    void Start()
    {
        secondTimer = GetComponent<TextMeshProUGUI>();
        secondTimer.text = secondTime.ToString();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= 1.0f)
        {
            deltaTime = 0;
            secondTime--;
            secondTimer.text = secondTime.ToString();
            //Debug.Log(secondTime);
            if (secondTime <= 0)
            {
                secondTime = 0;
                secondTimer.text = secondTime.ToString();
                StartCoroutine(gameManager.GameOver());
            }
        }
    }

}
