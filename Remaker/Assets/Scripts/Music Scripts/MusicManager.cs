using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private bool cutsceneMusicActive = false;
    [SerializeField] private bool singleLoop = false;
    [SerializeField] private AudioSource[] songs;
    [SerializeField] private int[] songChance;
    

    public void startSong()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject mine = GameObject.Find("Test");
        // Debug.Log(mine.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
