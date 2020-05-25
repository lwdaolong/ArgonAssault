using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject DeathFX;
    float startTime;

    [Header("Movement Values")]
    [Tooltip("In ms^-1")][SerializeField] float xFactor;
    [Tooltip("In ms^-1")] [SerializeField] float yFactor;

    [Range(1,50)]public float xSpeed;
    [Range(1, 50)] public float ySpeed;

    [Header("Screen Space Values")]
    [SerializeField] float xRange = 10;
    [SerializeField] float yMax = 10;
    [SerializeField] float yMin = 10;

    float horizontalThrow;
    float verticalThrow;

    [Header("Throw Based Values")]
    [SerializeField] float positionpitchfactor = -5f;
    [SerializeField] float throwpitchfactor = -20f;
    [SerializeField] float throwrollfactor = -30f;
    [SerializeField] float positionyawfactor = 4f;

    bool isControlEnabled = true;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }

    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionpitchfactor + verticalThrow * throwpitchfactor;
        float yaw = transform.localPosition.x * positionyawfactor;
        float roll = horizontalThrow * throwrollfactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void ProcessTranslation()
    {
         horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xFactor = horizontalThrow * Time.deltaTime;
        float xRaw = transform.localPosition.x + xFactor * xSpeed;
        float x = Mathf.Clamp(xRaw, -xRange, xRange);
        transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);

         verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        yFactor = verticalThrow * Time.deltaTime;
        float yRaw = transform.localPosition.y + yFactor * ySpeed;
        float y = Mathf.Clamp(yRaw, yMin, yMax);
        transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
    }

    private void OnPlayerDeath() // called by String reference
    {
        toggleControls();
    }

    private void toggleControls()
    {
        if(Time.time-startTime >= 10f)
        {
            isControlEnabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            DeathFX.SetActive(true);

        }
    }


}
