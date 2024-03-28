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
            grabbing = true;
            collided = true;
            canGrab = false;
        }
    }

    void FixedUpdate() {
        Launch();
        ReturnHand();
    }

    public void TriggerHand(Vector3 mouseWorldPos) {
        mouseWorldPos.z = 0f;
        collided = false;
        if (grabbing) {
            grabbing = false;
            canGrab = false;
            handDirection = (playerController.transform.position - transform.position).normalized;
        } else {
            canGrab = true;
            handDirection = (mouseWorldPos - transform.position).normalized;
        }
    }

    private void Launch() {
        if (!collided && !grabbing) {
            transform.position += handDirection * handSpeed * Time.deltaTime;
        }
    }

    private void ReturnHand() {
        if (!grabbing && !canGrab) {
            rb.AddForce(handDirection * pullStrength);
        }
    }
}
