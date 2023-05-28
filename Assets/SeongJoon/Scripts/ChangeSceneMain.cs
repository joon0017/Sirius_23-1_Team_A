using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneMain : MonoBehaviour
{
    [SerializeField] string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel(sceneName);
    }
}
