using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {

    public AudioClip playerJump;
    public AudioClip playerShoot;
    public float movementSpeed = 6f;
    private bool grounded = true;
    private bool move = true;
    private ParallaxController _parallaxController;

    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        _parallaxController = GetComponent<ParallaxController>();
    }

	// Update is called once per frame
	void Update () {
        Movement();
        float x = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(x, 0f);
        //transform.Translate(movement * movementSpeed * Time.deltaTime);
        if (move == true)
        {
            _parallaxController.Scroll(movement *= -1);
        }  
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerShoot != null)
            {
                AudioSource.PlayClipAtPoint(playerShoot, transform.position);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("shoot", true);
            movementSpeed = 0f;
            move = false;
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("shoot", false);
            movementSpeed = 6f;
            move = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (grounded == true)
            {
                if (playerJump != null)
                {
                    AudioSource.PlayClipAtPoint(playerJump, transform.position);
                }
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1250));
            }
        }
        if(Input.GetKey (KeyCode.D))
        {
            transform.localScale = new Vector3(-3, 3, 3);
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            anim.SetInteger("walking", 1);
        }

       if(Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("walking", 0);
        }

        if(Input.GetKey (KeyCode.A))
        {
            transform.localScale = new Vector3(3, 3, 3);
            transform.Translate(-Vector2.right * movementSpeed * Time.deltaTime);
            anim.SetInteger("walking", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("walking", 0);
        }
    }
}
