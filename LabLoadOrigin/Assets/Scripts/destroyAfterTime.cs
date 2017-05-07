using UnityEngine;
using System.Collections;

public class destroyAfterTime : MonoBehaviour {

    public float waitTime;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, waitTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
