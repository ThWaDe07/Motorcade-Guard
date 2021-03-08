using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    public GameObject roadsParent;
    public float offSet = 20f;

    public bool roadBending;
    public bool roadCanBend;
    public bool firstHillRoad;
    public bool firstLeanRoad;
    public int howManyRoadBending = 0;

    public GameObject roadHorizontal;
    public GameObject roadLeanLeft;
    public GameObject roadLeanRight;
    public GameObject roadClimbUpHill;
    public GameObject roadDescendDownHill;

    GameObject moveRoad, moveRoadNew;
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
        roadBending = false;
        roadCanBend = false;
    }

    public void MoveRoad(int type)
    {
        // type 0 - Just horizontal  - high chance
        // type 1 - Lean left        - normal chance
        // type 2 - Lean right       - normal chance
        // type 3 - Climb uphill     - normal chance
        // type 4 - Descend downhill - normal chance

        moveRoad = roads[0];
        roads.Remove(moveRoad);

        howManyRoadBending--;

        // roads going horizontal, leaned left, leaned right, upwards, downwards
        if (roadBending == false && howManyRoadBending != 0)
        {
            if (type == 0)
            {
                moveRoadNew = Instantiate(roadHorizontal, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
            } //horizontal
            if (type == 1)
            {
                moveRoadNew = Instantiate(roadHorizontal, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
                moveRoadNew.transform.Rotate(0, 0, 30, Space.World);
                firstLeanRoad = false;
            } //leaned left
            if (type == 2)
            {
                moveRoadNew = Instantiate(roadHorizontal, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
                moveRoadNew.transform.Rotate(0, 0, -30, Space.World);
                firstLeanRoad = false;
            } //leaned right
            if (type == 3)
            {
                if (firstHillRoad == true) //becuase of models measure, the position of object that will come next is different
                {
                    moveRoadNew = Instantiate(roadHorizontal, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                    Destroy(moveRoad);
                    float newZ = roads[roads.Count - 1].transform.position.z + 17.779f;
                    float newY = roads[roads.Count - 1].transform.position.y + 10.083f;
                    moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                    moveRoadNew.transform.position += moveRoadNew.transform.up * newY;
                    moveRoadNew.transform.Rotate(-30, 0, 0, Space.World);
                    firstHillRoad = false;
                } else
                {
                    moveRoadNew = Instantiate(roadHorizontal, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                    Destroy(moveRoad);
                    float newZ = roads[roads.Count - 1].transform.position.z + 17.321f;
                    float newY = roads[roads.Count - 1].transform.position.y + 10f;
                    moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                    moveRoadNew.transform.position += moveRoadNew.transform.up * newY;
                    moveRoadNew.transform.Rotate(-30, 0, 0, Space.World);
                }
            } //upwards
            if (type == 4)
            {
                if (firstHillRoad == true) //becuase of models measure, the position of object that will come next is different
                {
                    moveRoadNew = Instantiate(roadHorizontal, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                    Destroy(moveRoad);
                    float newZ = roads[roads.Count - 1].transform.position.z + 17.737f;
                    float newY = roads[roads.Count - 1].transform.position.y - 10.153f;
                    moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                    moveRoadNew.transform.position += moveRoadNew.transform.up * newY;
                    moveRoadNew.transform.Rotate(30, 0, 0, Space.World);
                    firstHillRoad = false;
                }
                else
                {
                    moveRoadNew = Instantiate(roadHorizontal, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                    Destroy(moveRoad);
                    float newZ = roads[roads.Count - 1].transform.position.z + 17.26492f;
                    float newY = roads[roads.Count - 1].transform.position.y - 9.947f;
                    moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                    moveRoadNew.transform.position += moveRoadNew.transform.up * newY;
                    moveRoadNew.transform.Rotate(30, 0, 0, Space.World);
                }
            } //downwards
        }

        // roads changing shape
        if (roadBending == true && howManyRoadBending != 0)
        {
            roadBending = false;
            roadCanBend = false;
            howManyRoadBending = Random.Range(3, 10);

            if (type == 1)
            {
                moveRoadNew = Instantiate(roadLeanLeft, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
                firstLeanRoad = true;
            } //lean left
            if (type == 2)
            {
                moveRoadNew = Instantiate(roadLeanRight, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
                firstLeanRoad = true;
            } //lean right
            if (type == 3)
            {
                moveRoadNew = Instantiate(roadClimbUpHill, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
                firstHillRoad = true;
            } //Climb uphill
            if (type == 4)
            {
                moveRoadNew = Instantiate(roadDescendDownHill, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
                firstHillRoad = true;
            } //Descend downhill
        }

        // it allows to change roads shape
        if (howManyRoadBending == -1) roadCanBend = true;

        // roads changing back to horizontal
        if (howManyRoadBending == 0)
        {
            if (type == 1)
            {
                moveRoadNew = Instantiate(roadLeanRight, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
                moveRoadNew.transform.Rotate(0, 0, 30, Space.World);
            } //lean left to horizontal
            if (type == 2)
            {
                moveRoadNew = Instantiate(roadLeanLeft, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + offSet;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * roads[roads.Count - 1].transform.position.y;
                moveRoadNew.transform.Rotate(0, 0, -30, Space.World);
            } //lean right to horizontal
            if (type == 3)
            {
                moveRoadNew = Instantiate(roadDescendDownHill, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + 17.321f;
                float newY = roads[roads.Count - 1].transform.position.y + 10f;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * newY;
                moveRoadNew.transform.Rotate(-30, 0, 0, Space.World);
            } //lean upwards to horizontal
            if (type == 4)
            {
                moveRoadNew = Instantiate(roadClimbUpHill, moveRoad.transform.position, new Quaternion(0, 0, 0, 0));
                Destroy(moveRoad);
                float newZ = roads[roads.Count - 1].transform.position.z + 17.33808f;
                float newY = roads[roads.Count - 1].transform.position.y - 9.97f;
                moveRoadNew.transform.position = moveRoadNew.transform.forward * newZ;
                moveRoadNew.transform.position += moveRoadNew.transform.up * newY;
                moveRoadNew.transform.Rotate(30, 0, 0, Space.World);
            } //lean downwards to horizontal
        }

        moveRoadNew.transform.parent = roadsParent.transform;
        roads.Add(moveRoadNew);
    }
}