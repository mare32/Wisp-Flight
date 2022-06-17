using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class XpBar : MonoBehaviour
{
    private Image XpBarImage;
    public float currentXp;
    private float maxXp;
    public Player player;
    public TextMeshProUGUI playerLevel;
    public TextMeshProUGUI experienceNumbers;

    void Awake()
    {
        //TODO implement better refererncing
        if (player == null)
            player = FindObjectOfType<GameElements>().playerReference;
    }

    void Start()
    {
        currentXp = player.experience;
        XpBarImage = GetComponent<Image>();
        maxXp = player.xpByLevel[player.level];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        maxXp = player.xpByLevel[player.level];
        currentXp = player.experience;
        XpBarImage.fillAmount = currentXp / maxXp;
        experienceNumbers.text = currentXp.ToString() + "/" + maxXp.ToString();
        playerLevel.text = player.level.ToString();
    }
}
