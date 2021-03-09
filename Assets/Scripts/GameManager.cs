using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;
    private List<GameObject> asteroids = new List<GameObject>();
    private int a_marker = 0;

    private float asteroidDelay;
    private float delayTimer;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        while (asteroids.Count < 10)
        {
            GameObject new_asteroid = Instantiate(asteroid);
            asteroids.Add(new_asteroid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTimer > asteroidDelay)
        {
            ResetTimer();
            SpawnAsteroid();
        }
        delayTimer += Time.deltaTime;
    }

    private void ResetTimer()
    {
        asteroidDelay = Random.Range(1.0f, 2.0f);
        delayTimer = 0.0f;
    }

    public GameObject SpawnAsteroid()
    {
        GameObject temp = asteroids[a_marker];
        temp.SetActive(true);
        a_marker = (a_marker + 1) % 10;
        return temp;
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        score = 0;
        scoreText.text = "Score: 0";
        foreach (GameObject a in asteroids)
        {
            a.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public PlayerControls GetPlayer()
    {
        return GetComponentInChildren<PlayerControls>();
    }

    public GameObject GetLaser()
    {
        return GetComponentInChildren<Laser>(true).gameObject;
    }
}
