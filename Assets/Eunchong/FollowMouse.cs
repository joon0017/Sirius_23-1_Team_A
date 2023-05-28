using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    Camera screenCamera;
    float zDistance = 30.0f;

    private void Update() {
        Vector3 mousePos = Input.mousePosition;
        this.transform.position = screenCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));
    }
}
