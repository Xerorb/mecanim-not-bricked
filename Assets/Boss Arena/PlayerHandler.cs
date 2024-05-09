using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    private AudioSource source;
    public AudioClip lose;
    public AudioClip win;

    public Text gameOverMessage;    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
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
            source.PlayOneShot(win, 1.0f);
            Destroy(collision.collider.transform.parent.gameObject);
            Destroy(collision.collider.gameObject);
            // GameManager.score += 100;
            
            }
        }
    }
}
