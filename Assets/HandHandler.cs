using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.gameObject.tag == "EnemyBody")
        {
            {
            Destroy(collision.collider.transform.parent.gameObject);
            Destroy(collision.collider.gameObject);
            StateManager.score += 100;
            Debug.Log(StateManager.score + " points!");
            }
        }
    }
}