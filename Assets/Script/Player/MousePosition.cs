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
            // 마우스 포인터 위치 찍기
            mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mPosition);
            // 마우스 위치로 게임 오브젝트 옮기기
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
