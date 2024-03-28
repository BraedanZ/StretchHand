using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 mousePos;

    Hand left;
    Hand right;

    void Start()
    {
       left = GameObject.FindGameObjectWithTag("Left").GetComponent<Hand>(); 
       right = GameObject.FindGameObjectWithTag("Right").GetComponent<Hand>(); 
    }

    void Update()
    {
        UpdateMousePosition();
        DetectMouseInput();
    }

    private void UpdateMousePosition() {
        mousePos = Input.mousePosition;
        Debug.Log(mousePos);
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

    }
}
