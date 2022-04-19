using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float experience = 0;
    public float[] xpByLevel = {0, 100,150,200,250,300,450,600,750,900,1100,1300,1600,1900,2200,2500,2800,3200,3600,4000,4500,5000 };
    public int level = 1;
    public float passiveDamage = 1f ;
    public float shieldPower  = 0f;
    public float currentShield = 35;
    public float maxShield = 35;
    public float health = 100f;
    public float maxHp = 100f;
    public int pickups = 0;
    public Image HealthBarImg;
    public Image shieldBarImg;
    public TextMeshProUGUI pickupTextMesh;
    public TextMeshProUGUI shield;
    public TextMeshProUGUI damage;
    public Transform aura;
    public GameObject auraObject;
    public GameObject deathParticles;
    void Start()
    {
        //shieldBarImg = shieldBarImg.GetComponent<Image>();
    }
    public void TakeDamage(float amountOfDamage)
    {
        if(currentShield <= 0)
        {
            this.health = this.health - amountOfDamage;
            this.HealthBarImg.fillAmount = this.health / this.maxHp;
            if (this.health <= 0)
            {
                health = 0;
                StartCoroutine(WaitBeforeParticles());
            }
        }
        else if(currentShield - amountOfDamage < 0f)
        {
            float spareDmg = amountOfDamage - currentShield;
            currentShield = 0f;
            shieldBarImg.fillAmount = 0f;
            TakeDamage(spareDmg);
        }
        else
        {
            currentShield -= amountOfDamage;
            float v = currentShield / maxShield;
            shieldBarImg.fillAmount = v;
        }
    }
    IEnumerator WaitBeforeParticles()
    {
        deathParticles.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        gameObject.GetComponent<MovePlayer>().playerSpeed = 0;
        gameObject.GetComponent<PlayerMovement>().speed = new Vector2(0,0);
        auraObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");
    }
    public void PickUp()
    {
        pickups++;
        pickupTextMesh.text = "PowerUps: " + pickups;
        shield.text = "Shield: " + shieldPower;
        damage.text = "Damage: " + passiveDamage;

    }
    public void LevelUp()
    {
            level++;
            experience = 0;
    }
    // Update is called once per frame
    void Update()
    {
     
    }
    
}
