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
        Debug.Log("logged");
        // collider.gameObject.transform.position = playerController.transform.position;
        if (collider.GetComponent<Hand>() != null) {
            if (collider.GetComponent<Hand>().grabbing == false) {
                collider.GetComponent<Hand>().grabbing = true;
                collider.GetComponent<Hand>().rb.velocity = Vector2.zero;
                collider.GetComponent<Hand>().TriggerHand(playerController.mouseWorldPos);
            }
        }
    }
}
