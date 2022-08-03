using UnityEngine;

// ���� ������ �̵��� ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ
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
            // ȭ���� �������� �̾� ����
            Reposition();
        }
    }

    // ��ġ�� �����ϴ� �޼���
    private void Reposition()
    {
        Vector2 offset = new Vector2(0, 1080 * 2);
        transform.position = (Vector2)transform.position + offset;
    }
}