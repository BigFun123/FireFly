using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoreText(float score)
    {
        TextMeshProUGUI t = GetComponent<TextMeshProUGUI>();
        t.text = "Glow " + score.ToString();
    }
}
