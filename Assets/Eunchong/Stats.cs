using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private float time;
    private int score;
    private bool stop;
    private bool start;

    private int bestScore;

    private TextMesh text_time;
    private TextMesh text_score;
    private TextMesh text_start;
    private TextMesh text_restart;

    void Start()
    {
        time = 0f;
        score = 0;
        stop = true;
        start = true;
        bestScore = -1000000;

        GameObject obj1 = GameObject.Find("Time");
        text_time = obj1.GetComponent<TextMesh>();
        GameObject obj2 = GameObject.Find("Score");
        text_score = obj2.GetComponent<TextMesh>();
        GameObject obj3 = GameObject.Find("Start");
        text_start = obj3.GetComponent<TextMesh>();
        GameObject obj4 = GameObject.Find("Restart");
        text_restart = obj4.GetComponent<TextMesh>();
    }

    void Update()
    {
        if(!stop)
        {
            time += Time.deltaTime;
            text_time.text = "Time : " + time.ToString("F2");
            text_score.text = "Score : " + score.ToString();
        }
        if(time >= 10)
        {
            stop = true;
        }
        if(stop){
            if(start) {
                if(Input.GetKey(KeyCode.S)){
                    start = false;
                    stop = false;
                    text_start.text = "";
                } else {
                    text_start.text = "Press S to Start";
                }
            } else {
                if(Input.GetKey(KeyCode.R)){
                    stop = false;
                    time = 0.0f;
                    score = 0;
                    text_restart.text = "";
                } else {
                    int currentScore = score;
                    if(bestScore < currentScore) {
                        text_restart.text = "Best Score! : " + currentScore + "\nPress R to Start";
                        bestScore = currentScore;
                    } else {
                        text_restart.text = "Final Score : " + currentScore + "\nPress R to Start";
                    }
                    text_time.text = "";
                    text_score.text = "";
                    score = 0;
                }
            }
        }
    }

    public float getTime() {
        return time;
    }
    public void setTime(float num) {
        time = num;
    }
    public int getScore(){
        return score;
    }
    public void setScore(int num) {
        score = num;
    }
    public bool getStop() {
        return stop;
    }
    public void setStop(bool tf) {
        stop = tf;
    }
}
