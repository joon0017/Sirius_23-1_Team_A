using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chestNut;
    [SerializeField] private GameObject leftSpawn;
    [SerializeField] private GameObject rightSpawn;
    private Vector3 spawnpoint;

    private void Start() {
        InvokeRepeating("SummonRight", 0.0f, 1.5f);
        InvokeRepeating("SummonLeft", 1f, 1.5f);
    }

    private void SummonRight(){
        Vector3 spawnpoint = rightSpawn.transform.position + new Vector3(0, Random.Range(-10,10),0);
        GameObject n ;
        n = Instantiate(chestNut, spawnpoint, Quaternion.identity) as GameObject;
        Nut nut = n.GetComponent<Nut>();
        nut.setSpeed(Random.Range(5, 10));
        int nutsize = Random.Range(1, 100);
        nut.setNutScale(nutsize * 0.01f * nut.getNutSize());
        nut.setNutSize(nutsize/10);
    }

    private void SummonLeft(){
        Vector3 spawnpoint = leftSpawn.transform.position + new Vector3(0, Random.Range(-10,10),0);
        GameObject n ;
        n = Instantiate(chestNut, spawnpoint, Quaternion.identity) as GameObject;
        Nut nut = n.GetComponent<Nut>();
        nut.setMoveRight();
        nut.setSpeed(Random.Range(5, 15));
        int nutsize = Random.Range(1, 100);
        nut.setNutScale(nutsize * 0.01f * nut.getNutSize());
        nut.setNutSize(nutsize/10);
    }

    
}
