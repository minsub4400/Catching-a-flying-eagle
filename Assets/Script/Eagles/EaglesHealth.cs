using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglesHealth : MonoBehaviour
{
    public bool eaglesAlive { get; private set; }

    private void Start()
    {
        eaglesAlive = false;
    }

    public void Die()
    {
        eaglesAlive = true;
        gameObject.SetActive(false);
    }
}
