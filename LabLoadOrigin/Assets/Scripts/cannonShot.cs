using UnityEngine;
using System.Collections;

public class cannonShot : MonoBehaviour
{

    public float force;
    public float speed;
    Rigidbody2D rb;

    // Use this for initialization

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getForce()
    {
        return force;
    }
}
