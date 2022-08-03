using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStartCounter : MonoBehaviour
{
    public TextMeshProUGUI gameStartCounter;
    public GameManager gameManager;
    public Timer timer;
    private float deltaTime;
    private int count = 3;
    void Start()
    {
        gameStartCounter = GetComponent<TextMeshProUGUI>();
        timer = FindObjectOfType<Timer>();
    }
    void Update()
    {
        StartCoroutine(IGameStartCounter());
    }

    private IEnumerator IGameStartCounter()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= 1.0f)
        {
            deltaTime = 0;
            if (count <= 0 )
            {
                gameStartCounter.text = $"Start!";
                yield return new WaitForSeconds(1.5f);
                // 게임 매니저의 독수리, 조준경, 타이머 활성화
                gameManager = FindObjectOfType<GameManager>();
                gameManager.GameObjectTrue();
                timer.enabled = true;
                // 자신 게임 오브젝트 비활성화
                gameObject.SetActive(false);
            }    
            gameStartCounter.text = count.ToString();
            count--;
        }
    }
    
}
