using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerAttack attack;
    private Rigidbody2D Rigidbody;
    private bool TouchGround;
    public PlayerData data;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Input.GetKey("d") && Input.GetKey("a"))
        {
            Rigidbody.velocity = new Vector2(0.0f, Rigidbody.velocity.y);
        }
        else if (Input.GetKey("d"))
        {
            Rigidbody.velocity = new Vector2(data.MoveSpeed, Rigidbody.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            Rigidbody.velocity = new Vector2(-data.MoveSpeed, Rigidbody.velocity.y);
        }
        else
        {
            Rigidbody.velocity = new Vector2(0.0f, Rigidbody.velocity.y);
        }
        if (Input.GetKey("w") && TouchGround)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, data.JumpSpeed);
            TouchGround = false;
        }

        if (Input.GetKey("j"))
        {
            attack.newAttack();
        }
    }
    public void NewGame()
    {
        gameObject.transform.Translate(0.0f, 0.0f, 0.0f);
        TouchGround = false;
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            TouchGround = true;
        }
    }
}
