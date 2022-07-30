using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���������� ������ �������� �����δ�. -1 : ����, 0 : ������, 1 : ������
// ���ǵ�� �������� �������� �ٸ���.

public class EaglesMove : MonoBehaviour
{
    // X �ൿ �ּ� ����
    public float XminMove = -30f;
    // X �ൿ �ִ� ����
    public float XmaxMove = 30f;

    // Y �ൿ �ּ� ����
    public float YminMove = -10f;
    // Y �ൿ �ִ� ����
    public float YmaxMove = 10f;
    // �ൿ ���� ���� ����
    private float randMoveX;
    private float randMoveY;
    private Vector2 randMoveXY;
    // �ൿ ���ǵ�
    public float moveSpeed = 0.03f;

    // ���� ��ȯ�� Ȯ���ϱ� ���� ����
    private bool isRight; // ������
    private bool isLeft;   // ����
    private Animator animator;

    // ������ Ŀ�� ����� ���� �ִϸ��̼�
    /*[SerializeField]
    private AnimationCurve curve;*/

    public GameObject point1;
    private float Timer;

    // Collider ��������
    public CircleCollider2D circleCollider2D;

    void Start()
    {
        // �ʱ�ȭ
        randMoveX = Random.Range(XminMove, XmaxMove);
        randMoveY = Random.Range(YminMove, YmaxMove);
        circleCollider2D = GetComponent<CircleCollider2D>();
        Timer = 0f;
        isRight = false;
        isLeft = false;
        animator = GetComponent<Animator>();
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

        // ���� ��ȯ �޼ҵ�
        ChangeDirection();

    }

    private IEnumerator Moving()
    {
        /*        Vector2 L1 = Vector2.Lerp(transform.position, point1.transform.position, Timer);
                Vector2 L2 = Vector2.Lerp(point1.transform.position, point2.transform.position, Timer);
                Vector2 L12 = Vector2.Lerp(L1, L2, Timer);

                transform.Translate(L12 * Time.deltaTime);*/

        /*        float L13 = ThreePointBezier(transform.position.x, point1.transform.position.x, point2.transform.position.x);
                float L14 = ThreePointBezier(transform.position.y, point1.transform.position.y, point2.transform.position.y);
                Vector2 L22 = new Vector2(L13, L14);
                transform.position = L22 * Time.deltaTime;*/

        /*Vector2 positionSet = point1.transform.position - transform.position;
       transform.position = positionSet * Time.deltaTime;*/

        transform.position = Vector2.MoveTowards(gameObject.transform.position, point1.transform.position, moveSpeed);


        yield return new WaitForSeconds(2.0f);

        // �������� ��ġ�� point2�� ��ġ�� �����ϸ� point1, point2�� ��ġ�� �������� ����

        /*if (transform.position.x >= point2.transform.position.x && transform.position.y <= point2.transform.position.y)
        {
            RandomFloatNumber();
            point1.transform.position = randMoveXY;
            RandomFloatNumber();
            point2.transform.position = randMoveXY;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ����Ʈ�� ������ ����Ʈ ��ġ �̵�
        if (collision.tag == "Point1")
        {
            point1.transform.position = RandomFloatNumber();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // ���ڸ� ������ �� ��츦 ���� �ϱ� ���� �ڵ�
        if (collision.tag == "Point1")
        {
            point1.transform.position = RandomFloatNumber();
        }
    }

    private Vector2 RandomFloatNumber()
    {
        randMoveX = Random.Range(XminMove, XmaxMove);
        randMoveY = Random.Range(YminMove, YmaxMove);
        return randMoveXY = new Vector2(randMoveX, randMoveY);
    }

    private float ThreePointBezier(float A, float B, float C)
    {
        return Mathf.Pow((1 - Timer), 3) * A 
            + Mathf.Pow((1 - Timer), 2) * 3 * Timer * B 
            + Mathf.Pow(Timer, 2) * 3 * (1 - Timer) * C;
    }

    private void ChangeDirection()
    {
        // ������ �ڽ��� ������Ʈ ��ġ x�� ����Ʈ ������Ʈ���� ũ�� Left �̹�����  true, ����Ʈ ������Ʈ���� ������ Right �̹����� true

        if (transform.position.x >= point1.transform.position.x)
        {
            animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);
        }
        else
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
        }
    }

}
