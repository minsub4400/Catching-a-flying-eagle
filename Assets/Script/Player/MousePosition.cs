using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector2 mPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ������ ��ġ ���
            mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mPosition);
            // ���콺 ��ġ�� ���� ������Ʈ �ű��
            transform.position = mPosition;
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            this.mPosition = Input.mousePosition;
            transform.position = this.mPosition;
            Debug.Log(this.mPosition);
        }*/
    }
}
