using Unity.VisualScripting;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public Transform target;
    public float Speed, Power;
    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if (distance > 0.1f)
        {
            Go();
        }
    }
    private void Go()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Vector3 direction = collision.transform.position - transform.position;
            collision.rigidbody.AddForce(direction.normalized * Power);
            Debug.Log(1);
        }
    }
}
