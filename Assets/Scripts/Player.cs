using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //0 means on the ground, 1 means single jump, 2 means double jump
    public int Jumpstate = 0; 
    
    //Floats
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    //Stats 
    public int curHealth;
    public int maxHealth = 100; 
    
    //References
    private Rigidbody2D rb2d;
    private Animator anim;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;



    }


    void Update()
    {

        anim.SetInteger("AnimationState", 0);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump")) 
        {
            if (Jumpstate == 0)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                Jumpstate = 1;
            }
            else
            {
                if (Jumpstate == 1)
                {
                    Jumpstate = 2;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1f);
                }
            }

            if (curHealth > maxHealth)
            {
                curHealth = maxHealth; 

            }
            if(curHealth <= 0)
            {
                Die(); 
            }
        }
    }

    void FixedUpdate()

    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");
        
        //fake friction to ease the x speed of the player
       
        {
            rb2d.velocity = easeVelocity; 
        }
       
        
        
        //moving the player
        rb2d.AddForce((Vector2.right * speed) * h);
        
        //limiting speed of the player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);








        } 

}

        void Die(){
        //Restart 
        Application.LoadLevel(Application.loadedLevel); 
        }

    }


