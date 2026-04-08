// Tool.cs
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public ToolData data;
    protected int currentDurability;

    protected virtual void Start()
    {
        currentDurability = data.maxDurability;
    }

    // Appelée par le joueur au clic
    public void Use(Vector2 targetPos)
    {
        if (currentDurability <= 0)
        {
            Debug.Log($"{data.toolName} est cassé !");
            return;
        }

        OnUse(targetPos);
        currentDurability--;
    }

    protected abstract void OnUse(Vector2 targetPos);

    // Durabilité en % pour la UI
    public float GetDurabilityPercent() => (float)currentDurability / data.maxDurability;
}