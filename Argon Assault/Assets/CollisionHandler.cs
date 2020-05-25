using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float startTime;

    [SerializeField] float levelLoadDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }



    private void StartDeathSequence()
    {
        print("Player Dying");
        SendMessage("OnPlayerDeath");
        if(Time.time - startTime >= 10f)
            Invoke("RestartLevel", levelLoadDelay);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Player collided with something");
    }

}
