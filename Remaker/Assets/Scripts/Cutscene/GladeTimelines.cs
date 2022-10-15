using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class GladeTimelines : MonoBehaviour
{

    [SerializeField] private GameObject tmp;
    [SerializeField] private PlayableDirector manager;
    [SerializeField] private TimelineAsset maleStart;
    [SerializeField] private TimelineAsset femaleStart;
    [SerializeField] private TimelineAsset maleRockBreak;
    [SerializeField] private TimelineAsset femaleRockBreak;

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
