using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    private Image HealthBarImg;
    public float currentHp;
    private float maxHp = 100f;
    public Player player;
    public TextMeshProUGUI health;

    void Awake()
    {
        //TODO implement better refererncing
        if (player == null)
            player = FindObjectOfType<GameElements>().playerReference;
    }

    void Start()
    {
        currentHp = player.health;
        HealthBarImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentHp = player.health;
        HealthBarImg.fillAmount = currentHp / maxHp;
        health.text = currentHp + "/" + maxHp;
    }
}
