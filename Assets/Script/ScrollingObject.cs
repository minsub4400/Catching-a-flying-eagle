using UnityEngine;

// ���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f; // �̵� �ӵ�

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        // ���� ������Ʈ�� �������� ���� �ӵ��� ���� �̵��ϴ� ó��
        /*if (!GameManager.instance.isGameover) // ���ӿ����� �ƴ� ����
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }*/
    }
}