using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    // 1 = normal, 10 = very difficult
    public float Difficulty = 1f;
    public GameObject ChaserTemplate;
    public Runner Protagonist;
    public float DelayBetweenSpawns = 10;
    public float CountDown = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= Time.deltaTime;
        if (CountDown <0)
        {
            CountDown = DelayBetweenSpawns;
            SpawnChaser();
        }
    }

    void SpawnChaser()
    {
        GameObject newChaser = Instantiate(ChaserTemplate);
        Chaser cs = newChaser.gameObject.GetComponent<Chaser>();
        newChaser.transform.position = new Vector3(0, -6, 0);
        cs.TargetObject = Protagonist;
        cs.Speed = 0.1f + Random.value;
    }
}
