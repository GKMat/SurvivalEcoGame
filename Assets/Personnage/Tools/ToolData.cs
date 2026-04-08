// ToolData.cs
using UnityEngine;

public enum ToolType { Pickaxe, Axe, Shovel, Sword }

[CreateAssetMenu(fileName = "NewTool", menuName = "Survival/Tool")]
public class ToolData : ScriptableObject
{
    [Header("Infos")]
    public string toolName;
    public Sprite icon;
    public ToolType toolType;

    [Header("Stats")]
    public int damage = 1;
    public float useSpeed = 1.5f;   // coups/seconde
    public float range = 1.5f;
    public int maxDurability = 100;

    [Header("Layer ciblé")]
    public LayerMask targetLayer;   // ex: "Blocks" pour pioche, "Trees" pour hache
}