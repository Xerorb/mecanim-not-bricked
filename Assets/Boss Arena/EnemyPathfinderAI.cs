using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinderAI : MonoBehaviour
{ //initializing
    bool goRight;
    float speed;
    float interval;
    float lastSwitchTime;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    Rigidbody theRigidbody;
    Renderer myRender;
    public float playerTargetDistance;
    public Transform playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
        goRight = false;
        speed = 1.5f;
        interval = 2f;
        lastSwitchTime = 0f;
    }

    // Update is called once per x amount of time
    //update at a fixed rate
    void FixedUpdate()
    {
        playerTargetDistance = Vector3.Distance(playerTarget.position, transform.position);
        if (goRight == true) // if the thing is going right
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
        }
        if(Time.time > lastSwitchTime + interval)
        {
            lastSwitchTime = Time.time;
            goRight = !goRight;
        }    
    }
}   