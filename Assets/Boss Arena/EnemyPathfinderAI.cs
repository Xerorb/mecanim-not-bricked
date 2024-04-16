using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

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
        playerTargetDistance = 0f;
        enemyLookDistance = 10f;
        attackDistance = 8f;
        enemyMovementSpeed = 0.6f;
        goRight = false;
        speed = 1.5f;
        interval = 2f;
        lastSwitchTime = 0f;
    }

    // Update is called once per x amount of time
    void FixedUpdate()
    {
        playerTargetDistance = Vector3.Distance(playerTarget.position, transform.position);
        if (playerTargetDistance < attackDistance)
        {
            myRender.material.color = Color.red;
            print("Attaaaacckkkk!");
        }
        else if (playerTargetDistance < enemyLookDistance)
        {   
            myRender.material.color = Color.yellow;
            print("Be alert!");
        }
        else
        {
            myRender.material.color = Color.blue;
            print("At ease, soldier.");
        }
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