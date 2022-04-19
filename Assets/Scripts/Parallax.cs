using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    private float height, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public bool infinite = true;
    void Start()
    {
        startpos = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float dist = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);
        if (infinite)
        {
            if (temp > startpos + height) startpos += height * 2;
            else if (temp < startpos - height) startpos -= height;
        }
       
    }
}
