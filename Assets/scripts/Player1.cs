using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {

    public AudioClip playerJump;
    public AudioClip playerShoot;
    public float movementSpeed = 6f;
    private bool _grounded = true;
    private bool _move = true;
    private ParallaxController _parallaxController;
    [SerializeField] private bool _airControl = false;
    [SerializeField] private LayerMask m_WhatIsGround;

    private Animator _anim;
    private Rigidbody2D _rigidbody2D;

    // Use this for initialization
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
        if (_move == true)
        {
            _parallaxController.Scroll(movement *= -1);
        }  
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            _grounded = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            _grounded = false;
        }
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_grounded == true)
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
            _anim.SetInteger("walking", 1);
        }

       if(Input.GetKeyUp(KeyCode.D))
        {
            _anim.SetInteger("walking", 0);
        }

        if(Input.GetKey (KeyCode.A))
        {
            transform.localScale = new Vector3(3, 3, 3);
            transform.Translate(-Vector2.right * movementSpeed * Time.deltaTime);
            _anim.SetInteger("walking", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _anim.SetInteger("walking", 0);
        }
    }
}
