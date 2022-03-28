using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D ballRigid;
    private string PLAYER_TAG = "Player";
    void Start()
    {
        ballRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            ballRigid.bodyType = RigidbodyType2D.Dynamic;

            ballRigid.AddForce(new Vector2(Random.Range(-10f,10f), 0f), ForceMode2D.Impulse);
        }
    }
    
}
