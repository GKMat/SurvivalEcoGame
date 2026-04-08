// Pickaxe.cs
using UnityEngine;

public class Pickaxe : Tool
{
    protected override void OnUse(Vector2 targetPos)
    {
        // Cible les blocs minables (pierre, minerai...)
        Collider2D hit = Physics2D.OverlapCircle(targetPos, data.range, data.targetLayer);
        if (hit != null)
        {
            Block block = hit.GetComponent<Block>();
            block?.TakeDamage(data.damage);
        }
    }
}