using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    //public Rigidbody2D rb = new Rigidbody2D();
    public Vector2 speed = new Vector2(10,10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {

    }
    private void FixedUpdate()
    {
        //rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        //rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
