using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Hand hand;
    public Rigidbody2D rb;

    PlayerController playerController;

    Vector3 handDirection;
    
    public float handSpeed;

    public bool grabbing = false;
    private bool canGrab = false;
    public bool canThrow = true;

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

    void OnCollisionStay2D(Collision2D collision) {
        if (canGrab) {
            rb.velocity = Vector2.zero;
            grabbing = true;
            canGrab = false;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    void FixedUpdate() {
        ReturnHand();
    }

    public void TriggerHand(Vector3 mouseWorldPos) {
        mouseWorldPos.z = 0f;
        if (grabbing) {
            grabbing = false;
            canGrab = false;
            // canThrow = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        } else {
            // canGrab = true;
            // handDirection = (mouseWorldPos - transform.position).normalized;
            if (canThrow) {
                canGrab = true;
                handDirection = (mouseWorldPos - transform.position).normalized;
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

    public void CreateHinge() {
        if (GetComponent<HingeJoint2D>() == null) {
            gameObject.AddComponent<HingeJoint2D>();
            GetComponent<HingeJoint2D>().connectedBody = playerController.rb;
        }
    }

    public void DestroyHinge() {
        if (GetComponent<HingeJoint2D>() != null) {
            Destroy(GetComponent<HingeJoint2D>());
        }
    }
}
