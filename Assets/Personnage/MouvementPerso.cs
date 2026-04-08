using UnityEngine;

public class MouvementPerso : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            Debug.Log(target);
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

}
    