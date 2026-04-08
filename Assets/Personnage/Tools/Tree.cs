using UnityEngine;

public class Tree : MonoBehaviour
{
    public int health = 3;
    public GameObject dropPrefab;

    public void Chop(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Break();
        }
    }

    void Break()
    {
        if (dropPrefab)
            Instantiate(dropPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}