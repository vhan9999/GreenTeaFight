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
        Attack = 3,
        Dash = 4
    }
    PlayerState nowPlayerState = PlayerState.Idle;
    //public PlayerAttack attack;
    private Rigidbody2D Rigidbody;
    private bool TouchGround;
    private bool Dashing;
    private int DashCounter;
    private Vector2 DashTarget;
    public GameObject PastPlayer;
    public PlayerData data;
    //public GameObject attack;

    public Animator playerAction;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        playerAction = gameObject.GetComponent<Animator>();
        NewGame();
        data.pastLocal.Enqueue(new Vector2(
            transform.position.x,
            transform.position.y
        ));
    }

    // Update is called once per frame
    void Update()
    {
        if (data.QueueTime < data.DashBackTime * 2 - data.DashCd)
        {
            data.QueueTime += Time.deltaTime;
            data.pastLocal.Enqueue(new Vector2(
                transform.position.x,
                transform.position.y
            ));
        }
        else
        {
            data.pastLocal.Enqueue(new Vector2(
                transform.position.x,
                transform.position.y
            ));
            PastPlayer.transform.position = data.pastLocal.Dequeue();
        }

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
                Attack();
                nowPlayerState = PlayerState.Idle;
                /*
                if ( == playerAction.GetCurrentAnimatorStateInfo(0))
                {
                    nowPlayerState = PlayerState.Idle;

                }
                */
                break;
            case PlayerState.Dash:
                Rigidbody.gravityScale = 0;
                //Debug.Log(DashTarget);
                if (DashCounter >= data.DashFrameMoveTimes)
                {
                    Rigidbody.gravityScale = 1;
                    Dashing = false;
                    nowPlayerState = PlayerState.Idle;
                    DashCounter = 0;
                }
                else
                {
                    Dash(DashTarget);
                    DashCounter++;
                }
                break;
        }
        AllInput();
    }
    private void Dash(Vector2 DashTarget)
    {
        transform.position = (Vector2)transform.position + DashTarget;
    }

    private void AllInput()
    {

        if (!Dashing)
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
            if (Input.GetKey("k") && Dashing == false)
            {
                DashTarget = (data.pastLocal.Dequeue() - (Vector2)transform.position) / data.DashFrameMoveTimes;
                Dashing = true;
                nowPlayerState = PlayerState.Dash;
                //attack.SetBool("Attack", true);
            }

        }
        else
        {


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
        Dashing = false;
        data.pastLocal.Clear();
        data.QueueTime = 0;
        TouchGround = false;
        nowPlayerState = PlayerState.Idle;
        DashCounter = 0;
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            TouchGround = true;
        }
    }
}
