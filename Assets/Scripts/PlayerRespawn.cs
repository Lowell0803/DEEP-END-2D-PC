using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] public int numOfDeaths = 9;

    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;


    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        if (numOfDeaths > 10)
        {
            uiManager.GameOver();
            return;
        }

        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            print("Checkpoint");
        }
    }

    public void AddDeathCounter()
    {
        numOfDeaths++;
        print(numOfDeaths);
    }
}
