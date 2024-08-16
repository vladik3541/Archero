using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WaveConfige[] wave;
    [SerializeField] private Transform[] walls;
    private float timeWaiteBetweenWave = 3f;
    private int currentWave = 0;

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
