using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid
{
    public Vector2 foodGridPos;
    private int height;
    private int width;
    private GameObject foodGameObject;
    public Snake snake;
    private List<Vector2> obstacles;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    private void SpawnFood()
    {
        if (obstacles == null)
        {
            obstacles = GameObject.FindObjectOfType<Lvl>().Obstacles;
        }
     cycle :   while(true)
     {
         foodGridPos = new Vector2(Random.Range(-width, width), Random.Range(-height, height));
         if(snake.GetGridPos() == foodGridPos)
             continue;
         foreach (GameObject o in snake.snakeBodyParts)
         {
             if((Vector2)o.transform.position == foodGridPos)
                 goto cycle;
         }

         foreach (var vector in obstacles)
         {
             if(foodGridPos.x == vector.x &&foodGridPos.y == vector.y)
                 goto cycle;
         }
         break;
     } 
     foodGameObject = new GameObject("Food",typeof(SpriteRenderer));
     foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.food;
     foodGameObject.transform.position = new Vector3(foodGridPos.x,foodGridPos.y, -0.3f);
    }

    public void SnakeMoved(Vector2Int snakeGridPos)
    {
        if (snakeGridPos == foodGridPos)
        {
            Object.Destroy(foodGameObject);
            snake.snakeBodySize++;
            GameHandle.AddScore();
            SpawnFood();
        }
    }
}
