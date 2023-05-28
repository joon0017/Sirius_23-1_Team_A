using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    Transform transfrom;
    [SerializeField] float speed;
    private Stats stat;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Cube");
        stat = obj.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stat.getStop())
        {
            if (Input.GetKey(KeyCode.A)){
                Debug.Log("Left");
                Vector3 LeftPos = new Vector3(- speed * Time.deltaTime,0,0);
                obj.transform.position = obj.transform.position + LeftPos;
            }
            if (Input.GetKey(KeyCode.D)) {
                Debug.Log("Right");
                Vector3 RightPos = new Vector3(speed * Time.deltaTime,0,0);
                obj.transform.position = obj.transform.position + RightPos;
            }
            if (Input.GetKey(KeyCode.W)) {
                Debug.Log("Up");
                Vector3 RightPos = new Vector3(0,speed * Time.deltaTime,0);
                obj.transform.position = obj.transform.position + RightPos;
            }
        }
    }
}
