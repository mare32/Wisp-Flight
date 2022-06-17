using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShieldBar : MonoBehaviour
{
    private Image ShieldBarImg;
    public float currentShield =35f;
    private float maxShield = 35f;
    public Player player;
    public TextMeshProUGUI shield;

    void Awake()
    {
        //TODO implement better refererncing
        if (player == null)
            player = FindObjectOfType<GameElements>().playerReference;
    }

    void Start()
    {
        currentShield = player.currentShield;
        ShieldBarImg = GetComponent<Image>();
        //player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentShield = player.currentShield;
        ShieldBarImg.fillAmount = currentShield / maxShield;
        shield.text = currentShield + "/" + maxShield;
    }
}
