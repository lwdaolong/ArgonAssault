using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathfx;
    // Start is called before the first frame update
    void Start()
    {
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
        deathfx.SetActive(true);
        GetComponent<Rigidbody>().useGravity = true;
        Invoke("DestroyOBJ", 1f);


    }

    void DestroyOBJ()
    {
        Destroy(gameObject);
    }

}
