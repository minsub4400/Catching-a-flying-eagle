using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private GameManager gameManager;

    // ���콺�� Ŭ�� �Ǿ��°�?
    private bool isMouseClick;

    private void Start()
    {
        isMouseClick = false;
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0))
        {
            isMouseClick = true;
        }

        if (collision.tag == "SelectCursor" && isMouseClick)
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.isGame = true;
        } 
    }
}
