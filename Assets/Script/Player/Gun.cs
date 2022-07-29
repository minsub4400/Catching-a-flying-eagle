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

    // Eagles 가져오기
    private EaglesHealth eaglesHealth;
    private EaglesMove eaglesMove;
    // 마우스 위치 가져오기
    private MousePosition mousePosition;

    //콜라이더 가져오기
    private CircleCollider2D curcleCollider2D;

    void Start()
    {
        eaglesMove = GetComponent<EaglesMove>();
        mousePosition = GetComponent<MousePosition>();
        curcleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetButton(fireButtinName)) // 누르면 true 안누르면 false
        {
            Fire();
        }
    }

    private void Fire()
    {
        // 발사 저장 위치가 타겟 콜라이더 위치 안에 있으면 Die 실행

        // 콜라이더 활성화
        //curcleCollider2D.enabled = true;
    }

    private IEnumerable ShotEffect()
    {
        // 발사 효과 재생
        muzzleFlashEffect.Play();
        // 발사 소리 재생
        shotAudioPlayer.PlayOneShot(shotClip);
        // 소리가 겹쳐 나오지 않게 대기
        yield return new WaitForSeconds(0.2f);

    }
}
