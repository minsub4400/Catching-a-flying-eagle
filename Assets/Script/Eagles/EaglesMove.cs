using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 독수리들은 랜덤의 방향으로 움직인다. -1 : 왼쪽, 0 : 가만히, 1 : 오른쪽
// 스피드는 독수리의 종류마다 다르다.

public class EaglesMove : MonoBehaviour
{
    // 행동 최소 범위
    private int minMove = -30;
    // 행동 최대 범위
    private int maxMove = 30;
    // 행동 스피드
    public float moveSpeed = 1f;
    // 행동 범위 저장 변수
    public float randMoveX;
    public float randMoveY;
    private Vector2 randMoveXY;

/*    // 배경화면 사이즈 담을 변수
    private float backGroundX;
    private float backGroundY;

    // 배경 콜라이더의 사이즈 가져오기 위한 변수
    private BackgroundLoop backgroundLoop;*/

    // 베지어 커브 사용을 위한 애니매이션
    /*[SerializeField]
    private AnimationCurve curve;*/

    public GameObject point1;
    public GameObject point2;
    private Vector2 bezierCurve1;
    private Vector2 bezierCurve2;
    private float Timer;

    // Collider 가져오기
    public CircleCollider2D circleCollider2D;

    void Start()
    {
        // 초기화
        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);
        randMoveXY = new Vector2(randMoveX, randMoveY);
        circleCollider2D = GetComponent<CircleCollider2D>();
        Timer = 0f;
/*        backgroundLoop = FindObjectOfType<BackgroundLoop>();
        backGroundX = 60;//backgroundLoop.width; // 배경화면 가로 [60]
        backGroundY = 40;//backgroundLoop.hight; // 배경화면 세로 [40]*/

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

    }

    private IEnumerator Moving()
    {
        transform.position = Vector2.Lerp(transform.position, point1.transform.position, moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(2.0f);
        transform.position = Vector2.Lerp(transform.position, point2.transform.position, moveSpeed * Time.deltaTime);

        // 시작지점 위치와 point2의 위치가 동일하면 point1, point2의 위치를 랜덤으로 돌림

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
