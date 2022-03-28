using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rockRigid;
   

    void Start()
    {
        rockRigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rockRigid.bodyType == RigidbodyType2D.Kinematic)
            rockRigid.velocity = new Vector2(rockRigid.velocity.x, speed);
    }

    

   
}
