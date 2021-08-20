using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private bool clueActive = false;

    private void Start()
    {
        mySprite.enabled = clueActive;
    }

    public void ChangeClue()
    {
        clueActive = !clueActive;
        mySprite.enabled = clueActive;
    }
}