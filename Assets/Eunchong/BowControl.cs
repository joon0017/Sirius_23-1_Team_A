using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowControl : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject mpos;
    [SerializeField]
    private GameObject Arrow;
    private Stats stat;

    bool isMouseDown = false;
    public float charging = 0;

    void Start()
    {
        GameObject obj = GameObject.Find("Cube");
        stat = obj.GetComponent<Stats>();
        mpos.SetActive(true);
    }

    void Update()
    {
        Vector3 len = mpos.transform.position - Player.transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,z);
        Quaternion q = Quaternion.Euler(len.normalized);
        Vector3 v = q.ToEulerAngles();
        transform.position = Player.transform.position + v.normalized*2;

        if(!stat.getStop())
        {
            if (Input.GetMouseButton(0)) {
                isMouseDown = true;
                if (charging < 1000) {
                    charging += 7.5f;
                    Vector3 currScale = transform.localScale;
                    currScale.x *= 1.1f;
                }
                Debug.Log("charging: " + charging);
            }
            if (Input.GetMouseButtonUp(0) && isMouseDown) {
                isMouseDown = false;
                GameObject go = Instantiate(Arrow);
                go.transform.position = transform.position;
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        

        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("mouse");
            
        //     Vector3 mouseViewportPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //     Vector3 mouseWorldPos = Camera.main.ViewportToWorldPoint(new Vector3(mouseViewportPos.x, mouseViewportPos.y, 0));
        // }
    }
}
