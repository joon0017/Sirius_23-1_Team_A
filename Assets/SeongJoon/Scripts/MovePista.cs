using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePista : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody rb;
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {  
        scale = transform.localScale;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        // move method

        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");

        Vector2 currentPosition = transform.position;
        Vector2 newPosition = new Vector2(X, Z) * speed * Time.deltaTime;
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
    private void Eat(GameObject target){
        // eat method
        scale += new Vector3(0.03f, 0.03f, 0.03f);
        NutEaterManager.Instance.IncreaseEaten();
        Destroy(target);
        
    }

    private void Death(){
        //display death screen
    }
    private void OnTriggerEnter(Collider other) {
        // collision method
        Debug.Log(other.gameObject);
        if(other.gameObject.tag == "Food"){

            //first check if eatable
            if (NutEaterManager.Instance.GetEaten() > other.gameObject.GetComponent<Nut>().getNutSize()) Eat(other.gameObject);
            else Death();
        }
    }
}
