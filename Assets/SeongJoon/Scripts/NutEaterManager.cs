using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutEaterManager : MonoBehaviour
{
    private static NutEaterManager _instance;
    public static NutEaterManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    /*--------------------------------------*/

    [SerializeField] private GameObject displayCounter;
    [SerializeField] private int eaten = 3;

    public void IncreaseEaten(){
        eaten++;
        updateCanvas();
    }

    public int GetEaten(){
        return eaten;
    }

    public void Reset(){
        eaten = 0;
    }

    private void updateCanvas(){
        displayCounter.GetComponent<TMPro.TextMeshProUGUI>().text = eaten.ToString();
    }


}
