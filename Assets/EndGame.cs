using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    float timer;
    float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timeLimit = 20;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit)  
        {
            //Do stuff here
            Debug.Log ("countdown over!");
            enabled = false;
        }
        else
        {
            Debug.Log (timer);
        }
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Game Over: The player has reached the goal!"); 
            enabled = false; 
            //Turns our script off so we don’t lose the game after we’ve won.
        }
        
    }
}
