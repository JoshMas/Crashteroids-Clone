using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameManager manager;
    private void Start()
    {
        manager = GetComponentInParent<GameManager>();
    }
    /*
    [SerializeField]
    private float speed = 5.0f;

    private void Update()
    {
        gameObject.transform.position = CalculateNewPosition();
    }

    private Vector2 CalculateNewPosition()
    {
        Vector3 motion = new Vector3(0, speed * Time.deltaTime);
        return gameObject.transform.position + motion;
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            manager.IncrementScore();
        }
        if (!collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
