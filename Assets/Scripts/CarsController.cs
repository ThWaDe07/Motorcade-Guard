using UnityEngine;
public class CarsController : MonoBehaviour
{
    public float carSpeed = 10f;
    float hMove;

    UIScript uiScript;
    void Start()
    {
        uiScript = GameObject.Find("GameManager").GetComponent<UIScript>();
    }

    void FixedUpdate()
    {
        if (uiScript.gameStarted)
        {
            if (Input.touchCount > 0 && transform.position.x < 5.5f && transform.position.x > -5.5f)
            {
                hMove = 0.2f * Input.touches[0].deltaPosition.x;
            }
            else if (transform.position.x > 5.5f)
            {
                hMove = -1;
            }
            else if (transform.position.x < -5.5f)
            {
                hMove = 1;
            }
            else
            {
                hMove = 0;
            }

            transform.Translate(new Vector3(hMove, 1, carSpeed) * Time.deltaTime);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        }
    }
}