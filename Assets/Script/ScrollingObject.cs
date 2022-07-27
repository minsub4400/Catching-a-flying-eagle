using UnityEngine;

// 게임 오브젝트를 계속 위쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // 이동 속도

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        // 게임 오브젝트를 왼쪽으로 일정 속도로 평행 이동하는 처리
        /*if (!GameManager.instance.isGameover) // 게임오버가 아닐 때만
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }*/
    }
}