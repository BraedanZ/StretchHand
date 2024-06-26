using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerController playerController;
    public Rigidbody2D rb;

    Vector3 mouseScreenPos;
    public Vector3 mouseWorldPos;

    Hand left;
    Hand right;

    public float pullStrength;

    void Start()
    {
        playerController = this;
        rb = GetComponent<Rigidbody2D>();

        left = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Hand>(); 
        right = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Hand>(); 
    }

    void Update()
    {
        UpdateMousePosition();
        DetectMouseInput();
    }

    void FixedUpdate() {
        DetectHands();
    }

    private void UpdateMousePosition() {
        mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.nearClipPlane = 1;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private void DetectMouseInput() {

        if (Input.GetMouseButtonDown(0)) {
            LaunchHand(left);
        } 
        
        if (Input.GetMouseButtonDown(1)) {
            LaunchHand(right);
        }
    }

    private void LaunchHand(Hand hand) {
        hand.TriggerHand(mouseWorldPos);
    }

    private void DetectHands() {
        if (left.grabbing && right.grabbing) {
            left.DestroyDistanceJoint();
            right.DestroyDistanceJoint();

            rb.AddForce((left.transform.position - transform.position) * pullStrength);
            rb.AddForce((right.transform.position - transform.position) * pullStrength);
        } else if (left.grabbing && !right.grabbing) {
            left.CreateDistanceJoint();

        } else if (!left.grabbing && right.grabbing) {
            right.CreateDistanceJoint();

        } else {
            left.DestroyDistanceJoint();
            right.DestroyDistanceJoint();
        }


    }
}
