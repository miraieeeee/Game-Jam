using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public PlayerMovement player;
    GameObject Boss;
    public GameManagement man;
    Transform enemy, soldier;

    void Start()
    {
        Boss = gameObject;
        enemy = Boss.transform;
        soldier = player.Obj.transform;
    }

    void Update()
    {
        if (man.Exists)
        {
            enemy.position = Vector3.Lerp(enemy.position, soldier.position, man.Velocity);
        }
    }
}
