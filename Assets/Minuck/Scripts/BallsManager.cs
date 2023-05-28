using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    #region Singleton

    private static BallsManager _instance;

    public static BallsManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);



        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    [SerializeField]
    private Ball ballPrefab;

    private Ball initialBall;

    private Rigidbody2D initialBallRb;

    public float initialBallSpeed = 110.0f;
    private int count = 2;

    public List<Ball> Balls {  get; set; }

    private void Start()
    {
        InitBall();
    }

    private void Update()
    {
        if(!GameManager.Instance.isGameStarted)
        {
            // Align ball position to the player position

            Vector3 playerPosition = Paddle.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(playerPosition.x, playerPosition.y + 10, playerPosition.z);

            initialBall.transform.position = ballPosition;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                initialBallRb.isKinematic = false;
                initialBallRb.velocity = new Vector3(0, initialBallSpeed, 0);
                GameManager.Instance.isGameStarted = true;
            }
        }
    }

    private void InitBall()
    {
        Vector3 playerPosition = Paddle.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(playerPosition.x, playerPosition.y + 10 , playerPosition.z); // Get it from the player

        initialBall = Instantiate(ballPrefab, startingPosition, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        this.Balls = new List<Ball>
        {
            initialBall
        };
    }

    public void ResetBalls()
    {
       foreach (var ball in this.Balls.ToList()) {
            Destroy(ball.gameObject);
        }

       InitBall();
    }

    public void SpawnBalls(Vector3 position, int count, bool isLightningBall)
    {   
        for (int i = 0; i < count; i++)
        {
            Ball spawnedBall = Instantiate(ballPrefab, position, Quaternion.identity) as Ball;

            if (isLightningBall)
            {
                spawnedBall.StartLightningBall();
            }

            Rigidbody2D spawnedBallRb = spawnedBall.GetComponent<Rigidbody2D>();
            spawnedBallRb.isKinematic = false;
            spawnedBallRb.velocity = new Vector3(0, initialBallSpeed, 0);
            this.Balls.Add(spawnedBall);
        }
    }
}
