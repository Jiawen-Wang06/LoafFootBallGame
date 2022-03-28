using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpinner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] rabbit_reference;
    private GameObject spawnRabbit;
    [SerializeField]
    private Transform leftpos, rightpos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoopRabbit();
    }

    void LoopRabbit()
    {
        foreach (var rabbit in rabbit_reference)
        {
            //Debug.Log("I'm in foreach");
            float rabbit_x = rabbit.transform.position.x;
            float leftpos_x = leftpos.position.x;
            float rightpos_x = rightpos.position.x;
            
            if (rabbit_x <= leftpos_x && rabbit.transform.localScale.x>0)
            {
                rabbit.transform.position = leftpos.position;
                rabbit.transform.localScale = new Vector3(-(rabbit.transform.localScale.x), rabbit.transform.localScale.y,rabbit.transform.localScale.z);
                rabbit.GetComponent<Rabbit>().speed = 3f;
                

            }
            else if (rabbit_x >= rightpos_x && rabbit.transform.localScale.x < 0)
            {
                rabbit.transform.position = rightpos.position;
                rabbit.transform.localScale = new Vector3(-(rabbit.transform.localScale.x), rabbit.transform.localScale.y, rabbit.transform.localScale.z);
                rabbit.GetComponent<Rabbit>().speed = -3f;
               

            }
            
        }
        
    }
   
}
