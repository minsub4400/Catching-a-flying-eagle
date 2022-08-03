using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour
{
    public float width;
    public float hight;

    private void Awake()
    {
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x;
        hight = backGroundCollider.size.y;
    }
    private void Update()
    {
        if (transform.position.y <= -540)
        {
            // 화면을 위쪽으로 이어 붙임
            Reposition();
        }
    }

    // 위치를 리셋하는 메서드
    private void Reposition()
    {
        Vector2 offset = new Vector2(0, 1080 * 2);
        transform.position = (Vector2)transform.position + offset;
    }
}