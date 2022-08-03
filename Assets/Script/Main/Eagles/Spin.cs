using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] [Range(1f, 500f)] float rotationSpeed = 300f;
    private float z;
    void Start()
    {
        z = 0f;
    }
    void Update()
    {
        z += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, z);
        
    }
}
