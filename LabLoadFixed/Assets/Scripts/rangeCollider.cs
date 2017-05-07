using UnityEngine;
using System.Collections;

public class rangeCollider : MonoBehaviour {

    public int isTriggered;
    public GameObject trigger;

    void Start()
    {
        isTriggered = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "redBlock")
        {
            isTriggered = 1;
            trigger = collider.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "redBlock")
        {
            isTriggered = 0;
            //trigger = trigger;
        }
    }

}
