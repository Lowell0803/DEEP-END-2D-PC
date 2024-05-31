using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue = 1f;
    [SerializeField] private AudioClip gainHealthSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Health>().currentHealth < collision.GetComponent<Health>().startingHealth)
            {
                collision.GetComponent<Health>().AddHealth(healthValue);
                gameObject.SetActive(false);
            }
            else
            {
                print("hp full!");
            }
        }

        
    }
}
