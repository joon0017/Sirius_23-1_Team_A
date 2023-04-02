using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    Transform transfrom;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            Debug.Log("Left");
            Vector3 LeftPos = new Vector3(- speed * Time.deltaTime,0,0);
            obj.transform.position = obj.transform.position + LeftPos;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Debug.Log("Right");
            Vector3 RightPos = new Vector3(speed * Time.deltaTime,0,0);
            obj.transform.position = obj.transform.position + RightPos;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Debug.Log("Up");
            Vector3 RightPos = new Vector3(0,speed * Time.deltaTime,0);
            obj.transform.position = obj.transform.position + RightPos;
        }




    }
}
