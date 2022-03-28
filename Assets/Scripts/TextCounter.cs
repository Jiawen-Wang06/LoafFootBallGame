using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private Text p1Legend;
    [SerializeField]
    private Text p2Legend;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1Legend.text = player1.GetComponent<Loaf>().loafCarrotCount.ToString();
       
        p2Legend.text = player2.GetComponent<Loaf>().reinCarrotCount.ToString();
        
    }
}
