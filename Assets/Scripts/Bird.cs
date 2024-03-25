using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rig;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rig.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.status)
        {
            case GameStatus.Start:
                StartUpdate();
                    break;
            case GameStatus.Play:
                PlayUpdate();
                    break;
            case GameStatus.GameOver:
                GameOverUpdate();
                    break;
        }
    }


    void StartUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.StartGame();
            rig.bodyType = RigidbodyType2D.Dynamic;
            Jump();
        }
    }

    void Jump()
    {
        rig.velocity = Vector3.up * jumpForce;
    }

    void PlayUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // rig.AddForce(Vector3.up * jumpForce); Adiciona impulso com in�rcia
            // rig.velocity = Vector3.up * jumpForce;
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }


    void GameOverUpdate()
    {
    
    }
}


    
