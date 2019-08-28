using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmitter : MonoBehaviour
{
    public EntropicBullet bulletPrefab;
    public float delay;
    public int amount;
    public float angleOffset;

    public float bulletSpeed;
    public float bulletAngularVelocity;
    public float bulletLifespan;
    public float bulletAcceleration;
    public float bulletMaxSpeed;

    private float _cooldown;

    // Start is called before the first frame update
    void Start()
    {
        _cooldown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0)
        {
            _cooldown = delay;
            Emit();
        }
    }

    void Emit()
    {
        var angleDelta = 360f / amount;

        for (var angle = angleOffset; angle < 360 + angleOffset; angle += angleDelta)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, angle));
            var rigidbody2D = bullet.GetComponent<Rigidbody2D>();
            var angleRad = (angle % 360) * Mathf.Deg2Rad;

            rigidbody2D.velocity = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * bulletSpeed;
            rigidbody2D.angularVelocity = bulletAngularVelocity * Mathf.Deg2Rad;

            bullet.acceleration = bulletAcceleration;
            bullet.lifespan = bulletLifespan;
            bullet.maxSpeed = bulletMaxSpeed;
        }
    }
}
