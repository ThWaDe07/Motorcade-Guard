using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    private RoadSpawner roadSpawner;
    private PlotSpawner plotSpawner;

    public int roadType;
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner = GetComponent<PlotSpawner>();
    }

    public void SpawnTriggerEntered()
    {
        if (roadSpawner.roadCanBend == true)
        {
            roadType = DecideType();
            if (roadType > 0) roadSpawner.roadBending = true;
        }
        if (roadSpawner.howManyRoadBending == 0) roadType = 0;

        roadSpawner.MoveRoad(roadType);
        plotSpawner.SpawnPlot(roadType);
    }

    int DecideType()
    {
        // 0 - Just horizontal  - high chance
        // 1 - Lean left        - normal chance
        // 2 - Lean right       - normal chance
        // 3 - Climb uphill     - normal chance
        // 4 - Descend downhill - normal chance
        // level based chance

        float rand = Random.value;

        if (rand <= .6f) return 0;
        return Random.Range(1, 5);
    }
}
