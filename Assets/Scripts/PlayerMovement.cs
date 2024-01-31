using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    Animator animator;
    float gravityScaleAtStart;
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
    // void OnFire(InputValue value)
    // {
    //     if (!isAlive)
    //     {
    //         return;
    //     }
    //     Instantiate(bullet, gun.position, transform.rotation);
    // }
    void OnGun(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        Instantiate(bullet, gun.position, transform.rotation);
    }
    public void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    void Run()
    {
        // xet toc do cua nhan vat thong qua tru x, dat trong luong nhan vat vao truc y
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRuning", playerHorizontalSpeed);
    }

    void OnJump(InputValue value)
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            /// do stuff
            myRigidbody.velocity += new Vector2(0f, jumSpeed);
        }

    }




    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            animator.SetBool("IsClimBing", false);
            return;
        }
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;
        bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("IsClimBing", playerHorizontalSpeed);

    }
    void FlipSprite()
    {
        bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }

    }
    public void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")) || myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Enemy"))
        || myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Water")) || myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            isAlive = false;
            animator.SetTrigger("Dyning");
            myRigidbody.velocity = deathKick;
            FindObjectOfType<Game_Session>().ProcessPlayDeath();
        }
    }


    /*
            if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            animator.SetBool("isRuning", true);
            transform.Translate(Time.deltaTime * 5, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            // neu scale >0 thi scale lon hon 0 else
            transform.localScale = scale;

        }
    */
    // public void moveLeft()
    // {
    //     if (Input.GetKey(KeyCode.Mouse0))
    //     {
    //         Debug.Log("click");
    //         myRigidbody.velocity = new Vector2(-3f, myRigidbody.velocity.y);
    //         bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    //         animator.SetBool("IsRuning", playerHorizontalSpeed);
    //         FlipSprite();
    //     }
    // }
    // public void moveRight()
    // {
    //     if (Input.GetKey(KeyCode.Mouse1))
    //     {
    //         Debug.Log("click");
    //         myRigidbody.velocity = new Vector2(3f, myRigidbody.velocity.y);
    //         bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    //         animator.SetBool("IsRuning", playerHorizontalSpeed);
    //         FlipSprite();
    //     }
    // }
    public void jumping()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        /// do stuff
        myRigidbody.velocity += new Vector2(0f, jumSpeed);
    }
    public void left()
    {
        Debug.Log("click");
        transform.Translate(-Time.deltaTime * 5, 0, 0);
        Vector2 scale = transform.localScale;
        scale.x *= scale.x > 0 ? 1 : -1;
        // neu scale >0 thi scale lon hon 0 else
        transform.localScale = scale;
        bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRuning", playerHorizontalSpeed);
        FlipSprite();
    }
    public void right()
    {
        Debug.Log("click");
        transform.Translate(Time.deltaTime * 5, 0, 0);
        Vector2 scale = transform.localScale;
        scale.x *= scale.x > 0 ? 1 : -1;
        // neu scale >0 thi scale lon hon 0 else
        transform.localScale = scale;
        bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRuning", playerHorizontalSpeed);
        FlipSprite();
    }
    public void guning()
    {
        if (!isAlive)
        {
            return;
        }
        Instantiate(bullet, gun.position, transform.rotation);
    }
}
