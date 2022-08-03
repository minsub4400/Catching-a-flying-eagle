using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI score;

    private int whiteEagleScore = 100;
    private int blackEagleScore = 150;
    private int baldEagleScore = -100;
    private int goldEagleScore = 200;
    private int resultScore;

    public bool isWhiteEagle = false;
    public bool isBlackEagle = false;
    public bool isBaldEagle = false;
    public bool isGoldEagle = false;


    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        resultScore = 0;
    }

    void Update()
    {
        score.text = resultScore.ToString();
    }

    public void AddScore()
    {
        if (isWhiteEagle)
        {
            resultScore += whiteEagleScore;
            isWhiteEagle = false;
        }
        else if (isBlackEagle)
        {
            resultScore += blackEagleScore;
            isBlackEagle = false;
        }
        else if (isBaldEagle)
        {
            resultScore += baldEagleScore;
            isBaldEagle = false;
        }
        else if (isGoldEagle)
        {
            resultScore += goldEagleScore;
            isGoldEagle = false;
        }
    }
}
