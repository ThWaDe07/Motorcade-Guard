using System.Collections.Generic;
using UnityEngine;
public class CarSpawn : MonoBehaviour
{
    public List<GameObject> spawners;
    public List<GameObject> cars;

    public float otherCarSpeed = 5f;

    GameObject spawnedCar;
    int spawnPoint;

    UIScript uiScript;
    void Start()
    {
        uiScript = GameObject.Find("GameManager").GetComponent<UIScript>();
        if (uiScript.gameStarted)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "SpawnPoint")
                {
                    spawners.Add(child.gameObject);
                }
            }

            spawnPoint = chooseSpawner();
            int chooseCar = Random.Range(0, cars.Count);
            otherCarSpeed = Random.Range(5, 20);

            spawnedCar = Instantiate(cars[chooseCar], spawners[spawnPoint].transform.position, new Quaternion(0, 180, 0, 0));
            Destroy(spawnedCar, 10f);
        }
    }

    private void Update()
    {
        spawnedCar.transform.Translate(new Vector3(0, 1, otherCarSpeed) * Time.deltaTime);
    }

    int chooseSpawner()
    {
        float rand = Random.value;
        if (rand <= .9f) return Random.Range(0, spawners.Count - 1);
        return spawners.Count - 1;
    }
}
