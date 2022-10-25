using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private bool attacked = false;
    void Start()
    {
        newAttack();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void newAttack()
    {
        attacked = false;
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
