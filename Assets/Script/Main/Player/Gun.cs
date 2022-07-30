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

    // Eagles ��������
    private EaglesHealth eaglesHealth;
    private EaglesMove eaglesMove;
    // ���콺 ��ġ ��������
    private MousePosition mousePosition;

    //�ݶ��̴� ��������
    private CircleCollider2D curcleCollider2D;

    void Start()
    {
        eaglesMove = GetComponent<EaglesMove>();
        mousePosition = GetComponent<MousePosition>();
        curcleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetButton(fireButtinName)) // ������ true �ȴ����� false
        {
            Fire();
        }
    }

    private void Fire()
    {
        // �߻� ���� ��ġ�� Ÿ�� �ݶ��̴� ��ġ �ȿ� ������ Die ����

        // �ݶ��̴� Ȱ��ȭ
        //curcleCollider2D.enabled = true;
    }

    private IEnumerable ShotEffect()
    {
        // �߻� ȿ�� ���
        muzzleFlashEffect.Play();
        // �߻� �Ҹ� ���
        shotAudioPlayer.PlayOneShot(shotClip);
        // �Ҹ��� ���� ������ �ʰ� ���
        yield return new WaitForSeconds(0.2f);

    }
}
