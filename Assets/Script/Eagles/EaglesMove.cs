using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������� ������ �������� �����δ�. -1 : ����, 0 : ������, 1 : ������
// ���ǵ�� �������� �������� �ٸ���.

public class EaglesMove : MonoBehaviour
{
    // �ൿ �ּ� ����
    private int minMove = -30;
    // �ൿ �ִ� ����
    private int maxMove = 30;
    // �ൿ ���ǵ�
    public float moveSpeed = 1f;
    // �ൿ ���� ���� ����
    public float randMoveX;
    public float randMoveY;
    private Vector2 randMoveXY;

/*    // ���ȭ�� ������ ���� ����
    private float backGroundX;
    private float backGroundY;

    // ��� �ݶ��̴��� ������ �������� ���� ����
    private BackgroundLoop backgroundLoop;*/

    // ������ Ŀ�� ����� ���� �ִϸ��̼�
    /*[SerializeField]
    private AnimationCurve curve;*/

    public GameObject point1;
    public GameObject point2;
    private Vector2 bezierCurve1;
    private Vector2 bezierCurve2;
    private float Timer;

    // Collider ��������
    public CircleCollider2D circleCollider2D;

    void Start()
    {
        // �ʱ�ȭ
        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);
        randMoveXY = new Vector2(randMoveX, randMoveY);
        circleCollider2D = GetComponent<CircleCollider2D>();
        Timer = 0f;
/*        backgroundLoop = FindObjectOfType<BackgroundLoop>();
        backGroundX = 60;//backgroundLoop.width; // ���ȭ�� ���� [60]
        backGroundY = 40;//backgroundLoop.hight; // ���ȭ�� ���� [40]*/

    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 0.5f)
        {
            StartCoroutine(Moving());
            // ���� ������Ʈ ��ġ�� �ݶ��̴� ��ġ�� ���� �����ֱ�
            circleCollider2D.transform.position = transform.position;
        }

    }

    private IEnumerator Moving()
    {
        transform.position = Vector2.Lerp(transform.position, point1.transform.position, moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(2.0f);
        transform.position = Vector2.Lerp(transform.position, point2.transform.position, moveSpeed * Time.deltaTime);

        // �������� ��ġ�� point2�� ��ġ�� �����ϸ� point1, point2�� ��ġ�� �������� ����

        if (transform.position.x >= point2.transform.position.x && transform.position.y <= point2.transform.position.y)
        {
            RandomFloatNumber();
            point1.transform.position = randMoveXY;
            RandomFloatNumber();
            point2.transform.position = randMoveXY;
        }
    }

    private void RandomFloatNumber()
    {
        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);
        randMoveXY = new Vector2(randMoveX, randMoveY);
    }
}
