using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private GameObject laser;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(CalculateNewPosition());
        RestrictXAxis();
        if (Input.GetKeyDown(KeyCode.Space) && !laser.activeSelf)
        {
            laser.SetActive(true);
            laser.transform.position = gameObject.transform.position;
        }
    }

    private Vector2 CalculateNewPosition()
    {
        float newSpeed = Input.GetAxis("Horizontal") * speed;
        Vector2 motion = new Vector2(newSpeed * Time.deltaTime, 0);
        return motion;
    }

    public void Move(Vector2 movement)
    {
        gameObject.transform.Translate(movement);
    }

    private void RestrictXAxis()
    {
        float newX = Mathf.Clamp(gameObject.transform.position.x, -8.5f, 8.5f);
        gameObject.transform.position = new Vector3(newX, -4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            manager.GameOver();
        }
    }
}
