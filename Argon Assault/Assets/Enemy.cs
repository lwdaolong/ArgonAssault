using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathfx;

    ScoreBoard scoreboard;
    bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        scoreboard = FindObjectOfType<ScoreBoard>();
        AddComponents();
    }

    private void AddComponents()
    {
        BoxCollider col = gameObject.AddComponent<BoxCollider>();
        col.isTrigger = false;
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (alive)
        {
            alive = false;
            deathfx.SetActive(true);
            GetComponent<Rigidbody>().useGravity = true;
            Invoke("DestroyOBJ", 1f);

        }



    }

    void DestroyOBJ()
    {
        scoreboard.addScore();

        Destroy(gameObject);
    }

}
