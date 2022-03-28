using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public float speed;
    private Rigidbody2D rabitbody;
    private Transform rabittrans;

    [SerializeField]
    private GameObject rabbit;
    private string RABBIT_TAG = "Rabbit";
    void Awake()
    {
        rabitbody = GetComponent<Rigidbody2D>();
        rabittrans = GetComponent<Transform>();
        
        
        rabitbody.freezeRotation = true;
        
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rabittrans.localScale.x > 0)
        {
            speed = -3f;
        }
        else
        {
            speed = 3f;
        }
        rabitbody.velocity = new Vector2(speed, rabitbody.velocity.y);
        //Debug.Log("Rabit Speed: "+ speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(RABBIT_TAG))
        {
            rabbit.transform.localScale = new Vector3(-(rabbit.transform.localScale.x), rabbit.transform.localScale.y, rabbit.transform.localScale.z);
        }
        
    }
}
