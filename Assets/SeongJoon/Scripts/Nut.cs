using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    [SerializeField]
    private int nutSize;
    [SerializeField]
    private bool moveRight;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody rb;
    
    public Nut (int nutSize)
    {
        this.nutSize = nutSize;
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

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
