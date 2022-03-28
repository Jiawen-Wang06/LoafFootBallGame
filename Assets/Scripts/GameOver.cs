using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject player;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(checkgameover());
    }
    IEnumerator checkgameover()
    {
        if (player.GetComponent<Loaf>().heartCount == 0)
        {
           
            yield return new WaitForSeconds(0.5f);
            gameOver.GetComponent<RectTransform>().position = new Vector3(1000,500,0);
            
         
        }
        
    }
    

}
