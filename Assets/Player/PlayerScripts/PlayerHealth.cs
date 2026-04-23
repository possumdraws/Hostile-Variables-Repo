using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool invincible; //for testing lol

    public TextMeshProUGUI displayHealth;

    public PlayerHealthbar healthbar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set health to full when loaded
        currentHealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && currentHealth > 0)
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }

    /*public int GetCurrentHealth()
    {
        return currentHealth;
    }*/
}

