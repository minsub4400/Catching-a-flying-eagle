using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // 발사 이펙트 효과
    public ParticleSystem muzzleFlashEffect;
    // 발사 소리
    public AudioClip shotClip;
    private AudioSource shotAudioPlayer;
    // 남은 탄알
    public int totalBulletCount = 25;

    // 발사를 위한 입력 버튼 이름 지정
    public string fireButtinName = "Fire1";

    // 점수 전달
    public Score score;

    // Eagles 가져오기
    private EaglesHealth eaglesHealth;
    private EaglesMove eaglesMove;
    // 마우스 위치 가져오기
    private MousePosition mousePosition;

    private Animator animator;

    //콜라이더 가져오기
    private CircleCollider2D curcleCollider2D;

    private float deltaTime;

    void Start()
    {
        eaglesMove = GetComponent<EaglesMove>();
        mousePosition = GetComponent<MousePosition>();
        curcleCollider2D = GetComponent<CircleCollider2D>();
        shotAudioPlayer = GetComponent<AudioSource>();
        score = FindObjectOfType<Score>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        deltaTime += Time.deltaTime;

        if (deltaTime > 0.1)
        {
            deltaTime = 0;
            if (Input.GetButton(fireButtinName)) // 누르면 true 안누르면 false
            {
                StartCoroutine(Fire());
                animator.SetBool("issight1", false);
                animator.SetBool("issight2", true);
            }
            else
            {
                animator.SetBool("issight1", true);
                animator.SetBool("issight2", false);
            }
        }
    }

    private IEnumerator Fire()
    {
        // 콜라이더 활성화
        curcleCollider2D.enabled = true;
        totalBulletCount--;
        if (totalBulletCount <= 0)
        {
            totalBulletCount = 0;
            curcleCollider2D.enabled = false;
        }
        yield return new WaitForSeconds(0.5f);
        curcleCollider2D.enabled = false;
        // 발사 소리 재생
        shotAudioPlayer.PlayOneShot(shotClip);
        // 발사 효과 재생

        //muzzleFlashEffect.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "White")
        {
            score.isWhiteEagle = true;
        }
        else if (collision.tag == "Black")
        {
            score.isBlackEagle = true;
        }
        else if (collision.tag == "Gold")
        {
            score.isGoldEagle = true;
        }
        else if (collision.tag == "Bald")
        {
            score.isBaldEagle = true;
        }
        score.AddScore();
    }
}
