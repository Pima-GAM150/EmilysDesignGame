﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FleeAction : BaseAction
{
   //public List<BaseFactor> Factors;

    override public int GetRank(GameObject aiToCheck)
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

    override public int GetWeight(GameObject aiToCheck)
    {
        //sum of bonuses * product of multipliers
        var weight = 0;

        foreach (var factor in Factors)
        {
            weight += factor.GetFactorBonus(aiToCheck) * factor.GetFactorMultiplier(aiToCheck);
        }

        return weight;
    }

    override public void Run(GameObject ai)
    {
        var mySettings = ai.GetComponent<AI>();

        mySettings.CanPerformAction = false;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = transform.position - player.transform.position;

        direction = direction * 2;

        AIManager aiManager = ai.GetComponent<AIManager>();

        aiManager.agent.destination = direction;

        mySettings.CanPerformAction = true;

        //Remove this script from its parent
        Destroy(this);
    }
}

