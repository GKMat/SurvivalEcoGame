// Axe.cs
using UnityEngine;

public class Axe : Tool
{
    protected override void OnUse(Vector2 targetPos)
    {
        // Cible les arbres/bois
        Collider2D hit = Physics2D.OverlapCircle(targetPos, data.range, data.targetLayer);
        if (hit != null)
        {
            Tree tree = hit.GetComponent<Tree>();
            tree?.Chop(data.damage);
        }
    }
}