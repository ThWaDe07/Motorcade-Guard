using UnityEngine;

public class RoadSpawnTrigger : MonoBehaviour
{
    public SpawnManager spawnManager;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Limo"))
        {
            spawnManager.SpawnTriggerEntered();
            Destroy(gameObject);
        }
    }
}
