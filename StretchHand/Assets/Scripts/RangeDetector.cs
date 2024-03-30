using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    PlayerController playerController;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerExit2D(Collider2D collider) {
        collider.gameObject.transform.position = playerController.transform.position;
        Debug.Log("it should have worked");
    }
}
