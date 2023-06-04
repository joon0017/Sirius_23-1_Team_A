using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    [SerializeField]
    private int nutSize;
    [SerializeField]
    private bool moveRight = false;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody rb;
    
    public Nut (int nutSize)
    {
        this.nutSize = nutSize;
    }

    public void setSpeed(float speed){
        this.speed = speed;
    }

    public void setMoveRight()
    {
        this.moveRight = true;
    }

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        Move();
    }

    private void Move() {
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = new Vector2(moveRight? 1 : -1, 0) * speed * Time.deltaTime;
        transform.position = currentPosition + newPosition;
        
        ResetVelocity();
    }

    private void ResetVelocity(){
        // Reset the velocity
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // "Pause" the physics
        rb.isKinematic = true;
        // Re-enable the physics
        rb.isKinematic = false;
    }



    public int getNutSize()
    {
        return nutSize;
    }
    public void setNutSize(int nutSize){
        this.nutSize = nutSize;
    }

    public void setNutScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
