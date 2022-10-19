using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private bool attacked = false;
    public float size = 1;
    private int counter = 0;
    private float[] attackTimes ={
        0.0f,
        0.1f,
        0.2f,
        0.3f,
        0.4f,
        0.5f
    };
    private Vector3[] attack_location = {
        new Vector3(1,1,0),
        new Vector3(2,0.5f,0),
        new Vector3(3,0,0),
        new Vector3(2,-0.5f,0),
        new Vector3(1,-1,0) };
    private float keepTime = 5;
    private float nowTime = 0;
    void Start()
    {
        newAttack();
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;

        if (nowTime >= attackTimes[counter])
        {
            Debug.Log(nowTime);
            Attack(counter);
            counter += 1;
        }
    }
    void Attack(int counter)
    {
        if (counter == 0)
        {
            transform.position = new Vector3(
                Player.transform.position.x + attack_location[counter].x * size,
                Player.transform.position.y + attack_location[counter].y * size,
                Player.transform.position.z
            );
            transform.Rotate(0, 0, 0, Space.Self);
        }
        else if (counter == 1)
        {
            transform.position = new Vector3(
                Player.transform.position.x + attack_location[counter].x * size,
                Player.transform.position.y + attack_location[counter].y * size,
                Player.transform.position.z
                );
            transform.Rotate(0, 0, -45, Space.Self);
        }
        else if (counter == 2)
        {
            transform.position = new Vector3(
                Player.transform.position.x + attack_location[counter].x * size,
                Player.transform.position.y + attack_location[counter].y * size,
                Player.transform.position.z
                );
            transform.Rotate(0, 0, 45, Space.Self);
        }
        else if (counter == 3)
        {
            transform.position = new Vector3(
                Player.transform.position.x + attack_location[counter].x * size,
                Player.transform.position.y + attack_location[counter].y * size,
                Player.transform.position.z
                );
            transform.Rotate(0, 0, 45, Space.Self);
        }
        else if (counter == 4)
        {
            transform.position = new Vector3(
                Player.transform.position.x + attack_location[counter].x * size,
                Player.transform.position.y + attack_location[counter].y * size,
                Player.transform.position.z
                );
            transform.Rotate(0, 0, -45, Space.Self);
        }
        else
        {
            this.gameObject.SetActive(false);

        }

    }
    public void newAttack()
    {
        attacked = false;
        counter = 0;
        nowTime = 0f;
        this.gameObject.SetActive(true);

        transform.position = new Vector3(
            Player.transform.position.x + attack_location[counter].x * size,
            Player.transform.position.y + attack_location[counter].y * size,
            Player.transform.position.z
        );
        transform.Rotate(0, 0, 0, Space.Self);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && attacked == false)
        {
            attacked = true;
            //enemy -HP
        }

    }
}
