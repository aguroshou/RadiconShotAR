using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int moveCountLimit;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FireBullet");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FireBullet()
    {
        for (int moveCount = 0; moveCount < moveCountLimit; moveCount++)
        {
            transform.position += transform.forward * moveSpeed;
            yield return null;
        }

        Destroy(this.gameObject);
        yield return null;
    }

    private void OnCollisionEnter(Collision collideObject)
    {
        Debug.Log("Collide");
        if (collideObject.gameObject.CompareTag("Target"))
        {
            Destroy(this.gameObject);
        }
    }
}