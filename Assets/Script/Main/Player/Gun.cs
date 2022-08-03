using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // �߻� ����Ʈ ȿ��
    public ParticleSystem muzzleFlashEffect;
    // �߻� �Ҹ�
    public AudioClip shotClip;
    private AudioSource shotAudioPlayer;
    // ���� ź��
    public int totalBulletCount = 25;

    // �߻縦 ���� �Է� ��ư �̸� ����
    public string fireButtinName = "Fire1";

    // ���� ����
    public Score score;

    // Eagles ��������
    private EaglesHealth eaglesHealth;
    private EaglesMove eaglesMove;
    // ���콺 ��ġ ��������
    private MousePosition mousePosition;

    private Animator animator;

    //�ݶ��̴� ��������
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
            if (Input.GetButton(fireButtinName)) // ������ true �ȴ����� false
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
        // �ݶ��̴� Ȱ��ȭ
        curcleCollider2D.enabled = true;
        totalBulletCount--;
        if (totalBulletCount <= 0)
        {
            totalBulletCount = 0;
            curcleCollider2D.enabled = false;
        }
        yield return new WaitForSeconds(0.5f);
        curcleCollider2D.enabled = false;
        // �߻� �Ҹ� ���
        shotAudioPlayer.PlayOneShot(shotClip);
        // �߻� ȿ�� ���

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
