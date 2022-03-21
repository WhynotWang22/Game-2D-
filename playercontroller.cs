using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class playercontroller : MonoBehaviour
{
    //bienhinh
    public SpriteRenderer SpriteRenderer;
    public Sprite SmileSprite, SabSprite;
    //
    private Rigidbody2D rb;
    private Collider2D col;
    private Animator animator;
    ///
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float moveSpeed;

    [SerializeField] private  float Speed = 5f;
    [SerializeField] private  LayerMask matdat;
    [SerializeField] private  float jumpost = 5f;
    [SerializeField] private  int cherries = 0;
    [SerializeField] private  Text cherryText;
    [SerializeField] private  GameObject fire;//ban truong
    

  
    // Start is called before the first frame update
    void Start()
    {
        //
        SpriteRenderer = this.GetComponent<SpriteRenderer>();
        //
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Monment();

    }

    

    private void Monment()
    {
        
        float Huong = Input.GetAxis("Horizontal");
        if (Huong < 0)
        {
            animator.SetInteger("sate", 1);
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);

        }
        else if (Huong > 0)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            animator.SetInteger("sate", 1);
        }
        if (Input.GetButtonDown("Jump") && col.IsTouchingLayers(matdat)) 
            
        {

            rb.velocity = new Vector2(rb.velocity.x, (jumpost) * 2);//nhay nhan 2
            animator.SetInteger("sate",2);

        }
        else if (Input.GetButtonDown("Fire1"))//ban truong
        {
            Instantiate(fire, gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.G))//phong to
        {
            transform.localScale = new Vector2(3, 3);
        }
        else if (Input.GetKeyUp(KeyCode.G))//phong to
        {
            transform.localScale = new Vector2(1, 1);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            cherries += 1;
            cherryText.text = cherries.ToString();  
        }
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed, _rigidbody.velocity.y, joystick.Vertical * moveSpeed);
        if(joystick.Horizontal !=0 || joystick.Vertical !=0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);

        }
    }

}

