using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
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
        if (collision.collider.gameObject.tag == "EnemyHead")
        {
            if (transform.position.y>= collision.collider.transform.position.y)
            {
            Destroy(collision.collider.transform.parent.gameObject);
            Destroy(collision.collider.gameObject);
            // GameManager.score += 100;
            }
        }
    }
}
