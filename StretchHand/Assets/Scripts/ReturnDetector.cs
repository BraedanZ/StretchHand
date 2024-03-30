using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("logged");
        if (collider.GetComponent<Hand>() != null) {
            collider.GetComponent<Hand>().rb.velocity = Vector2.zero;
            collider.GetComponent<Hand>().canThrow = true;
        }
    }
}
