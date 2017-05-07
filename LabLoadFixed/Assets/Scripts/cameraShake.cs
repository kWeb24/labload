using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour {

    Vector3 originalCameraPosition;
    public Camera mainCamera;

    public float force;
    public float quake;
    float shakeAmt = 0;

    void Awake()
    {
        //mainCamera = this;
        originalCameraPosition = mainCamera.transform.position;
    }

    public void Shake()
    {
        shakeAmt = force;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.3f);
    }


    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * quake - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            pp.x += quakeAmt;
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }
}

