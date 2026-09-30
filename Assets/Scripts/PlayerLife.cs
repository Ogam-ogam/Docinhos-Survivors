using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    float damage;
    public float maxLife = 100f;
    public float currentLife;
    bool isDamaged;
    bool isDead;

    public Slider lifeBar;

    void Start()
    {
        currentLife = maxLife;
        lifeBar.maxValue = maxLife;
        lifeBar.value = currentLife;
    }

    public void OnDamage()
    {   
        if (isDamaged == true)
        {
            currentLife -= damage;
            lifeBar.value = currentLife;
            isDamaged = false;
        }

        if (currentLife <= 0 && !isDead)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        isDead = true;
        Debug.Log("Você morreu! Pressione Enter para reviver.");
    }

    void Reviver()
    {
        currentLife = maxLife;
        lifeBar.value = currentLife;
        isDead = false;
        Debug.Log("Revivido!");
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("levou dano");
            isDamaged = true;
        }
        else
        {
            isDamaged = false;
        }
    }

    void Update()
    {
        if (!isDead)
        {
            OnDamage();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Reviver();
        }
    }
}