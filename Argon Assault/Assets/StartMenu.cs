using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<StartMenu>().Length;
        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);

        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }


}
