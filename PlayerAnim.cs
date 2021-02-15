using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnim : MonoBehaviour
{

    Animator anim;
    public PlayerMovement player;
    public bool usingCandle;

    //Vector true == right, false == left!

    void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetBool("Vector", false);
    }

    void FixedUpdate()
    {
        if (player.rb2d.velocity.x < 0) 
        {
            anim.SetBool("Vector", false);
        }
        else if (player.rb2d.velocity.x >= 0)
        {
            anim.SetBool("Vector", true);
        }
        else if (!player.Jump)
        {
            anim.SetBool("isJumping", true);
        }
        else if (player.Jump)
        {
            anim.SetBool("isJumping", false);
        }
        else if (player.hAxis != 0 && player.Jump)
        {
            anim.SetBool("isRunning", true);
        }
        else if (player.hAxis == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("Candle", true);
            usingCandle = true;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            anim.SetBool("Candle", false);
            usingCandle = false;
        }
    }
}
