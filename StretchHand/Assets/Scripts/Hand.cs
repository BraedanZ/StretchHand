using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Hand hand;
    Rigidbody2D rb;

    Vector3 handDirection;
    
    public float handSpeed;

    private bool collided;

    void Start()
    {
        hand = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        collided = true;
    }

    void FixedUpdate() {
        if (!collided) {
            transform.position += handDirection * handSpeed * Time.deltaTime;
        }
    }

    public void Launch(Vector3 mouseWorldPos) {
        mouseWorldPos.z = 0f;
        handDirection = (mouseWorldPos - transform.position).normalized;
        collided = false;
    }
}
