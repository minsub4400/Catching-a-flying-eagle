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
                // ���� �Ŵ����� ������, ���ذ�, Ÿ�̸� Ȱ��ȭ
                gameManager = FindObjectOfType<GameManager>();
                gameManager.GameObjectTrue();
                timer.enabled = true;
                // �ڽ� ���� ������Ʈ ��Ȱ��ȭ
                gameObject.SetActive(false);
            }    
            gameStartCounter.text = count.ToString();
            count--;
        }
    }
    
}
