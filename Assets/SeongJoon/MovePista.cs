using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePista : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 scale;
    private int eaten = 0;
    // Start is called before the first frame update
    void Start()
    {  
        scale = transform.localScale;
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
        
        //reset velocity
        this.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void Eat(GameObject target){
        // eat method
        scale += new Vector3(0.03f, 0.03f, 0.03f);
        Destroy(target);
        eaten++;
        
    }

    private void OnCollisionEnter(Collision other) {
        // collision method
        if(other.gameObject.tag == "Food"){
            Eat(other.gameObject);
            Debug.Log("Eaten: " + eaten);
        }
    }
}
