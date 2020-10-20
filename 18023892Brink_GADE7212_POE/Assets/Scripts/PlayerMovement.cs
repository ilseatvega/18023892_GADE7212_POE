using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [Range(0.01f, 0.5f)] [SerializeField] private float movementSmoothing;
    public LayerMask whatIsGround;
    Animator playerAnim;

    bool facingRight = true;
    float h;

    //System.Random rnd = new System.Random();

    private void Start()
    {
        Application.targetFrameRate = 144;
        playerAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("Walk", true);
        }
        else
        {
            playerAnim.SetBool("Walk", false);

            //StartCoroutine(Idle());
        }

        if (h < 0 && facingRight)
        {
            FlipX();
        }
        else if (h > 0 && !facingRight)
        {
            FlipX();
        }

        Vector3 refer = Vector3.zero;
        Vector3 targetVelocity = new Vector2(h * moveSpeed * 10 * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().velocity = Vector3.SmoothDamp(GetComponent<Rigidbody2D>().velocity, targetVelocity, ref refer, movementSmoothing);
    }

    private void FlipX()
    {
        //toggle - thats what the ! does
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;

        facingRight = !facingRight;
    }

    //void RepeatIdle()
    //{
    //    StartCoroutine(Idle());
    //}

    //IEnumerator Idle()
    //{
    //    playerAnim.Play("Base Layer.Idle");
    //    yield return new WaitForSeconds(5f);
    //    RepeatIdle();
    //    yield return null;
    //}
}
