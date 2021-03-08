using UnityEngine;
public class CameraController : MonoBehaviour
{
    private Transform carLimo;
    public float yOffSet;
    public float zOffSet;
    void Start()
    {
        carLimo = GameObject.Find("Limo").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(carLimo.position.x, carLimo.position.y + yOffSet, carLimo.position.z + zOffSet);
    }
}
