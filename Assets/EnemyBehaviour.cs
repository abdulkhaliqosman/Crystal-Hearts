using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    EnemyState state;

    [SerializeField]
    float SightRadius;

    [SerializeField]
    float AttackRadius;

    [SerializeField]
    float AttackCooldown;

    [SerializeField]
    Color IdleColor;

    [SerializeField]
    Color ChaseColor;

    [SerializeField]
    Color AttackColor;


    float currentAttackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            default:
                break;
        }
    }

    void Idle()
    {
        // Play some animation or just walk around here

        // TRANSITIONS

        var player = PlayerBehaviour.instance;
        if(player)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 enemyPos = transform.position;

            if(Vector3.Distance(playerPos, enemyPos) < SightRadius)
            {
                state = EnemyState.Chase;
            }

        }
    }

    void Chase()
    {
        // Chase the player

        var player = PlayerBehaviour.instance;
        if (player)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 enemyPos = transform.position;

            if (Vector3.Distance(playerPos, enemyPos) > SightRadius)
            {
                state = EnemyState.Idle;
            }

            if (Vector3.Distance(playerPos, enemyPos) < AttackRadius)
            {
                state = EnemyState.Attack;
            }
        }
    }

    void Attack()
    {
        var player = PlayerBehaviour.instance;
        if (player)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 enemyPos = transform.position;

            if (Vector3.Distance(playerPos, enemyPos) > AttackRadius)
            {
                state = EnemyState.Chase;
            }
        }
    }

}
