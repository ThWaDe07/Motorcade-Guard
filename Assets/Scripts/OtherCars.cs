using UnityEngine;
public class OtherCars : MonoBehaviour
{
    public BoxCollider box;

    UIScript uiScript;
    void Start()
    {
        uiScript = GameObject.Find("GameManager").GetComponent<UIScript>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jeep"))
        {
            box.isTrigger = false;
            other.transform.parent = null;
            other.GetComponent<BoxCollider>().enabled = false;

            other.transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 5f);
            Destroy(other.gameObject, 5f);
        }
        if (other.gameObject.CompareTag("Limo"))
        {
            box.isTrigger = false;
            other.transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            uiScript.LimoHealth -= 1;
            Destroy(gameObject, 5f);
        }
    }
}