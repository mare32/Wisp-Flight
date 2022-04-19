using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float damage = 30f;
    public float health;
    public float maxHp = 50f;
    public float _speed = 2f;
    public float xpWorth = 30;
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
    public GameObject deathParticles;
    public GameObject hpBar;
    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        MoveAround();
    }
    public void TakeDamage(float amountOfDamage)
    {
        health = health - amountOfDamage;
        if (health <= 0)
        {
            StartCoroutine(WaitBeforeParticles());
        }
           
    }
    IEnumerator WaitBeforeParticles()
    {
        deathParticles.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        hpBar.SetActive(false);
        yield return new WaitForSeconds(.2f);
        var tmpXp = player.experience + xpWorth;
        if (tmpXp > player.xpByLevel[player.level])
        {
            var spareXp = tmpXp - player.xpByLevel[player.level];
            player.LevelUp();
            player.experience += spareXp;
        }
        else if (tmpXp == player.xpByLevel[player.level])
        {
            player.LevelUp();
        }
        else
        {
            player.experience += xpWorth;
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }
    void MoveAround()
    {
        if (horizontal)
        {
            
            currentPosX = transform.position.x;
            if (reverse)
            {
                if ((currentPosX >= posX - moveAmount) && !arrived)
                {
                    transform.Translate(Vector3.left * _speed * Time.deltaTime);
                    arrived = false;
                }
                else if (currentPosX < posX)
                {
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
                if (reverse)
                    transform.Translate(Vector3.left * _speed * Time.deltaTime);
                else
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
                arrived = false;
            }
            else if(currentPosX >= posX)
            {
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
            if (reverse)
            {
                if ((currentPosY >= posY - moveAmount) && !arrived)
                {
                    transform.Translate(Vector3.down * _speed * Time.deltaTime);
                    arrived = false;
                }

                else if (currentPosY < posY)
                {
                    transform.Translate(Vector3.up * _speed * Time.deltaTime);
                    arrived = true;
                }
                else
                {
                    arrived = false;
                }
            }
            else
            {
                if ((currentPosY < posY + moveAmount) && !arrived)
                {
                    transform.Translate(Vector3.up * _speed * Time.deltaTime);
                    arrived = false;
                }

                else if (currentPosY >= posY)
                {
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
}
