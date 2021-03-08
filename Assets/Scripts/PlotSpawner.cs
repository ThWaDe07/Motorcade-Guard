using System.Collections.Generic;
using UnityEngine;
public class PlotSpawner : MonoBehaviour
{
    public float xPos = 20f;

    public List<GameObject> plotsLeft;
    public List<GameObject> plotsRight;

    RoadSpawner roadSpawner;
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
    }

    public void SpawnPlot(int type)
    {
        GameObject plotLeft = plotsLeft[Random.Range(0, plotsLeft.Count)];
        GameObject plotRight = plotsRight[Random.Range(0, plotsRight.Count)];

        Vector3 newPos = roadSpawner.roads[roadSpawner.roads.Count - 1].transform.position;

        GameObject pLeft = Instantiate(plotLeft, new Vector3(newPos.x - xPos, newPos.y + 0.5f, newPos.z), plotLeft.transform.rotation);
        GameObject pRight = Instantiate(plotRight, new Vector3(newPos.x + xPos, newPos.y + 0.5f, newPos.z), new Quaternion(0, 180, 0, 0));

        if (type == 1)
        { 
            if (roadSpawner.firstLeanRoad == true)
            {
                pLeft.transform.position = new Vector3(pLeft.transform.position.x, pLeft.transform.position.y - 2.13f, pLeft.transform.position.z);
                pRight.transform.position = new Vector3(pRight.transform.position.x, pRight.transform.position.y + 2.13f, pRight.transform.position.z);
            } else
            {
                pLeft.transform.position = new Vector3(pLeft.transform.position.x + 1.34f, pLeft.transform.position.y - 4.685f, pLeft.transform.position.z);
                pRight.transform.position = new Vector3(pRight.transform.position.x - 1.34f, pRight.transform.position.y + 4.685f, pRight.transform.position.z);
            }
        }
        if (type == 2)
        {
            if (roadSpawner.firstLeanRoad == true)
            {
                pLeft.transform.position = new Vector3(pLeft.transform.position.x, pLeft.transform.position.y + 2.13f, pLeft.transform.position.z);
                pRight.transform.position = new Vector3(pRight.transform.position.x, pRight.transform.position.y - 2.13f, pRight.transform.position.z);
            }
            else
            {
                pLeft.transform.position = new Vector3(pLeft.transform.position.x + 1.34f, pLeft.transform.position.y + 4.685f, pLeft.transform.position.z);
                pRight.transform.position = new Vector3(pRight.transform.position.x - 1.34f, pRight.transform.position.y - 4.685f, pRight.transform.position.z);
            }
        }

        Destroy(pLeft, 10f);
        Destroy(pRight, 10f);
    }
    public void SpawnPlotStart(int i)
    {
        GameObject plotLeft = plotsLeft[Random.Range(0, plotsLeft.Count)];
        GameObject plotRight = plotsRight[Random.Range(0, plotsRight.Count)];

        Vector3 newPos = roadSpawner.roads[i].transform.position;

        GameObject pLeft = Instantiate(plotLeft, new Vector3(newPos.x - xPos, newPos.y + 0.5f, newPos.z), plotLeft.transform.rotation);
        GameObject pRight = Instantiate(plotRight, new Vector3(newPos.x + xPos, newPos.y + 0.5f, newPos.z), new Quaternion(0, 180, 0, 0));

        Destroy(pLeft, 10f);
        Destroy(pRight, 10f);
    }
}