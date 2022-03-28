using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{
    // Start is called before the first frame update
    //private string PLAYER_TAG = "Player";
    [SerializeField]
    private GameObject wingame;
    [SerializeField]
    private Transform endline;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject p1ball;
    [SerializeField]
    private GameObject p2ball;
    [SerializeField]
    private Text text;

    [SerializeField]
    private AudioSource winSound;
    [SerializeField]
    private AudioSource bkSound;

    bool check = true;


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (check)
            StartCoroutine(checkwin());
        else
            StopCoroutine(checkwin());
       
    }



    IEnumerator checkwin()
    {
        //Debug.Log("WInGame: "+player1.GetComponent<Loaf>().loafDie);
        // Debug.Log(player2.GetComponent<Loaf>().reinDie);
        if ((player1.GetComponent<Rigidbody2D>().position.x >= (endline.position.x) && p1ball.GetComponent<Rigidbody2D>().position.x >= (endline.position.x)) || player1.GetComponent<Loaf>().reinDie || player2.GetComponent<Loaf>().reinDie || p2ball.GetComponent<Loaf>().reinDie)
        {
            bkSound.Stop();
            check = false;
            yield return new WaitForSeconds(0.5f);

            wingame.GetComponent<RectTransform>().position = new Vector3(1000, 500, 0);
            text.text = "Loaf Win!";
            
            winSound.Play();
            //StopCoroutine(checkwin());
            check = false;


        }
        else if ((player2.GetComponent<Rigidbody2D>().position.x >= (endline.position.x) && p2ball.GetComponent<Rigidbody2D>().position.x >= (endline.position.x)) || player2.GetComponent<Loaf>().loafDie || player1.GetComponent<Loaf>().loafDie || p1ball.GetComponent<Loaf>().loafDie)
        {
            bkSound.Stop();
            check = false;
            yield return new WaitForSeconds(0.5f);
            wingame.GetComponent<RectTransform>().position = new Vector3(1000, 500, 0);
            text.text = " Seven Win!";
            
            winSound.Play();
            //StopCoroutine(checkwin());
          
        }

    }


}
