using UnityEngine;

public class MouvementPerso : MonoBehaviour
{
    Vector3 newPosition = Vector3.zero;
    public int speed = 5;
    public GameObject Point;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                transform.LookAt(hit.point);
                Point.transform.position = new Vector3(
                    newPosition.x,
                    Point.transform.position.y,
                    newPosition.z
                );
                isMoving = true;
            }
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                newPosition,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, newPosition) < 0.01f)
            {
                isMoving = false;
            }
        }

        Point.GetComponent<MeshRenderer>().enabled = isMoving;
    }
}