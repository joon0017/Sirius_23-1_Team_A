using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickButton : MonoBehaviour
{
    [SerializeField] string sceneName;
    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    
    void TaskOnClick(){
        LoadScene();
    }

    void LoadScene()
    {
        Application.LoadLevel(sceneName);
    }

}
