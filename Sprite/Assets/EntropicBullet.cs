using System;
using UnityEngine;

public class EntropicBullet : MonoBehaviour
{
    public float lifespan;
    public float acceleration;
    public float maxSpeed;

    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }

        var velocity = _rigidbody2D.velocity;
        _rigidbody2D.velocity = velocity.normalized * Math.Min(velocity.magnitude + acceleration, maxSpeed);
    }
}
