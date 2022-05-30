using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * FireFly is a Kafka-esque game about chasing food and running from moths
 * Our hero-protagonist (Kafka) must eat light to survive, but every time he eats, a jealous moth appears to taunt him
 * The game has no end other than complete entropy or returning to 0 Glow
 * 
 * Factory pattern to instantiate moths and food for Kafka
 * Mediator to handle food consumption and calculate score (Glow) 
 * 
 */

public class GameService : MonoBehaviour
{
    public float GlowScore = 1f;
    // 1 = normal, 10 = very difficult    
    public float Difficulty = 1f;
    public float DifficultyStep = 0.1f;
    public GameObject ChaserTemplate;
    public GameObject FoodTemplate;
    public Runner Protagonist;
    public float DelayBetweenSpawns = 5;
    public float CountDown = 10;

    public Vector2 WorldSize = new Vector2(3, 3);
    void Start()
    {
        SpawnChaser();
        SpawnFood();
    }
    
    void Update()
    {
        CountDown -= Time.deltaTime;
        if (CountDown <0)
        {
            CountDown = DelayBetweenSpawns / Difficulty;
            SpawnChaser();
            SpawnFood();
        }
    }

    /*
     * Create some food for our hero to eat
     */
    void SpawnFood()
    {
        GameObject newFood = Instantiate(FoodTemplate);        
        newFood.transform.position = new Vector3(Random.Range(-WorldSize.x, WorldSize.x), Random.Range(-WorldSize.y, WorldSize.y), 0);        
    }

    /*
     * Create a new chaser with random properties     
     */
    void SpawnChaser()
    {
        GameObject newChaser = Instantiate(ChaserTemplate);
        Chaser cs = newChaser.gameObject.GetComponent<Chaser>();
        newChaser.transform.position = new Vector3(0, -WorldSize.y * 2, 0);
        newChaser.transform.localScale += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        cs.TargetObject = Protagonist;
        cs.Speed = 0.1f + Random.value;
    }

    /*
     * Called by an object in the Game when it eats food
     */
    public void AteFood(float amt)
    {   
        Difficulty += DifficultyStep;
        GlowScore += amt;
        SetScore(GlowScore);
    }

    /*
     * Protagonist hit a moth
     */
    public void HitMoth(float amt)
    {
        GlowScore -= amt;
        SetScore(GlowScore);
    }

    /*
    * Tell the world the score
    */
    void SetScore(float score)
    {
        gameObject.BroadcastMessage("SetScoreText", score);
    }
}
