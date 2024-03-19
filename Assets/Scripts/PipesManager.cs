using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipesManager : MonoBehaviour
{

    public GameObject pipeModel;
    public Transform spawnPoint;
    public float interval;

    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > interval)
        {
            CreatePipe();
            currentTime = 0f;
        }
    }


    void CreatePipe()
    {
        var pipeGameObject = Instantiate(pipeModel);
        var pipeTransform = pipeGameObject.GetComponent<Transform>();

        float y = Random.Range(-3.0f, -0.6f);

        pipeTransform.position = new Vector3(spawnPoint.position.x, y);
    }



}
