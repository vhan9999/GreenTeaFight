using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    enum PlayerState
    {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Attack = 3
    }
    PlayerState nowPlayerState = PlayerState.Idle;
    //public PlayerAttack attack;
    private Rigidbody2D Rigidbody;
    private bool TouchGround;
    public PlayerData data;
    //public GameObject attack;

    public Animator playerAction;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        playerAction = gameObject.GetComponent<Animator>();
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(nowPlayerState);
        playerAction.SetInteger("State", (int)nowPlayerState);
        switch (nowPlayerState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Walk:
                break;
            case PlayerState.Run:
                break;
            case PlayerState.Attack:
                Debug.Log(playerAction.GetCurrentAnimatorStateInfo(0).IsName("AttackEnd"));
                if (playerAction.GetCurrentAnimatorStateInfo(0).IsName("AttackEnd"))
                {
                    nowPlayerState = PlayerState.Idle;
                }


                Attack();
                /*
                if ( == playerAction.GetCurrentAnimatorStateInfo(0))
                {
                    nowPlayerState = PlayerState.Idle;

                }
                */
                break;
        }
        AllInput();
    }

    private void AllInput()
    {

        if (Input.GetKey("d") && Input.GetKey("a"))
        {
            Move(0.0f, Rigidbody.velocity.y);
            //Rigidbody.velocity = new Vector2(0.0f, Rigidbody.velocity.y);
        }
        else if (Input.GetKey("d"))
        {
            Move(data.MoveSpeed, Rigidbody.velocity.y);
            //Rigidbody.velocity = new Vector2(data.MoveSpeed, Rigidbody.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            Move(-data.MoveSpeed, Rigidbody.velocity.y);
            //Rigidbody.velocity = new Vector2(-data.MoveSpeed, Rigidbody.velocity.y);
        }
        else
        {
            Move(0.0f, Rigidbody.velocity.y);
            //Rigidbody.velocity = new Vector2(0.0f, Rigidbody.velocity.y);
        }
        if (Input.GetKey("w") && TouchGround)
        {
            Move(Rigidbody.velocity.x, data.JumpSpeed);
            //Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, data.JumpSpeed);
            TouchGround = false;
        }

        if (Input.GetKey("j"))
        {
            nowPlayerState = PlayerState.Attack;
            //attack.SetBool("Attack", true);
        }

    }
    private void Move(float x, float y)
    {

        Rigidbody.velocity = new Vector2(x, y);
        //

    }
    public void Attack()
    {
    }
    public void NewGame()
    {
        gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
        TouchGround = false;
        nowPlayerState = PlayerState.Idle;
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            TouchGround = true;
        }
    }
}
