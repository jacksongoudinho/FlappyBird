using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class pipe : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;

        if (transform.position.x < -3.1f)
        {
            // Autoexcluir

            Destroy(gameObject);

        }

    }
}
