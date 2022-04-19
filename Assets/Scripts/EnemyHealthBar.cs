using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Image HealthBarImg;
    public float currentHp;
    private float maxHp;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarImg = GetComponent<Image>();
        maxHp = enemy.maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        currentHp = enemy.health;
        HealthBarImg.fillAmount = currentHp / maxHp;
    }
}
