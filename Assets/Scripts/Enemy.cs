using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public BasicGameData basicGameData;

    public Animator animator;
    public Player player;
    public SpriteRenderer spriteRenderer;
    public float damage = 30f;
    public float health;
    public float maxHp = 50f;
    public Vector2 _speed = new Vector2(2f, 3f);
    public float xpWorth = 30;

    public AnimationCurve horizontalCurve;
    public float horizontalMovement = 0.0f;
    public AnimationCurve verticalCurve;
    public float verticalMovement = 0.0f;

    private Vector2 birthPos;
    //[HideInInspector]
    public float randomOffset = 0f;

    public float moveAmount = 5;
    public bool reverse;
    private bool arrived = false;
    public GameObject deathParticles;
    public GameObject hpBar;

    void Awake ()
    {
        //TODO implement better refererncing
        if (player == null)
            player = FindObjectOfType<GameElements>().playerReference;


        birthPos = new Vector2(transform.position.x, transform.position.y + (verticalMovement * randomOffset));
        randomOffset = Random.Range(-1, 1);
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
            animator.SetTrigger("Die");
            StartCoroutine(WaitBeforeParticles());
        }
           
    }
    IEnumerator WaitBeforeParticles()
    {
        deathParticles.SetActive(true);
        //spriteRenderer.color = Color.clear;
        hpBar.SetActive(false);
        yield return new WaitForSeconds(1.5f);
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
        if (other.tag == "LowerEdge")
        {
            BackToQueue();
        }
    }
    void MoveAround()
    {

        birthPos += basicGameData.constantGravityModifier * Time.deltaTime;

        transform.position = new Vector3
            (
            horizontalMovement != 0 ? birthPos.x + CalculateOffset(true) : birthPos.x,
            verticalMovement != 0 ? birthPos.y + CalculateOffset(false) : birthPos.y,
            0
            );
    }

    float CalculateOffset(bool dir)
    {
        float tempTime;
        if (dir)
        {
            tempTime = ((Time.time / _speed.x) + randomOffset) % 1;
            tempTime = horizontalCurve.Evaluate(tempTime) * horizontalMovement;
        }
        else
        {
            tempTime = ((Time.time / _speed.y) + randomOffset) % 1;
            tempTime = verticalCurve.Evaluate(tempTime) * verticalMovement;
        }

        return tempTime;
    }

    void BackToQueue()
    {

    }
}
