using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rig;
    public float jumpForce;
    public Animator animator;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
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

    public void StartGame()
    {
        rig.bodyType = RigidbodyType2D.Dynamic;
        Jump();
        animator.SetBool("isAluve", true);
    }


    void StartUpdate()
    {
     
    }

    void Jump()
    {
        rig.velocity = Vector3.up * jumpForce;
    }

    void PlayUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // rig.AddForce(Vector3.up * jumpForce); Adiciona impulso com inércia
            // rig.velocity = Vector3.up * jumpForce;
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
        animator.SetBool("isAluve", false);
    }


    void GameOverUpdate()
    {
    
    }

    public void Restart()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rig.bodyType = RigidbodyType2D.Static;
        animator.SetBool("isAluve", true);

    }
}


    
