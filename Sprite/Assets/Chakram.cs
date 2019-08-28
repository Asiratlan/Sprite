using System;
using UnityEngine;

public class Chakram : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public GameObject owner;
    public float rotation;
    public float speed;
    public float range;
    public float epsilon;
    public Vector2 direction;
    
    private bool _comingBack;
    private Vector2 _origin;
    private Vector2 _target;

    void Start()
    {
        _comingBack = false;
        _origin = transform.position;
        _target = _origin + direction.normalized * range;
    }

    void Update()
    {
        _comingBack |= Vector2.Distance(rigidbody2D.position, _origin) >= range - epsilon;

        if (!_comingBack)
        {
            var dest = Vector2.MoveTowards(rigidbody2D.position, _target, speed * Time.deltaTime);
            rigidbody2D.MovePosition(dest);
        }
        else {
            var dest = Vector2.MoveTowards(rigidbody2D.position, owner.transform.position, speed * Time.deltaTime);
            rigidbody2D.MovePosition(dest);
            
            if (Vector2.Distance(rigidbody2D.position, owner.transform.position) < epsilon)
            {
                Destroy(gameObject);
            }
        }

        transform.Rotate(Vector3.forward, rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Switch>())
        {
            _comingBack = true;
        }
    }
}