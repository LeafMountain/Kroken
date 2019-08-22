﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorBoatScript : AIBase, IDamageable
{
   

    
    void Start()
    {
        GetReferences();
        direction = GetRandomDirection();
        CheckFlipX(direction.x);
    }

    
    void Update()
    {
        UpdateSprite();
        Move();
        CheckBounderies();
    }


    public void OnAttacked(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            SpawnFloaters(2);
        }

    }
}
