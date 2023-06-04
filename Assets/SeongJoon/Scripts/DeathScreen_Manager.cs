using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathScreen_Manager : MonoBehaviour
{
    public void LoadCurrent(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void returnToMenu(){
        SceneManager.LoadScene("ChooseScene");
    }
}
