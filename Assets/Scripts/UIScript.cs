using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    public GameObject DistanceText;
    public GameObject countDownText;
    public GameObject tapButton;
    public GameObject gamePanel;
    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject tapToStartText;
    public GameObject levelText;
    public GameObject healthText;
    public GameObject medal;
    public Sprite[] medalTextures;
    public bool gameStarted = false;
    public int Level;
    public int LimoHealth = 2;

    GameObject limo;
    int distance;
    int initAmount;
    int tempChildCount;
    float tempDistance;
    Text distText;
    RoadSpawner roadSpawner;
    PlotSpawner plotSpawner;
    void Start()
    {
        limo = GameObject.Find("Limo");
        Level = PlayerPrefs.GetInt("level", 1);
        levelText.GetComponent<Text>().text = "Level: " + Level;
        LimoHealth = 2;
        healthText.GetComponent<Text>().text = "Health: " + LimoHealth;

        gameStarted = false;
        distText = DistanceText.GetComponent<Text>();

        tempDistance = Random.Range(50, 100) * Level;
        distance = Mathf.RoundToInt(tempDistance);
        distText.text = "Distance: " + distance;
        
        roadSpawner = GameObject.Find("SpawnManager").GetComponent<RoadSpawner>();
        plotSpawner = GameObject.Find("SpawnManager").GetComponent<PlotSpawner>();
        initAmount = roadSpawner.roads.Count;
        tempChildCount = limo.transform.childCount;
    }

    void Update()
    {
        if (gameStarted)
        {
            tempDistance -= 10 * Time.deltaTime;
            distance = Mathf.RoundToInt(tempDistance);

            distText.text = "Distance: " + distance;

            healthText.GetComponent<Text>().text = "Health: " + LimoHealth;

            if (LimoHealth == 0)
            {
                gameStarted = false;
                gamePanel.GetComponent<Animator>().Play("FadeIn");
                StartCoroutine(RestartLevel());
            }
            if (distance <= 1)
            {
                if (limo.transform.childCount < tempChildCount)
                {
                    if (LimoHealth < 2) { medal.GetComponent<Image>().sprite = medalTextures[2]; }
                    else { medal.GetComponent<Image>().sprite = medalTextures[1]; }
                } else { medal.GetComponent<Image>().sprite = medalTextures[0]; }
                gameStarted = false;
                gamePanel.GetComponent<Animator>().Play("FadeIn");
                StartCoroutine(EndLevel());
            }
        }
    }

    public void TapToStart()
    {
        tapButton.SetActive(false);
        gamePanel.GetComponent<Animator>().Play("FadeOut");
        StartCoroutine(StartGame());
        tapToStartText.SetActive(false);
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        countDownText.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDownText.GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1f);
        countDownText.GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1f);
        gameStarted = true;
        countDownText.SetActive(false);
        countDownText.GetComponent<Text>().text = "3";
        for (int i = 5; i < roadSpawner.roads.Count; i++)
        {
            plotSpawner.SpawnPlotStart(i);
        }
    }
    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(0.5f);
        Level++;
        PlayerPrefs.SetInt("level", Level);
        winPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameScene");
    }
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(0.5f);
        lostPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameScene");
    }
}

