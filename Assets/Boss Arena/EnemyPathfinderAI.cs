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
    //public Vector3 com;
    Rigidbody theRigidbody;
    Renderer myRender;
    public float playerTargetDistance;
    public Transform playerTarget;
//intialize vector3
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
        //theRigidbody.centerOfMass = com;

        //attempt 2
        //theRigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        
        playerTargetDistance = 0f;
        enemyLookDistance = 10f;
        attackDistance = 8f;
        enemyMovementSpeed = 0.6f;
        goRight = false;
        speed = 1.5f;
        interval = 2f;
        lastSwitchTime = 0f;
        //sets movedirection to new vector object that stores x y z variables
        moveDirection = new Vector3(5,0,5);
    }

    // Update is called once per x amount of time
    void FixedUpdate()
    {
        playerTargetDistance = Vector3.Distance(playerTarget.position, transform.position);
        if (playerTargetDistance < attackDistance)
        {
            myRender.material.color = Color.red;
            print("Attaaaacckkkk!");
            transform.position += moveDirection * speed * Time.deltaTime;
            Debug.Log(moveDirection);
            //theRigidbody.AddForce(transform.forward * enemyMovementSpeed, ForceMode.VelocityChange);
            
            // this is what we tried to make the enemy not fall over 
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;    
        
        }
        else if (playerTargetDistance < enemyLookDistance)
        {   
            myRender.material.color = Color.yellow;
            print("Be alert!");
            //rotate towards player in alert state
            Quaternion rotation = Quaternion.LookRotation(playerTarget.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation , rotation, Time.deltaTime * damping);
            speed = 0f;       
        }
        else
        {
            myRender.material.color = Color.blue;
            print("At ease, soldier.");
            speed = 1.5f;
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