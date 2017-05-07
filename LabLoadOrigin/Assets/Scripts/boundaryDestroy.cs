using UnityEngine;
using System.Collections;

public class boundaryDestroy : MonoBehaviour {

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "bullet")
        {
            Destroy(collider.gameObject);
        }
    }
}
