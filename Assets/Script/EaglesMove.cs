using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 독수리들은 랜덤의 방향으로 움직인다. -1 : 왼쪽, 0 : 가만히, 1 : 오른쪽
// 스피드는 독수리의 종류마다 다르다.

public class EaglesMove : MonoBehaviour
{
    // 행동 최소 범위
    private int minMove = -6;
    // 행동 최대 범위
    private int maxMove = 6;
    // 행동 스피드
    public float moveSpeed = 0.05f;
    // 행동 범위 저장 변수
    public float randMoveX;
    public float randMoveY;

    // 배경화면 사이즈 담을 변수
    private float backGroundX;
    private float backGroundY;

    // 배경 콜라이더의 사이즈 가져오기 위한 변수
    private BackgroundLoop backgroundLoop;

    private Vector2 randMoveXY;

    // 베지어 커브 사용을 위한 애니매이션
    /*[SerializeField]
    private AnimationCurve curve;*/

    private Vector2 target;
    private float targetX;
    private float targetY;

    void Start()
    {
        // 초기화
        targetX = Random.Range(-6, 6);
        targetY = Random.Range(-2.2f, 2.2f);
        target = new Vector2(targetX, targetY);
        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);
        backgroundLoop = FindObjectOfType<BackgroundLoop>();
        backGroundX = 60;//backgroundLoop.width; // 배경화면 가로 [60]
        backGroundY = 40;//backgroundLoop.hight; // 배경화면 세로 [40]

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

        // 죽지 않았다면 계속 움직임
        if (true)
        {
            transform.Translate(randMoveXY * Time.deltaTime);

        }
        yield return new WaitForSeconds(20f);

        *//*if (myPosition.x >= backGroundX || myPosition.y >= backGroundY)
        {
            Debug.Log("배경화면 밖으로 나감");
        }*//*

        
    }*/
}
