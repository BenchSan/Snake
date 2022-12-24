using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Lvl2Collision : Lvl
{
    
    public List<Obstacle> _obs;
    [SerializeField] private Snake snake;


        // Start is called before the first frame update
    void Awake()
    {
        Obstacles = new List<Vector2>();
        _obs = GameObject.FindObjectsOfType<Obstacle>().ToList();
        foreach (var obstacle in _obs)
        {
            Obstacles.Add(obstacle.transform.position);
        }
    }

    public void Start()
    {
        
    }

    private void Update()
    {
        LvlCollision();
    }


    public void LvlCollision()
    {
        foreach (var obstacle in Obstacles)
        {
            if (snake.gridPos == obstacle)
            {
                Destroy(snake.levelGrid.snake);
                foreach (GameObject o in snake.snakeBodyParts)
                {
                    Destroy(o);
                }
                if (Highscore.SetNewHighscore(GameHandle.GetScore()))
                {
                    snake.newHighScore.SetActive(true);
                    snake.newHighScore.GetComponent<Text>().text = "You made a new highscore! " + GameHandle.GetScore();
                }
                
                Debug.Log("Game Over!");
                snake.gameOver.SetActive(true);
            }
            
            }
        }
    }

