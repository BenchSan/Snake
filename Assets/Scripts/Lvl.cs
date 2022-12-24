using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lvl : MonoBehaviour
{
    public List<Vector2> Obstacles;
    public static Lvl Singleton;
    private void Awake()
    {
        Singleton = this;
    }

}
