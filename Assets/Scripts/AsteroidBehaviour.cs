using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResetPosition();
        //set its size to a random variable
        RandomiseSize();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetPosition();
        RandomiseSize();
        gameObject.SetActive(false);
    }

    private void ResetPosition()
    {
        //set its position to a random x-value above the camera
        float randomX = Random.Range(-9.0f, 9.0f);
        gameObject.transform.position = new Vector2(randomX, 6.0f);
    }

    private void RandomiseSize()
    {
        float randomSize = Random.Range(0.5f, 2.0f);
        Vector2 size = new Vector2(randomSize, randomSize);
        gameObject.transform.localScale = size;
    }
}
