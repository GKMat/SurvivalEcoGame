using UnityEngine;

public class MouvementPerso : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        // Clique souris
        if (Input.GetMouseButtonDown(0))
        {
            // Convertit la position souris en position monde
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            targetPosition = mouseWorldPos;
            isMoving = true;
        }

        // Déplacement
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );

            // Stop quand arrivé
            if (Vector2.Distance(transform.position, targetPosition) < 0.05f)
            {
                isMoving = false;
            }
        }
    }
}