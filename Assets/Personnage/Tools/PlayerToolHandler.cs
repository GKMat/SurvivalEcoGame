// PlayerToolHandler.cs
using UnityEngine;

public class PlayerToolHandler : MonoBehaviour
{
    [Header("Outils disponibles")]
    public Tool[] tools;            // Pioche [0], Hache [1], Pelle [2]...

    private Tool equippedTool;
    private int equippedIndex = -1;
    private float nextUseTime;

    void Start()
    {
        // Désactive tous les outils au départ
        foreach (Tool t in tools)
            t.gameObject.SetActive(false);

        EquipTool(0);               // équipe la pioche par défaut
    }

    void Update()
    {
        HandleSwitch();
        HandleUse();
        FlipTool();
    }

    // --- Changement d'outil via touches 1/2/3... ---
    void HandleSwitch()
    {
        for (int i = 0; i < tools.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                EquipTool(i);
        }
    }

    void EquipTool(int index)
    {
        if (index == equippedIndex || index >= tools.Length) return;

        if (equippedTool != null)
            equippedTool.gameObject.SetActive(false);

        equippedIndex = index;
        equippedTool = tools[index];
        equippedTool.gameObject.SetActive(true);
    }

    // --- Utilisation au clic gauche ---
    void HandleUse()
    {
        if (!Input.GetMouseButton(0)) return;
        if (equippedTool == null) return;
        if (Time.time < nextUseTime) return;

        // Vérifie que le curseur est dans la portée du joueur
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dist = Vector2.Distance(transform.position, mouseWorld);

        if (dist <= equippedTool.data.range * 3f)   // portée de sélection
        {
            equippedTool.Use(mouseWorld);
            nextUseTime = Time.time + (1f / equippedTool.data.useSpeed);
        }
    }

    // --- L'outil se retourne selon la direction du curseur ---
    void FlipTool()
    {
        if (equippedTool == null) return;

        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool mouseOnRight = mouseWorld.x >= transform.position.x;

        equippedTool.GetComponent<SpriteRenderer>().flipX = !mouseOnRight;
    }
}
