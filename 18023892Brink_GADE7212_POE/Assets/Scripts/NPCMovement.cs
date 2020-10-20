using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    //basic idea for wandering NPCs taken from
    //https://forum.unity.com/threads/making-npcs-wander-in-2d.524950/
    
    float movespeed = 2f;
    internal Transform thisTransform;

    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;

    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.zero, Vector3.zero };
    internal int currentMoveDirection;

    Animator NPCAnim;

    bool facingRight = false;

    //
    void Start()
    {
        thisTransform = this.transform;
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
        //ChooseMoveDirection();

        NPCAnim = GetComponent<Animator>();
    }

    //
    private void Update()
    {
        if (currentMoveDirection == 0 || currentMoveDirection == 1)
        {
            NPCAnim.SetBool("Walk", true);
        }
        else
        {
            NPCAnim.SetBool("Walk", false);
        }
        //move left
        if (thisTransform.position.x <= -3.1)
        {
            decisionTimeCount = 0f;
            thisTransform.position += moveDirections[0] * Time.deltaTime * movespeed;
        }
        //move right
        else if (thisTransform.position.x >= 8.45)
        {
            decisionTimeCount = 0f;
            thisTransform.position += moveDirections[1] * Time.deltaTime * movespeed;
        }
        //random
        else
        {
            thisTransform.position += moveDirections[currentMoveDirection] * Time.deltaTime * movespeed;

            if (decisionTimeCount > 0)
            {
                decisionTimeCount -= Time.deltaTime;
            }
            else
            {
                //Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
                decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

                //Choose a movement direction, or stay in place
                ChooseMoveDirection();
                Vector2 newPos = new Vector2(transform.position.x, Mathf.Clamp(transform.position.x, -2.85f, 8.45f));
            }
        }
    }

    void ChooseMoveDirection()
    {
        // Choose whether to move sideways
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
        if (currentMoveDirection == 1 && facingRight)
        {
            FlipX();
        }
        else if (currentMoveDirection == 0 && !facingRight)
        {
            FlipX();
        }
    }

    private void FlipX()
    {
        //toggle - thats what the ! does
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;

        facingRight = !facingRight;
    }
}
