using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossManage : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private Transform playerT;
    private float distance = 3;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        playerT = player.GetComponent<Transform>();
        float bossX = this.gameObject.transform.position.x;
        if (Mathf.Abs(playerT.position.x - bossX) > distance)
        {
            if (bossX > playerT.position.x)
            {
                this.gameObject.transform.Translate(new Vector2(-speed, 0));
            }
            if (bossX < playerT.position.x)
            {
                this.gameObject.transform.Translate(new Vector2(speed, 0));
            }
        }
    }
}
