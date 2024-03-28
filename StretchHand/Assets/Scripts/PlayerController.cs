using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        DetectMouseInput();
    }

    private void DetectMouseInput() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Pressed left click");
        } else if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Pressed right click");
        }
    }
}
