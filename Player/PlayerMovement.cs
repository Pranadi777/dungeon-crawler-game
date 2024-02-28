using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    

    private Rigidbody2D rb;
    // //Initialize the vector2d for the movement inputs
    private Vector2 move;
    //Initialize the speed float to dictate speed 
    [SerializeField] private float speed = 200f;
    private SpriteRenderer playerSprite;
    private GameObject sword;
    private SpriteRenderer swordSprite;
    private Vector2 mousePos;
    private Vector2 playerPos;
    [SerializeField] private float swordXPos = 0.45f;
    [SerializeField] private float swordYPos = -0.1f;
    
    



    // Start is called before the first frame update
    void Start()
    {    
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        sword = GameObject.FindGameObjectWithTag("Sword");
        swordSprite = sword.GetComponent<SpriteRenderer>();

        sword.transform.localPosition = new Vector3 (swordXPos,swordYPos,0f);

    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        
    }

    //FixedUpdate, is ran every frame before the update function
    void FixedUpdate()
    {
        //Force is tthe oonly way to have a knockback on the character
        rb.AddForce(move * speed * Time.fixedDeltaTime, ForceMode2D.Force);
        //rb.velocity = new Vector2(move.x * speed * Time.fixedDeltaTime, move.y * speed * Time.deltaTime);
        //rb.MovePosition(rb.position + (move * speed * Time.deltaTime));
        CheckForFlippingMouse();
    }

    private void CheckForFlippingMouse()
    {

        //for flipping
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //pplayer position
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (mousePos.x < playerPos.x)
        {
            playerSprite.flipX = true;
            swordSprite.flipX = true;
            sword.transform.localPosition = new Vector3 (-swordXPos,swordYPos,0f);;
        }
        else
        {
            playerSprite.flipX = false;
            swordSprite.flipX = false;
            sword.transform.localPosition = new Vector3 (swordXPos,swordYPos,0f);;
        }

    }





    // //Function for checking if thee sprrite flips accord to the direction movement
    // private void CheckForFlipping()
    // {
    //     bool movingRight = move.x > 0;
    //     bool movingLeft = move.x < 0;

    //     if (movingRight)
    //     {
    //         playerSprite.flipX = false;
    //     }
    //     if (movingLeft)
    //     {
    //         playerSprite.flipX = true;
    //     }

    // }   

}
