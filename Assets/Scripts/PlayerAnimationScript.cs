using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    PlayerScript player;
    Animator anim;
    SpriteRenderer sprite;

    void Awake()
    {
        player = GetComponent<PlayerScript>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.lado == -1)
        {
            sprite.flipX = true;
        }
        else if (player.lado == 1)
        {
            sprite.flipX = false;
        }        
    }

    public void Walk(bool walk)
    {
        anim.SetBool("Walking", walk);
    }

    public void Jump()
    {
        anim.SetBool("Landing", false);
        anim.SetBool("Falling", false);
        anim.SetBool("Jumping", true);
    }

    public void Land()
    {
        anim.SetBool("Falling", false);
        anim.SetBool("Jumping", false);
        anim.SetBool("Landing", true);
    }

    public void Fall()
    {
        anim.SetBool("Jumping", false);
        anim.SetBool("Landing", false);
        anim.SetBool("Falling", true);
    }
}
