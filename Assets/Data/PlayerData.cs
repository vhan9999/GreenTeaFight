using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerDataScriptableObject", order = 1)]
public class PlayerData : ScriptableObject
{
    public float MoveSpeed;
    public float JumpSpeed;
    public Queue<GameObject> bulletList = new Queue<GameObject>();
}

