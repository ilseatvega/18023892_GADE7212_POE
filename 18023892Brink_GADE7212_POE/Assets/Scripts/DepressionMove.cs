using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionMove : MonoBehaviour
{
    private Transform player;
    Animator NPCAnim;
    bool facingRight = false;
    float h;
    public Vector3 offset = new Vector3(2, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        NPCAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!NewDialogueManager.DLM.inDialogue)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        if (Mathf.Abs(player.transform.position.x - this.transform.position.x)> offset.x)
        {
            if (player.transform.position.x > this.transform.position.x && !facingRight)
            {
                FlipX();
            }
            else if (player.transform.position.x < this.transform.position.x && facingRight)
            {
                FlipX();
            }

            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position + offset, 0.02f);
            NPCAnim.SetBool("Walk", true);
        }
        else
        {
            NPCAnim.SetBool("Walk", false);
        }
    }

    private void FlipX()
    {
        //toggle - thats what the ! does
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;

        facingRight = !facingRight;
    }

}
