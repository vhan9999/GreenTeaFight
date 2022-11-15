using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerDataScriptableObject", order = 1)]
public class PlayerData : ScriptableObject
{
    public float xMax;
    public float xMin;
    
    public float MoveSpeed;
    public float JumpSpeed;
    public float DashFrameMoveTimes;

    public Queue<Vector2> pastLocal = new Queue<Vector2>();
    public float DashCd;
    public float DashBackTime;
    public float QueueTime;

    public int PlayerDamege;

    public int EnemyHP;
}

