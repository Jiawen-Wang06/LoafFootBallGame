using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loaf : MonoBehaviour
{
    // Start is called before the first frame update


    private Rigidbody2D loafballRgbd2D;
    private Rigidbody2D reindeerballRgbd2D;
    private Rigidbody2D loafRgbd2D;
    private Rigidbody2D reindeerRgbd2D;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject loafball;
    [SerializeField]
    private GameObject reindeerball;

    [SerializeField]
    private AudioSource[] audioSouces;
    private AudioSource jump, bounce, hurt, carrot, gameover;



    [SerializeField]
    private float jumpForce = 2.5f;
    private string CARROT_TAG = "Carrot";
    private string CELLING_TAG = "Ceiling";
    private string RABBIT_TAG = "Rabbit";
    private string BOTTOM_TAG = "Bottom";
    private string LOAF_BALL = "loafBall";
    private string REINDEER_BALL = "reindeerBall";
    private bool loafBallTouch;
    private bool reindeerBallTouch;
    private bool even;
    private float time;

    public int loafCarrotCount = 0;
    public int reinCarrotCount = 0;
    public int heartCount = 3;
    public bool loafDie = false;
    public bool reinDie = false;

    float speed = 2f;
    private void Awake()
    {

        player1.GetComponent<Rigidbody2D>().freezeRotation = true;
        player2.GetComponent<Rigidbody2D>().freezeRotation = true;
        loafRgbd2D = player1.GetComponent<Rigidbody2D>();
        reindeerRgbd2D = player2.GetComponent<Rigidbody2D>();

        loafballRgbd2D = loafball.GetComponent<Rigidbody2D>();
        reindeerballRgbd2D = reindeerball.GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        jump = audioSouces[0].GetComponent<AudioSource>();
        bounce = audioSouces[1].GetComponent<AudioSource>();
        hurt = audioSouces[2].GetComponent<AudioSource>();
        carrot = audioSouces[3].GetComponent<AudioSource>();
        gameover = audioSouces[4].GetComponent<AudioSource>();

        Physics2D.IgnoreCollision(player1.GetComponent<Collider2D>(), player2.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player1.GetComponent<Collider2D>(), reindeerball.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(player2.GetComponent<Collider2D>(), loafball.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(loafball.GetComponent<Collider2D>(), reindeerball.GetComponent<Collider2D>());

    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {

        playerJump();
        pushBall();
        move();
        pushPlayer(player1, player2);


    }

    void move()
    {


        var player1Move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        var player2Move = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0);

        player1.transform.position += player1Move * speed * Time.deltaTime;
        player2.transform.position += player2Move * speed * Time.deltaTime;

        //Flip player
        Vector3 p1characterScale = player1.transform.localScale;
        Vector3 p2characterScale = player2.transform.localScale;

        //Player 1 
        if (Input.GetAxis("Horizontal") < 0)
        {
            p1characterScale.x = -1.3f;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            p1characterScale.x = 1.3f;
        }
        player1.transform.localScale = p1characterScale;

        //Player 2
        if (Input.GetAxis("Horizontal2") < 0)
        {
            p2characterScale.x = -0.83f;
        }
        if (Input.GetAxis("Horizontal2") > 0)
        {
            p2characterScale.x = 0.83f;
        }
        player2.transform.localScale = p2characterScale;


    }
    void pushBall()
    {
        //Player 1
        float loafStartTime = 0f;
        if (loafBallTouch && Input.GetKeyDown(KeyCode.Space))
        {
            loafStartTime = Time.time;
        }
        if (loafBallTouch && Input.GetKeyUp(KeyCode.Space))
        {

            //Debug.Log((Time.time - startTime));
            loafBallTouch = false;

            float timediff = Time.time - loafStartTime;
            timediff = (timediff < 4) ? 6 : 8;
            loafStartTime = 0;
            if (player1.transform.localScale.x > 0)
            {
                loafballRgbd2D.AddForce(new Vector2(timediff / 4, timediff), ForceMode2D.Impulse);
            }
            else
            {
                loafballRgbd2D.AddForce(new Vector2(-timediff / 4, timediff), ForceMode2D.Impulse);
            }
        }

        //Player2
        float reindeerStartTime = 0f;
        if (reindeerBallTouch && Input.GetKeyDown(KeyCode.LeftShift))
        {
            reindeerStartTime = Time.time;
        }
        if (reindeerBallTouch && Input.GetKeyUp(KeyCode.LeftShift))
        {

            //Debug.Log((Time.time - startTime));
            reindeerBallTouch = false;

            float timediff = Time.time - reindeerStartTime;
            timediff = (timediff < 4) ? 6 : 8;
            reindeerStartTime = 0;
            if (player2.transform.localScale.x > 0)
            {
                reindeerballRgbd2D.AddForce(new Vector2(timediff / 4, timediff), ForceMode2D.Impulse);
            }
            else
            {
                reindeerballRgbd2D.AddForce(new Vector2(-timediff / 4, timediff), ForceMode2D.Impulse);
            }
        }
    }
    void playerJump()
    {


        //Player 1
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {

            loafBallTouch = false;
            if (player1.transform.localScale.x > 0)
            {
                loafRgbd2D.AddForce(new Vector2(0, jumpForce * 0.125f), ForceMode2D.Impulse);

            }
            else if (player1.transform.localScale.x < 0)
            {
                loafRgbd2D.AddForce(new Vector2(0, jumpForce * 0.125f), ForceMode2D.Impulse);

            }


            bounce.Play();
            // Debug.Log("I'm short jump");
        }

        //Player 2
        if (Input.GetKeyUp(KeyCode.W))
        {

            reindeerBallTouch = false;
            if (player2.transform.localScale.x > 0)
            {
                reindeerRgbd2D.AddForce(new Vector2(0, jumpForce * 0.125f), ForceMode2D.Impulse);
            }
            else if (player2.transform.localScale.x < 0)
            {
                reindeerRgbd2D.AddForce(new Vector2(0, jumpForce * 0.125f), ForceMode2D.Impulse);
            }


            bounce.Play();
            // Debug.Log("I'm short jump");
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(CELLING_TAG))
        {
            var colliderName = collision.otherCollider.name;
            if (colliderName == "LoafNoNose")
            {
               
                loafDie = true;
                player1.GetComponent<SpriteRenderer>().flipY = true;
                player1.GetComponent<Rigidbody2D>().velocity = new Vector2(player1.GetComponent<Rigidbody2D>().velocity.x, -5f);
            }
            else if (colliderName == "Reindeer")
            {
                
                reinDie = true;
                player2.GetComponent<SpriteRenderer>().flipY = true;
                player2.GetComponent<Rigidbody2D>().velocity = new Vector2(player2.GetComponent<Rigidbody2D>().velocity.x, -5f);
            }
            //gameover.Play();
            //PlayerDead();

        }

        if (collision.gameObject.CompareTag(LOAF_BALL))
        {
            var colliderName = collision.otherCollider.name;
            if (colliderName == "LoafNoNose")
            {
                loafBallTouch = true;
            }

        }

        if (collision.gameObject.CompareTag(REINDEER_BALL))
        {
            var colliderName = collision.otherCollider.name;
            if (colliderName == "Reindeer")
            {
                reindeerBallTouch = true;
            }

        }

        if (collision.gameObject.CompareTag(RABBIT_TAG))
        {



        }

        if (collision.gameObject.CompareTag(BOTTOM_TAG))
        {
            var colliderName = collision.otherCollider.name;
           
            if (colliderName == "LoafNoNose" || colliderName == "LoafBall")
            {
                loafDie = true;
                player1.GetComponent<Rigidbody2D>().rotation = -90f;
               
            }
            else if (colliderName == "Reindeer" || colliderName == "RenBall")
            {
                
                reinDie = true;
                player2.GetComponent<Rigidbody2D>().rotation = -90f;
               
            }
            //gameover.Play();


        }



    }

    void pushPlayer(GameObject p1, GameObject p2)
    {
       
        float dis = (p1.transform.position - p2.transform.position).magnitude;
        if(dis > 20)
        {
            GameObject push = (p1.transform.position.x < p2.transform.position.x) ? p1 : p2;
            push.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.05f, 0), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CARROT_TAG))
        {
            string name = this.name;
            if(name == "LoafNoNose")
            {
               
                Destroy(collision.gameObject);
                loafCarrotCount++;
                carrot.Play();
            }else if(name == "Reindeer")
            {
                Destroy(collision.gameObject);
                reinCarrotCount++;
                carrot.Play();
            }
            

        }



    }

}
