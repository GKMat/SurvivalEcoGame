using UnityEngine;

public class Persomouvement
{
    Vector3 newPosition = Vector3.zero;
    public int speed = 5;
    public GameObject Point;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                //transfrom.position = newPosition;
                transform.LookAt(hit.point);
                Point.position = new Vector3(newPosition.x, Point.transform.position.y,newPosition.z);
            }
        }
        if (newPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition * Time.deltaTime)
    
        }

        if (transform.position == newPosition || newPosition==Vector3.zero)
        {
            Point.GetComponent<MeshRenderer> () .enabled = false;
        }
        else
        {
            Point.GetComponent<MeshRenderer>().enabled = true;
        }

    }
}
