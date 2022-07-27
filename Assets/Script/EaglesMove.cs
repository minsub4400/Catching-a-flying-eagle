using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 독수리들은 랜덤의 방향으로 움직인다. -1 : 왼쪽, 0 : 가만히, 1 : 오른쪽
// 스피드는 독수리의 종류마다 다르다.

public class EaglesMove : MonoBehaviour
{
    // 행동 최소 범위
    private int minMove = -1;
    // 행동 최대 범위
    private int maxMove = 1;
    // 행동 스피드
    public float moveSpeed = 15.0f;
    // 행동 범위 저장 변수
    public float randMoveX;
    public float randMoveY;

    // 배경화면 사이즈 담을 변수
    private float backGroundX;
    private float backGroundY;

    // 배경 콜라이더의 사이즈 가져오기 위한 변수
    BackgroundLoop backgroundLoop;

    void Start()
    {
        // 초기화
        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);
        backgroundLoop = FindObjectOfType<BackgroundLoop>();
        backGroundX = 60;//backgroundLoop.width; // 배경화면 가로 [60]
        backGroundY = 40;//backgroundLoop.hight; // 배경화면 세로 [40]
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
            Debug.Log("배경화면 밖으로 나감");
        }

        randMoveX = Random.Range(minMove, maxMove);
        randMoveY = Random.Range(minMove, maxMove);


    }
}
