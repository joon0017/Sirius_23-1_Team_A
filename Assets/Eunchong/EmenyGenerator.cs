using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyGenerator : MonoBehaviour
{
    private float interval = 1.5f;
    [SerializeField]
    private GameObject Enemy;
    private Stats stat;
    private float time;

    void Start()
    {
        GameObject obj = GameObject.Find("Cube");
        stat = obj.GetComponent<Stats>();
    }

    void Update()
    {
        if(!stat.getStop())
        {
            time += Time.deltaTime;
            if(time >= interval)
            {
                GameObject obj = GameObject.Find("Cube");
                PlayerMove pm = obj.GetComponent<PlayerMove>();
                Debug.Log(pm.transform.position);
                GameObject enemy = Instantiate(Enemy);
                float x = Random.Range(-35.0f, 35.0f);
                float y = Random.Range(0.0f, 20.0f);
                enemy.transform.position = new Vector3(x, y, 0);
                enemy.transform.localScale *= 5.0f;
                interval += 1.5f;
            }
        }
    }
}
