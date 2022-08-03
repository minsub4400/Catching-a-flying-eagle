using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletHome : MonoBehaviour
{
    public Gun gun;

    // 총알 카운트
    private TextMeshProUGUI bulletCountText;


    void Start()
    {
        bulletCountText = GetComponent<TextMeshProUGUI>();
        gun = FindObjectOfType<Gun>();
    }

    void Update()
    {
        // 탄알 수를 건에서 가져와서 업데이트 한다.
        bulletCountText.text = gun.totalBulletCount.ToString();
    }
}
