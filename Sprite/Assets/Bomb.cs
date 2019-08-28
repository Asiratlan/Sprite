using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float lifeSpan;
    public GameObject explosionPrefab;

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;

        if (lifeSpan <= 0)
            Explode();
    }

    public void Explode()
    {
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        GameManager.managerInstance.audioManager.PlayExplosionSound();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            Explode();
    }
}
