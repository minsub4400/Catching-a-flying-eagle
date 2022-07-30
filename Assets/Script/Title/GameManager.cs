using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Ŀ�� �̹���
    public RectTransform cursorImage;

    // ���� ���� ��ư�� ���ȴ��� Ȯ�� ����
    public bool isGame;

    // Ÿ��Ʋ ���� ����
    // ��ư �Ҹ� ����Ʈ

    void Start()
    {
        isGame = false;
        Init_Cursor();
    }

    void Update()
    {
        // Main Scene ȣ��
        if (isGame)
        {
            SceneManager.LoadScene(0);
        }

        // Ŀ�� �̹���
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
