﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FleeAction : BaseAction
{
   //public List<BaseFactor> Factors;

    override public int GetRank(AI aiToCheck)
    {
        var rank = 0;

        foreach (var factor in Factors)
        {
            if (factor.GetFactorRank(aiToCheck) > rank)
            {
                rank += factor.GetFactorRank(aiToCheck);
            }
        }

        return rank;
    }

    override public int GetWeight(AI aiToCheck)
    {
        //sum of bonuses * product of multipliers
        var weight = 0;

        foreach (var factor in Factors)
        {
            weight += factor.GetFactorBonus(aiToCheck) * factor.GetFactorMultiplier(aiToCheck);
        }

        return weight;
    }

    override public void Run(AI ai)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = transform.position - player.transform.position;

        direction = direction * 2;

        ai.aiManager.agent.destination = direction;

        //Remove this script from its parent
        Destroy(this);
    }
}

