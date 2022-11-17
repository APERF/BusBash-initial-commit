using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownwards : MonoBehaviour
{
    private float obstacleSpeed = 30f;
    private float stayInLine = 0f;
    private float outOfBounds = -30f;

    private int livesValue = 1;

    private GameManager gameManager;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("Enemy") || gameObject.CompareTag("Crate") || gameObject.CompareTag("SpeedUp_PowerUp"))
        {
            transform.Translate(new Vector3(stayInLine, stayInLine, -obstacleSpeed) * Time.deltaTime);
            
            if (gameObject.transform.position.z < outOfBounds)
            {
                gameManager.UpdateLives(livesValue);
                Destroy(gameObject);   
            }
        }

        if(gameObject.CompareTag("Ground") && playerController.gameOver == false)
        {
            transform.Translate(new Vector3(stayInLine, stayInLine, -obstacleSpeed) * Time.deltaTime);
        } 
    }
}
