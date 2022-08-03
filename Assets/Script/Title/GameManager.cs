using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject golden;
    public GameObject white;
    public GameObject black;
    public GameObject bald;
    public GameObject sight;
    public GameObject bullet;
    public GameObject clear;
    public GameObject howTo;
    // 커서 이미지
    public RectTransform cursorImage;

    // 게임 시작 버튼이 눌렸는지 확인 변수
    public bool isGameStart;

    //  게임이 끝났는지 확인 변수
    private bool isGameOver;

    private bool howToPlay;

    void Start()
    {
        howToPlay = false;
        isGameStart = false;
        Init_Cursor();
        isGameOver = false;

    }

    void Update()
    {
        // Main Scene 호출
        if (isGameStart)
        {
            //SceneManager.LoadScene(1);
        }

        // 커서 이미지
        Update_MousePosition();

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("눌림");
            golden.SetActive(true);
        }*/

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
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        howToPlay = true;
        howTo.SetActive(true);
    }

    public void HowToPlayBack()
    {
        howToPlay = false;
        howTo.SetActive(false);
    }

    public IEnumerator GameOver()
    {
        isGameOver = true;
        if (isGameOver)
        {
            // 자동으로 타이틀로 감
            // 조건 : 타이머가 0 or 대머리 독수리를 제외한 다른 독수리를 모두 잡았을 경우
            Debug.Log("게임 클리어");
            clear.SetActive(true);
            // 2초 뒤에 타이틀로 감
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene(0);
        }
    }

    public void GameObjectTrue()
    {
        golden.SetActive(true);
        white.SetActive(true);
        black.SetActive(true);
        bald.SetActive(true);
        sight.SetActive(true);
        bullet.SetActive(true);
    }
}
