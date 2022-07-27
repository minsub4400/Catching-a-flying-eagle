using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������� ������ �������� �����δ�. -1 : ����, 0 : ������, 1 : ������
// ���ǵ�� �������� �������� �ٸ���.

public class EaglesMove : MonoBehaviour
{
    // �ൿ �ּ� ����
    private int minMove = -1;
    // �ൿ �ִ� ����
    private int maxMove = 1;
    // �ൿ ���ǵ�
    public float moveSpeed = 15.0f;
    // �ൿ ���� ���� ����
    public float randMoveX;
    public float randMoveY;

    // ���ȭ�� ������ ���� ����
    private float backGroundX;
    private float backGroundY;

    // ��� �ݶ��̴��� ������ �������� ���� ����
    BackgroundLoop backgroundLoop;

    void Start()
    {
        // �ʱ�ȭ
        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);
        backgroundLoop = FindObjectOfType<BackgroundLoop>();
        backGroundX = 60;//backgroundLoop.width; // ���ȭ�� ���� [60]
        backGroundY = 40;//backgroundLoop.hight; // ���ȭ�� ���� [40]
    }

    void Update()
    {
        float moveValueX = randMoveX * moveSpeed * Time.deltaTime;
        float moveValueY = randMoveY * moveSpeed * Time.deltaTime;
        //transform.Translate(moveValueX, moveValueY, 0f);
        transform.position += new Vector3(moveValueX, moveValueY, 0f);

        Vector2 myPosition = transform.position;

        if (myPosition.x >= backGroundX || myPosition.y >= backGroundY)
        {
            Debug.Log("���ȭ�� ������ ����");
        }

        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);


    }
}
