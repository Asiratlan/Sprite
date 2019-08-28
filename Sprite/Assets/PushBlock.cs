using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
    //Manages movable blocks, primarily used for switches and puzzles
    //Diagonal movement should be disabled
    //Once movement on an axis has occurred, movement should be disabled on the other axis

    bool switched = false;    //checked by objects using the block as a switch
    bool initialMov = false;  //control variable, set to true after first input

    float startX, startY;
    float blockLength = 1f; //.16 on both axes. Distance to move one block-length

    Rigidbody2D block;

    void Start()
    {
        block = GetComponent<Rigidbody2D>();
        startX = transform.position.x;
        startY = transform.position.y;
    }

    void Update()
    {
        if (!switched)
        {
            if (transform.position.x >= startX + blockLength)
            {
                block.isKinematic = true;
                transform.position = new Vector2(startX + blockLength, transform.position.y);
                switched = true;
                StartCoroutine(MoveCo());
            }
            else if (transform.position.x <= startX - blockLength)
            {
                block.isKinematic = true;
                transform.position = new Vector2(startX - blockLength, transform.position.y);
                switched = true;
                StartCoroutine(MoveCo());
            }
            else if (transform.position.y >= startY + blockLength)
            {
                block.isKinematic = true;
                transform.position = new Vector2(transform.position.x, startY + blockLength);
                switched = true;
                StartCoroutine(MoveCo());
            }
            else if (transform.position.y <= startY - blockLength)
            {
                block.isKinematic = true;
                transform.position = new Vector2(transform.position.x, startY - blockLength);
                switched = true;
                StartCoroutine(MoveCo());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.CompareTag("Player"))
            return;

        Player body = coll.gameObject.GetComponent<Player>();

        if (!initialMov)
        {
            if (body.movement.x < 0) { block.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; }//leftward
            else if (body.movement.x > 0) { block.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; }//rightward
            else if (body.movement.y > 0) { block.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; }//upward
            else if (body.movement.y < 0) { block.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; }//downward
            block.isKinematic = false;
            initialMov = true;
        }
    }

    public IEnumerator MoveCo()
    {
        if (block != null)
        {
            yield return new WaitForSeconds(0.05f);
            block.velocity = Vector2.zero;
            block.isKinematic = true;
        }
    }
}
