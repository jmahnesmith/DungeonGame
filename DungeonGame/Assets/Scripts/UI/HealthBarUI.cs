using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Health playerHealth;
    private Image healthBar;
    
    private void Start()
    {
        healthBar = GetComponent<Image>();
    }


    void Update()
    {
        HealthChanging();
    }

    private void HealthChanging()
    {
        healthBar.fillAmount = playerHealth.curHealth / playerHealth.health;
    }
}
