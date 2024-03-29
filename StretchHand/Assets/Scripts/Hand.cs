using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Hand hand;
    Rigidbody2D rb;

    PlayerController playerController;

    Vector3 handDirection;
    
    public float handSpeed;

    public bool collided;
    private bool grabbing = false;
    private bool canGrab = false;
    private bool canThrow = true;

    public float throwSpeed;
    public float pullStrength;

    void Start()
    {
        hand = this;
        rb = GetComponent<Rigidbody2D>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (canGrab) {
            rb.velocity = Vector2.zero;
            grabbing = true;
            collided = true;
            canGrab = false;
        }
    }

    void FixedUpdate() {
        ReturnHand();
    }

    public void TriggerHand(Vector3 mouseWorldPos) {
        mouseWorldPos.z = 0f;
        collided = false;
        if (grabbing) {
            grabbing = false;
            canGrab = false;
            canThrow = true;
        } else {
            canGrab = true;
            handDirection = (mouseWorldPos - transform.position).normalized;
            if (canThrow) {
                rb.velocity = Vector2.zero;
                rb.AddForce(handDirection * throwSpeed);
                canThrow = false;
            }
        }
    }

    private void ReturnHand() {
        if (!grabbing && !canGrab) {
            handDirection = (playerController.transform.position - transform.position).normalized;
            rb.AddForce(handDirection * pullStrength);
        }
    }
}
