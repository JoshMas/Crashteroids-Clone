using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject gameSystem;

    private GameObject gameInstance;
    // Start is called before the first frame update
    void Start()
    {
        gameInstance = Instantiate(gameSystem);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameInstance.activeSelf)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        gameInstance.SetActive(true);
    }
}
