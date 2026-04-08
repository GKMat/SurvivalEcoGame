// Block.cs
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 3;
    public GameObject dropPrefab;       // item lâché à la destruction

    [Header("Feedback visuel")]
    public SpriteRenderer sr;
    private Color baseColor;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        baseColor = sr.color;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Teinte rouge au fur et à mesure des dégâts
        float ratio = (float)currentHealth / maxHealth;
        sr.color = Color.Lerp(Color.red, baseColor, ratio);

        if (currentHealth <= 0) Break();
    }

    void Break()
    {
        if (dropPrefab)
            Instantiate(dropPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}