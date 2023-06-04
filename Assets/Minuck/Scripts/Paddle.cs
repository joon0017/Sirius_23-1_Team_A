using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    #region Singleton

    private static Paddle _instance;

    public static Paddle Instance => _instance;

    public bool PaddleIsTransforming { get; set; }

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

    public float horizontalInput;
    public float verticalInput;
    private float speed = 120.0f;

    public float extendShrinkDuration = 10;
    public float paddleWidth = 20.0f;
    public float paddleHeight = 2.8f;

    private Camera mainCamera;
    private float paddleInitialY;
    private SpriteRenderer sr;
    private BoxCollider2D boxCol;

    public List<int> paddleSkill = new List<int>();

    public bool PaddleIsShooting { get; set; }
    public GameObject leftMuzzle;
    public GameObject rightMuzzle;
    public Projectile bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        paddleInitialY = this.transform.position.y;
        sr = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(-Vector3.down * verticalInput * Time.deltaTime * speed);
    }

    public void StartWidthAnimation(float newWidth)
    {
        StartCoroutine(AnimatePaddleWidth(newWidth));
    }

    public IEnumerator AnimatePaddleWidth(float width)
    {
        this.PaddleIsTransforming = true;
        this.StartCoroutine(ResetPaddleWidthAfterTime(this.extendShrinkDuration));

        if (width > this.sr.size.x)
        {
            float currentWidth = this.sr.size.x;
            while (currentWidth < width)
            {
                currentWidth += Time.deltaTime * 2;
                this.sr.size = new Vector2(currentWidth, paddleHeight);
                boxCol.size = new Vector2(currentWidth, paddleHeight);
                yield return null;
            }
        }
        else
        {
            float currentWidth = this.sr.size.x;
            while (currentWidth > width)
            {
                currentWidth -= Time.deltaTime * 2;
                this.sr.size = new Vector2(currentWidth, paddleHeight);
                boxCol.size = new Vector2(currentWidth, paddleHeight);
                yield return null;
            }
        }

        this.PaddleIsTransforming = false;
    }

    private IEnumerator ResetPaddleWidthAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.StartWidthAnimation(this.paddleWidth);
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

            ballRb.velocity = Vector3.zero;

            float difference = paddleCenter.x - hitPoint.x;

            if (hitPoint.x < paddleCenter.x)
            {
                ballRb.velocity = new Vector3(-(Mathf.Abs(difference * 10)), BallsManager.Instance.initialBallSpeed, 0);
            }
            else
            {
                ballRb.velocity = new Vector3((Mathf.Abs(difference * 10)), BallsManager.Instance.initialBallSpeed, 0);
            }
        }
    }

    public void StartShooting()
    {
        if (this.PaddleIsShooting)
        {
            this.PaddleIsShooting = true;
            StartCoroutine(StartShootingRoutine());

        }
    
    }

    public IEnumerator StartShootingRoutine()
    {
        float fireCooldown = 0.5f; // TODO: extract this into Unity variable
        float fireCooldownLeft = 0;

        float shootingDuration = 10;
        float shootingDurationLeft = shootingDuration;

        Debug.Log("START SHOOTING");

        while (shootingDurationLeft >= 0)
        {
            fireCooldownLeft = fireCooldownLeft - Time.deltaTime;
            shootingDurationLeft = shootingDurationLeft - Time.deltaTime;

            if (fireCooldownLeft <= 0)
            {
                this.Shoot();

                Debug.Log($"Shoot at {Time.time}");
            }

            yield return null;
        }

        Debug.Log("STOP SHOOTING!");
        this.PaddleIsShooting = false;
        leftMuzzle.SetActive(false);
        rightMuzzle.SetActive(false );
    
    }

    private void Shoot()
    {
        leftMuzzle.SetActive(false);
        rightMuzzle.SetActive(false );

        leftMuzzle.SetActive(true);
        rightMuzzle.SetActive(true);

        this.SpawnBullet(leftMuzzle);
        this.SpawnBullet(rightMuzzle);

    }

    private void SpawnBullet(GameObject muzzle)
    {
        Vector3 spawnPosition = new Vector3(muzzle.transform.position.x, muzzle.transform.position.y + 2f, muzzle.transform.position.z);
        Projectile bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(new Vector3(0, 450f, 0));

    }
}
