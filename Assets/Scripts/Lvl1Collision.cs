using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lvl1Collision : Lvl
{
    private List<Obstacle> _obs;
    // Start is called before the first frame update
    void Start()
    {
        Obstacles = new List<Vector2>();
        _obs = GameObject.FindObjectsOfType<Obstacle>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
