using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private int cnt;

    // Start is called before the first frame update
    void Start()
    {
        cnt = PlayerPrefs.GetInt("cnt");

        if (cnt == 2)
        {
            PlayerPrefs.SetInt("cnt", 0);
            SceneManager.LoadScene(7);
        }

        if (PlayerPrefs.GetInt("health", currentHealth) > 0 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            currentHealth = PlayerPrefs.GetInt("health");
        }
        else
        {
            currentHealth = maxHealth;
            PlayerPrefs.SetInt("health", 100);
        }

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        Debug.Log(currentHealth);
        Debug.Log(cnt);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            PlayerMovement.Reset();
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        Debug.Log(healthBar);
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("axe"))
        {
            TakeDamage(5);
        }

        if (other.gameObject.CompareTag("obstacles"))
        {
            cnt += 1;
            TakeDamage(50);
            PlayerPrefs.SetInt("health", currentHealth);
            PlayerPrefs.SetInt("cnt", cnt);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}
