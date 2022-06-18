using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public BasicGameData basicGameData;

    public Player player;
    public PlayerMovement playerMovement;
    public MovePlayer movePlayer;
    public bool shield;
    public float shieldPower = 1f;
    public bool acceleration;
    public float accelerationSpeed = 1f;
    public bool damageModifier;
    public float damageIncreaseNumber = 10f;
    public bool deceleration;
    public float decelerationSpeed = 1f;
    public bool heal;
    public float healPower = 25f;
    public bool increaseAuraRadius;
    public float increaseAuraValue = .5f;
    public GameObject particlesAfterPickup;

    void Awake ()
    {
        //TODO implement better refererncing
        if (player == null)
        {
            player = FindObjectOfType<GameElements>().playerReference;
            playerMovement = player.gameObject.GetComponent<PlayerMovement>();
            movePlayer = player.gameObject.GetComponent<MovePlayer>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.PickUp();
            if (acceleration)
                Acceleration();
            if (shield)
                Shield();
            if (damageModifier)
                DamageModifier();
            if (deceleration)
                Deceleration();
            if (heal)
                Heal();
            if (increaseAuraRadius)
                IncreaseAuraRadius();

            StartCoroutine(WaitBeforeParticles());
        }
    }
    IEnumerator WaitBeforeParticles()
    {
        particlesAfterPickup.SetActive(true);
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
    }
    void Shield()
    {
        if((player.currentShield + shieldPower) > player.maxShield)
            player.currentShield = player.maxShield;
        else
        {
            player.currentShield += shieldPower;
        }
        player.shield.text =  "Shield: " + player.shieldPower;
    }
    void Acceleration()
    {
        movePlayer.playerSpeed += accelerationSpeed;
        playerMovement.speed = new Vector2(playerMovement.speed.x+accelerationSpeed, playerMovement.speed.y+ accelerationSpeed);
        movePlayer.speedText.text = "Speed: " + movePlayer.playerSpeed + "ms";
    }
    void Deceleration()
    {
        if (playerMovement.speed.x > 1.1f)
        {
            playerMovement.speed = new Vector2(playerMovement.speed.x - decelerationSpeed, playerMovement.speed.y - decelerationSpeed);
            movePlayer.playerSpeed -= decelerationSpeed;
            movePlayer.speedText.text = "Speed: " + movePlayer.playerSpeed + "ms";
        }
        
    }
    void DamageModifier()
    {
        player.passiveDamage += damageIncreaseNumber;
        player.damage.text = "Damage: " + player.passiveDamage;
    }
    void Heal()
    {
        if (player.health + healPower > player.maxHp)
            player.health = player.maxHp;
        else
            player.health += healPower;
    }
    void IncreaseAuraRadius()
    {
        player.aura.localScale = new Vector3(player.aura.localScale.x + increaseAuraValue, player.aura.localScale.y + increaseAuraValue, 0);
    }

    void FixedUpdate ()
    {
        GravityConstant();
    }

    void GravityConstant ()
    {
        transform.position += new Vector3 (basicGameData.constantGravityModifier.x * Time.deltaTime, basicGameData.constantGravityModifier.y * Time.deltaTime, 0);
    }
}
