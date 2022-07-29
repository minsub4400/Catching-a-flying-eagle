using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 독수리들은 랜덤의 방향으로 움직인다. -1 : 왼쪽, 0 : 가만히, 1 : 오른쪽
// 스피드는 독수리의 종류마다 다르다.

public class EaglesMove : MonoBehaviour
{
    // X 행동 최소 범위
    public float XminMove = -30f;
    // X 행동 최대 범위
    public float XmaxMove = 30f;

    // Y 행동 최소 범위
    public float YminMove = -10f;
    // Y 행동 최대 범위
    public float YmaxMove = 10f;
    // 행동 범위 저장 변수
    private float randMoveX;
    private float randMoveY;
    private Vector2 randMoveXY;
    // 행동 스피드
    public float moveSpeed = 0.03f;

    // 방향 전환을 확인하기 위한 변수
    private bool isRight; // 오른쪽
    private bool isLeft;   // 왼쪽
    private Animator animator;

    // 베지어 커브 사용을 위한 애니매이션
    /*[SerializeField]
    private AnimationCurve curve;*/

    public GameObject point1;
    private float Timer;

    // Collider 가져오기
    public CircleCollider2D circleCollider2D;

    void Start()
    {
        // 초기화
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
            // 게임 오브젝트 위치랑 콜라이더 위치가 같게 맞춰주기
            circleCollider2D.transform.position = transform.position;
        }

        // 방향 전환 메소드
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

        // 시작지점 위치와 point2의 위치가 동일하면 point1, point2의 위치를 랜덤으로 돌림

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
        // 포인트랑 닿으면 포인트 위치 이동
        if (collision.tag == "Point1")
        {
            point1.transform.position = RandomFloatNumber();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // 제자리 유지가 될 경우를 방지 하기 위한 코드
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
        // 방향은 자신의 오브젝트 위치 x가 포인트 오브젝트보다 크면 Left 이미지를  true, 포인트 오브젝트보다 작으면 Right 이미지를 true

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
