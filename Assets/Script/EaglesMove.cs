using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������� ������ �������� �����δ�. -1 : ����, 0 : ������, 1 : ������
// ���ǵ�� �������� �������� �ٸ���.

public class EaglesMove : MonoBehaviour
{
    // �ൿ �ּ� ����
    private int minMove = -6;
    // �ൿ �ִ� ����
    private int maxMove = 6;
    // �ൿ ���ǵ�
    public float moveSpeed = 0.05f;
    // �ൿ ���� ���� ����
    public float randMoveX;
    public float randMoveY;

    // ���ȭ�� ������ ���� ����
    private float backGroundX;
    private float backGroundY;

    // ��� �ݶ��̴��� ������ �������� ���� ����
    private BackgroundLoop backgroundLoop;

    private Vector2 randMoveXY;

    // ������ Ŀ�� ����� ���� �ִϸ��̼�
    /*[SerializeField]
    private AnimationCurve curve;*/

    private Vector2 target;
    private float targetX;
    private float targetY;

    void Start()
    {
        // �ʱ�ȭ
        targetX = Random.Range(-6, 6);
        targetY = Random.Range(-2.2f, 2.2f);
        target = new Vector2(targetX, targetY);
        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);
        backgroundLoop = FindObjectOfType<BackgroundLoop>();
        backGroundX = 60;//backgroundLoop.width; // ���ȭ�� ���� [60]
        backGroundY = 40;//backgroundLoop.hight; // ���ȭ�� ���� [40]

    }

    void Update()
    {
        //StartCoroutine(Moving());

        transform.position = Vector3.Slerp(transform.position, target, moveSpeed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            targetX = Random.Range(-6, 6);
            targetY = Random.Range(-2.2f, 2.2f);
            target = new Vector2(targetX, targetY);
        }

    }

    /*private IEnumerator Moving()
    {
        randMoveX = Random.Range(minMove, maxMove) * moveSpeed;
        randMoveY = Random.Range(minMove, maxMove) * moveSpeed;
        randMoveXY = new Vector2(randMoveX, randMoveY);

        // ���� �ʾҴٸ� ��� ������
        if (true)
        {
            transform.Translate(randMoveXY * Time.deltaTime);

        }
        yield return new WaitForSeconds(20f);

        *//*if (myPosition.x >= backGroundX || myPosition.y >= backGroundY)
        {
            Debug.Log("���ȭ�� ������ ����");
        }*//*

        
    }*/
}
