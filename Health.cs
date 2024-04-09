using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public TextMeshProUGUI playerHPText;

    public void TakeHit(int damage)
    {
        health -= damage;

        playerHPText.text = "" + health;

        if (health < 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void SetHealth(int BonusHealth)
    {
        health += BonusHealth;

        playerHPText.text = "" + health;
    }
}
