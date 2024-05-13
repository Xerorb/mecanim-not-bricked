using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyHandler : MonoBehaviour {

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

    // Use this for initialization
    void Start()
    {
        goRight = false;
        speed = 1.5f;
        interval = 2f;
        lastSwitchTime = 0f;
        myRender = GetComponent<Renderer>();
        theRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (goRight == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
        }

        if (Time.time > lastSwitchTime + interval)
        {
            lastSwitchTime = Time.time;
            goRight = !goRight;
        }

        playerTargetDistance = Vector3.Distance(playerTarget.position, transform.position);

        if (playerTargetDistance < attackDistance)
        {
            print("Attaaaacckkkk!");
            myRender.material.color = Color.red;
            theRigidbody.AddForce(transform.forward * enemyMovementSpeed, ForceMode.VelocityChange);
            Quaternion rotation = Quaternion.LookRotation(playerTarget.position - transform.position);
            //Reset rotation on the x and z rotation
            rotation.x = transform.rotation.x;
            rotation.z = transform.rotation.z;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            speed = 0f;
        }
        else if (playerTargetDistance < enemyLookDistance)
        {
            print("Be alert!");
            myRender.material.color = Color.yellow;
            Quaternion rotation = Quaternion.LookRotation(playerTarget.position - transform.position);
            //Reset rotation on the x and z rotation
            rotation.x = transform.rotation.x;
            rotation.z = transform.rotation.z;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            speed = 0f;
        }
        else
        {
            print("At ease, soldier.");
            myRender.material.color = Color.blue;
            speed = 1.5f;
        }
    }
}
