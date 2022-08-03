using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletHome : MonoBehaviour
{
    public Gun gun;

    // �Ѿ� ī��Ʈ
    private TextMeshProUGUI bulletCountText;


    void Start()
    {
        bulletCountText = GetComponent<TextMeshProUGUI>();
        gun = FindObjectOfType<Gun>();
    }

    void Update()
    {
        // ź�� ���� �ǿ��� �����ͼ� ������Ʈ �Ѵ�.
        bulletCountText.text = gun.totalBulletCount.ToString();
    }
}
