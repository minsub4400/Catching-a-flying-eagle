using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 커서 이미지
    public RectTransform cursorImage;

    // 게임 시작 버튼이 눌렸는지 확인 변수
    public bool isGame;

    // 타이틀 게임 음악
    // 버튼 소리 이펙트

    void Start()
    {
        isGame = false;
        Init_Cursor();
    }

    void Update()
    {
        // Main Scene 호출
        if (isGame)
        {
            SceneManager.LoadScene(0);
        }

        // 커서 이미지
        Update_MousePosition();
    }
    private void Init_Cursor()
    {
        Cursor.visible = false;
        cursorImage.pivot = Vector2.up;
        if (cursorImage.GetComponent<Graphic>())
            cursorImage.GetComponent<Graphic>().raycastTarget = false;
    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        cursorImage.transform.position = mousePos;
/*        float w = cursorImage2.rect.width;
        float h = cursorImage2.rect.height;
        cursorImage2.position = cursorImage.position + (new Vector3(w, h) * 0.5f);*/
    }

}
