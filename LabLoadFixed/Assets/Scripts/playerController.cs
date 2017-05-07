using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{

    public float speed = 1f;
    public float boomRate;

    private float nextBoom;

    public GameObject mainCamera;

    public GameObject killed;
    public GameObject killedTxt;
    public GameObject winTxt;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        /* Moving */
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        /* Booms */
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftControl))
        {
            if (Time.time > nextBoom)
            {
                nextBoom = Time.time + boomRate;
                allahuakbar();
                mainCamera.GetComponent<cameraShake>().Shake();
                
            }
       
        }

    }

    void allahuakbar()
    {
        /* Should boom? */
        /* ALLAHU AKHBAR */
        int x = this.gameObject.GetComponentInChildren<rangeCollider>().GetComponent<rangeCollider>().isTriggered;
        if (x == 1)
        {
            //Debug.Log("czerwony deda");
            //Debug.Log(this.gameObject.GetComponentInChildren<rangeCollider>().GetComponent<rangeCollider>().trigger);

            //Debug.Log("T: " + x + "Destroing: " + this.gameObject.GetComponentInChildren<rangeCollider>().GetComponent<rangeCollider>().trigger);
            Destroy(this.gameObject.GetComponentInChildren<rangeCollider>().GetComponent<rangeCollider>().trigger);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "dieBitch")
        {
            //Debug.Log("dead");
            Instantiate(killed);
            Instantiate(killedTxt);

            GameObject.FindGameObjectWithTag("GameController").GetComponent<thegreatcountdown>().gameState = false;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<thegreatcountdown>().showHint();

            /* Self kill buahahahaha */
            Destroy(this.gameObject);
        }

        if (collider.tag == "Finish")
        {
            Instantiate(winTxt);

            GameObject.FindGameObjectWithTag("GameController").GetComponent<thegreatcountdown>().gameState = false;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<thegreatcountdown>().showHint();

            /* Self kill anyway buahahahaha */
            Destroy(this.gameObject);
        }
    }
}
