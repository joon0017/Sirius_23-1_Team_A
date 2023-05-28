using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float delay = 7f;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("decreaseScore", delay);
        Destroy(gameObject, delay);
        Invoke("changeSprite", 5.5f);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("arrow"))
        {
            Destroy(gameObject);
        }
    }

    private void changeSprite() {
        Color newColor = new Color(1f, 0.5f, 0f, 1f); // RGB(1, 0.5, 0)의 노란색
        spriteRenderer.color = newColor;
    }
    private void decreaseScore() {
        GameObject obj = GameObject.Find("Cube");
        Stats stat = obj.GetComponent<Stats>();
        stat.setScore(stat.getScore()-1);
    }
}
