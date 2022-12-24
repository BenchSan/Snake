using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    public Vector2Int gridPos;
    private Vector2Int gridMoveDir;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    public LevelGrid levelGrid;
    [SerializeField] public GameObject gameOver;
    private int width = 14;
    private int height = 7;
    public int snakeBodySize;
    public List<GameObject> snakeBodyParts;
    [SerializeField] private GameObject snakeBody;
    [SerializeField] public GameObject newHighScore;

    public Vector2Int GetGridPos()
    {
        return gridPos;
    }
    private void Start()
    {
        gridPos = new Vector2Int(0, 0);
        gridMoveDir = new Vector2Int(0,1);
        gridMoveTimerMax = 0.3f;
        gridMoveTimer = gridMoveTimerMax;
        levelGrid = new LevelGrid(width,height);
        levelGrid.Setup(this);
        snakeBodySize = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
     HandleInput();   
     HandleGridMovement();
    }

    protected void HandleInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            gridMoveTimerMax = 0.1f;
        }
        else
        {
            gridMoveTimerMax = 0.3f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && gridMoveDir.y !=-1)
        {
            gridMoveDir.y = 1;
            gridMoveDir.x = 0;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gridMoveDir.y!= 1)
        {
            gridMoveDir.y = -1;
            gridMoveDir.x = 0;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && gridMoveDir.x != -1)
        {
            gridMoveDir.x = 1;
            gridMoveDir.y = 0;
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gridMoveDir.x != 1)
        {
            gridMoveDir.x = -1;
            gridMoveDir.y = 0;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        
    }

    public bool CollisionDetector()
    {
        foreach (GameObject o in snakeBodyParts)
        {
            if ((Vector2)o.transform.position == this.gridPos)
            {
                return true;
            }
        }
        
        return false;
    }

    protected void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            
            if (snakeBodySize > 0)
            {
                GameObject tempBody = GameObject.Instantiate(snakeBody, new Vector3(gridPos.x, gridPos.y, -0.3f),
                    quaternion.identity);
                snakeBodyParts.Insert(0, tempBody);
            }
            if (snakeBodyParts.Count >= snakeBodySize+1)
            {
                GameObject.Destroy(snakeBodyParts[snakeBodyParts.Count-1]);
                snakeBodyParts.RemoveAt(snakeBodyParts.Count-1);
            }
            

            gridPos += gridMoveDir;
            gridPos = ValidateGridPos(gridPos);
            gridMoveTimer -= gridMoveTimerMax;
            transform.position = new Vector3(gridPos.x, gridPos.y, -0.3f);
            levelGrid.SnakeMoved(gridPos);
            if (CollisionDetector())
            {
                Destroy(levelGrid.snake);
                foreach (GameObject o in snakeBodyParts)
                {
                    Destroy(o);
                }
                Destroy(gameObject);
                if (Highscore.SetNewHighscore(GameHandle.GetScore()))
                {
                    newHighScore.SetActive(true);
                    newHighScore.GetComponent<Text>().text = "You made a new highscore! " + GameHandle.GetScore();
                }
                Debug.Log("Game Over!");
                gameOver.SetActive(true);
                
            }
        }
        
    }

    public Vector2Int ValidateGridPos(Vector2Int currentPos)
    {
        if (currentPos.x < -width)
        {
            currentPos.x = width;
        }

        if (currentPos.y < -height)
        {
            currentPos.y = height;
        }

        if (currentPos.x > width)
        {
            currentPos.x = -width;
        }

        if (currentPos.y > height)
        {
            currentPos.y = -height;
        }

        return currentPos;
    }
}
