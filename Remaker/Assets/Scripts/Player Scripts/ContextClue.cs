using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    [SerializeField] private SpriteRenderer talkSprite;
    [SerializeField] private SpriteRenderer interactSprite;
    [SerializeField] private SpriteRenderer multiTaskingSprite;
    private int talkers = 0;
    private int interactors = 0;

    void OnEnable()
    {
        UpdateUI();
    }

    public void AddTalker()
    {
        talkers += 1;
        UpdateUI();
    }

    public void RemoveTalker()
    {
        talkers -= 1;
        if(talkers < 0)
        {
            talkers = 0;
        }
        UpdateUI();
    }

    public void AddInteractor()
    {
        interactors += 1;
        UpdateUI();
    }

    public void RemoveInteractor()
    {
        interactors -= 1;
        if(interactors < 0)
        {
            interactors = 0;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if(talkers > 0 && interactors > 0)
        {
            multiTaskingSprite.enabled = true;
            talkSprite.enabled = false;
            interactSprite.enabled = false;
        }
        else
        {
            if(talkers > 0)
            {
                multiTaskingSprite.enabled = false;
                talkSprite.enabled = true;
                interactSprite.enabled = false;
            }
            else
            {
                if(interactors > 0)
                {
                    multiTaskingSprite.enabled = false;
                    talkSprite.enabled = false;
                    interactSprite.enabled = true;
                }
                else
                {
                    multiTaskingSprite.enabled = false;
                    talkSprite.enabled = false;
                    interactSprite.enabled = false;
                }
            }
        }
    }
}