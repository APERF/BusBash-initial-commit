using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables START
    private Rigidbody playerRb;
    public GameManager gameManager;
    
    private float speed = 10f;
    private float jumpHeight = 150f;
    private float horizontalInput;

    public int scoreValue;

    public bool inAir = false;
    public bool gameOver = false;
    //Variables END

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set Input Listener
        horizontalInput = Input.GetAxis("Horizontal");

        //Move player on Input and if Game is not Over
        if (!gameOver)
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }

        //Force Only One Jump
        if (Input.GetKeyDown(KeyCode.Space) && !inAir && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            inAir = true;
        }

        if (gameManager.lives <= 0)
        {
            gameManager.UpdateGameOver();
            gameOver = true;
            gameManager.livesText.gameObject.SetActive(false);
        }
    }

   //Destroy Enemies or Crates on Player Collisions
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            inAir = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(scoreValue);
        }
    }
}
