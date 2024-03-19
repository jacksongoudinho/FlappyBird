using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rig;
    public float jumpForce;
    public BirdStatus status = BirdStatus.Start;

    // Start is called before the first frame update
    void Start()
    {
        rig.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case BirdStatus.Start:
                StartUpdate();
                    break;
            case BirdStatus.Play:
                PlayUpdate();
                    break;
            case BirdStatus.GameOver:
                GameOverUpdate();
                    break;
        }
    }


    void StartUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            status = BirdStatus.Play;
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
        status = BirdStatus.GameOver;
    }


    void GameOverUpdate()
    {
    
    }

    public enum BirdStatus
    {
        Start,
        Play,
        GameOver
    }
}


    
