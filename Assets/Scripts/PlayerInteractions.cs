using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Зіткнення з коробкою");
        }

        else if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Зіткнення зі стіною");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zone"))
        {
            Debug.Log("Вхід в робочу зону");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Zone"))
        {
            Debug.Log("Вихід з робочої зони");
        }
    }
}
