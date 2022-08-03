using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglesHealth : MonoBehaviour
{
    public bool eaglesAlive { get; private set; }
    public CircleCollider2D collider2D;
    public Rigidbody2D rigidBody2D;
    [SerializeField] [Range(1f, 500f)] float rotationSpeed = 50f;
    private float rotate_z;
    

    private void Start()
    {
        eaglesAlive = false;
        rigidBody2D = GetComponent<Rigidbody2D>();
        rotate_z = 0f;
    }

    private void Update()
    {
        if (eaglesAlive)
        {
            rotate_z += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Euler(0f, 0f, rotate_z);
            rigidBody2D.gravityScale = 300;
        }
    }


    public IEnumerator Die()
    {
        eaglesAlive = true;
        collider2D.enabled = false;
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("¥Í¿Ω");
            StartCoroutine(Die());
        }
    }
}
