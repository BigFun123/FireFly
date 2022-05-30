using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource sound;
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        if (sound != null)
        {
            sound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!sound.isPlaying)
        {
            Skip();
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene("MainScene");
    }
}
