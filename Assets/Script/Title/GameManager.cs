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
    // Ŀ�� �̹���
    public RectTransform cursorImage;

    // ���� ���� ��ư�� ���ȴ��� Ȯ�� ����
    public bool isGameStart;

    //  ������ �������� Ȯ�� ����
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
        // Main Scene ȣ��
        if (isGameStart)
        {
            //SceneManager.LoadScene(1);
        }

        // Ŀ�� �̹���
        Update_MousePosition();

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("����");
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
            // �ڵ����� Ÿ��Ʋ�� ��
            // ���� : Ÿ�̸Ӱ� 0 or ��Ӹ� �������� ������ �ٸ� �������� ��� ����� ���
            Debug.Log("���� Ŭ����");
            clear.SetActive(true);
            // 2�� �ڿ� Ÿ��Ʋ�� ��
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
