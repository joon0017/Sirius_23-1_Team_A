using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    private float arrowSpeed;

    void Start()
    {
        GameObject bowObject = GameObject.Find("Cube/Bow");
        BowControl bowControl = bowObject.GetComponent<BowControl>();
        Quaternion rot = bowControl.transform.rotation;
        Vector3 p = rot.eulerAngles;
        Debug.Log("bowControl: " + p);
        float angleRad = p.z * Mathf.Deg2Rad;
        Vector3 norVec = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0);

        arrowSpeed = 100 + bowControl.charging;
        Debug.Log("bow.charge: " + bowControl.charging);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(norVec * arrowSpeed);

        Debug.Log("arrowSpeed: " + arrowSpeed);

        bowControl.charging = 0;
    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0,0,angle);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            GameObject obj = GameObject.Find("Cube");
            Stats stat = obj.GetComponent<Stats>();
            stat.setScore(stat.getScore()+1);
            Destroy(gameObject);
        }
    }
}
