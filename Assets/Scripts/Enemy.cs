using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float _speed = 2f;
    public bool horizontal;
    public bool vertical;
    private float posX;
    private float posY;
    private float posZ;
    private float currentPosX;
    private float currentPosY;
    private float currentPosZ;
    public bool reverse;
    public float moveAmount = 5;
    private bool arrived = false;
    // Start is called before the first frame update
    void Start()
    {
        //if (reverse)
        //    moveAmount = -moveAmount;
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //MoveAround();
    }
    void FixedUpdate()
    {
        MoveAround();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("has collided");
            //other.transform.position = new Vector2(0, 0);
            SceneManager.LoadScene("SampleScene");
            //Destroy(this.gameObject);
        }
    }
    void MoveAround()
    {
        //Debug.Log("PosX:"+currentPosX+"\r\nPosY:"+currentPosY);
        if (horizontal)
        {
            currentPosX = transform.position.x;
            if (reverse)
            {
                if ((currentPosX >= posX - moveAmount) && !arrived)
                {
                    Debug.Log("LEVO123");
                    transform.Translate(Vector3.left * _speed * Time.deltaTime);
                    arrived = false;
                }
                else if (currentPosX < posX)
                {
                    Debug.Log("DESNO123");
                    transform.Translate(Vector3.right * _speed * Time.deltaTime);
                    arrived = true;
                }
                else
                {
                    arrived = false;
                }
            }
            else if ((currentPosX < posX + moveAmount) && !arrived)
            {
                //Debug.Log("DESNO");
                if (reverse)
                    transform.Translate(Vector3.left * _speed * Time.deltaTime);
                else
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
                arrived = false;
            }
            else if(currentPosX >= posX)
            {
                //Debug.Log("LEVO");
                if(reverse)
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
                else
                    transform.Translate(Vector3.left * _speed * Time.deltaTime);
                arrived = true;
            }
            else
            {
                arrived = false;
            }
               
        }
        if (vertical)
        {
            currentPosY = transform.position.y;
            if ((currentPosY < posY + moveAmount) && !arrived)
            {
                //Debug.Log("GORE");
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
                arrived = false;
            }
                
            else if(currentPosY >= posY)
            {
                //Debug.Log("DOLE");
                transform.Translate(Vector3.down * _speed * Time.deltaTime);
                arrived = true;
            }
            else
            {
                arrived = false;
            }
               
        }
    }
}
