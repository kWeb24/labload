using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class thegreatcountdown : MonoBehaviour {

    public Image cooldown;
    public bool coolingDown;
    public float waitTime = 30.0f;

    public Text left;

    public GameObject forest;

    private Vector3 startRotation;
    private float time;

    public GameObject who;
    private float instantiated;

    public bool gameState;

    public GameObject hint;

    public bool debugLevel;
    public int availableLevels;

    // Use this for initialization
    void Start () {
        left.text = "0%";
        startRotation = forest.transform.eulerAngles;
        time = 0.0f;
        instantiated = 0;
        gameState = true;

        if (!debugLevel)
        {
            randomizeLevel();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            float reducing = cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
            cooldown.fillAmount = reducing;

            float displaying = reducing * 100;
            left.text = displaying.ToString("F0") + "%";

            time = time + ( 360f / waitTime * Time.deltaTime);
            startRotation.z = time;
            forest.transform.eulerAngles = startRotation;

            //Debug.Log(startRotation);

            if (time >= 360.0f) { time = 0.0f; }

         
        }

        /* By */
        if (Input.GetKey(KeyCode.F1))
        {
            if (instantiated == 0)
            {
                instantiated = 1;
                Instantiate(who);
            }
        }
        else
        {
            if (instantiated == 1)
            {
                instantiated = 0;
                Destroy(GameObject.FindGameObjectWithTag("by"));
            }
        }

        /* Restart */
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!gameState)
            {
                Application.LoadLevel(0);
            }
        }


    }

    public void showHint()
    {
        Instantiate(hint);
    }

    void randomizeLevel()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        float level = Random.Range(1, availableLevels + 1);
        //Debug.Log(Resources.Load("labPrefabs/lab" + level.ToString()));
        
        Instantiate(Resources.Load("labPrefabs/lab" + level.ToString()));
    }

}
