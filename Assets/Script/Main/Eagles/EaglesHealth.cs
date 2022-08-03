using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglesHealth : MonoBehaviour
{
    public bool eaglesAlive { get; private set; }
    public CircleCollider2D collider2D;
    public Rigidbody2D rigidBody2D;
    public Spin spin;

    private void Start()
    {
        eaglesAlive = false;
        rigidBody2D = GetComponent<Rigidbody2D>();
        spin = GetComponent<Spin>();
    }

    public IEnumerator Die()
    {
        eaglesAlive = true;
        if (eaglesAlive)
        {
            collider2D.enabled = false;
            spin.enabled = true;
            rigidBody2D.gravityScale = 300;
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Die());
        }
    }
}
