using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] [Range(1f, 500f)] float rotationSpeed = 50f;
    private float z;
    void Start()
    {
        
    }

    void Update()
    {
        z += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, z);
    }
}
