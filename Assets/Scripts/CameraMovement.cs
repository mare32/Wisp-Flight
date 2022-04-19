using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;
        transform.Translate(Vector3.up * camSpeed * Time.deltaTime);
    }
}
