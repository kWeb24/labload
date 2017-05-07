using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float speed = 1f;
    public float gearRotationSpeed = 100f;

    private float nextFire;
    private float oldPos;
    /* Shots objects */
    public GameObject cannonShot;

    /* Gears objects */
    public GameObject gearLeft;
    public GameObject gearRight;

    /* Shots spawners */
    public Transform cannonShotsSpawner;

    /* Shots delays */
    public float cannonFireRate;

    // Use this for initialization
    void Start () {
        oldPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

        /* Moving */
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;

        /* Firing */
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + cannonFireRate;
                Fire();
            }
        }

        if(oldPos < transform.position.x)
        {
            /* Right */
            //Debug.Log("Right bitchezzz");
            gearLeft.transform.Rotate(Vector3.forward * Time.deltaTime * (gearRotationSpeed * -1));
            gearRight.transform.Rotate(Vector3.forward * Time.deltaTime * (gearRotationSpeed * -1));
        } else if (oldPos > transform.position.x)
        {
            /* Left */
            gearLeft.transform.Rotate(Vector3.forward * Time.deltaTime * gearRotationSpeed);
            gearRight.transform.Rotate(Vector3.forward * Time.deltaTime * gearRotationSpeed);
        }


        oldPos = transform.position.x;

    }

    void Fire()
    {
        Instantiate(cannonShot, cannonShotsSpawner.position, cannonShotsSpawner.rotation);
    }
}
