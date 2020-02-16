using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    PlayerScript player;
    Animator anim;
    AnimationClip jumpTime, landTime;
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

    public void Walk(bool walking)
    {
        anim.SetBool("Walking", walking);
    }
}
