using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Health playerHealth;
    public Sprite fullHealthImage;
    public Sprite emptyHeartImage;
    public Image[] hearts;

    private void Update()
    {
        if(playerHealth.curHealth > playerHealth.health)
        {
            playerHealth.curHealth = playerHealth.health;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth.curHealth)
            {
                hearts[i].sprite = fullHealthImage;
            }
            else
            {
                hearts[i].sprite = emptyHeartImage;
            }
            if(i < playerHealth.health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void DisplayHearts()
    {
        
    }
}
