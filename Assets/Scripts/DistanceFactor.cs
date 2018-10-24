﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFactor : BaseFactor
{
    //max distance AI's attack can reach
    public AI ai;
    public int importance;
    public float pursuitRange;

    override public int GetFactorRank(AI aiToCheck)
    {
        if( GetDistToPlayer( aiToCheck ) < pursuitRange ) {
            abort = false;
            return importance;
        }

        abort = true;
        return 0;
        // if (ai != null)
        // {
        //     attackRange = GetComponent<AI>().AttackRange;
        // }
        // else
        // {
        //     // print("No AI found on MyObject for distance factor!");
        // }

        // RaycastHit hit;

        // //if AI sees player, it has a lower probability of searching for player
        // if (Physics.Raycast(transform.position, -Vector3.forward, out hit, 100.0f))
        // {
        //     if (hit.collider.gameObject.tag == "Player")
        //     {
        //         return 5;
        //     }
        // }

        // return 20;
    }

    // override public int GetFactorBonus(AI aiToCheck)
    // {
    //     return 1;
    // }

    // override public int GetFactorMultiplier(AI aiToCheck)
    // {
    //     //if player is within attack range, set weight to 0
    //     if (pursuitRange <= GetDistToPlayer( aiToCheck ) )
    //     {
    //         return 0;
    //     }

    //     return 1;
    // }

    float GetDistToPlayer( AI aiToCheck ) {
        return Vector3.Distance( PlayerManager.Instance.transform.position, aiToCheck.transform.position );
    }
}

