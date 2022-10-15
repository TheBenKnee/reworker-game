using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;

public class GrowBerry : MonoBehaviour
{
    [SerializeField] private PlayableDirector myDirector;
    [SerializeField] private GameObject playerObject;
    public TextMeshProUGUI introDialogue;

    [SerializeField] private Image berry;

    [SerializeField] private Canvas playerUI;
    [SerializeField] private Image introUI;
    [SerializeField] private GameObject nameInput;

    [SerializeField] private GameObject selection;

    public float nameEntered = 0.0f;
    private float genderSelected = 0.0f;

    private Vector2 imageSize;
    
    void Awake()
    {
        imageSize = berry.rectTransform.sizeDelta;
    }

    void OnEnable()
    {
        myDirector.stopped += OnPlayableDirectorStopped;
    }

    void OnDisable()
    {
        myDirector.stopped -= OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (myDirector == aDirector)
        {
            introDialogue.text = "I haven't even asked you your name...";
            nameInput.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if(myDirector.time > 3.05 && myDirector.time < 5.07)
        {
            imageSize.x += 0.2f;
            imageSize.y += 0.2f;
            berry.rectTransform.sizeDelta = imageSize;
        }
        if(myDirector.time > 6.08 && myDirector.time < 7.08)
        {
            imageSize.x += 0.85f;
            imageSize.y += 0.85f;
            berry.rectTransform.sizeDelta = imageSize;
        }
        if(myDirector.time > 12.00)
        {
            introDialogue.text = "Oh my. Where are my manners?";
        }
        if(nameEntered > 0.0f && nameEntered < 60.0f)
        {
            if(nameEntered < 10.0f || (nameEntered > 30.0f && nameEntered < 50.0f))
            {
                berry.rectTransform.transform.Translate(3.5f, -3.5f, 0.0f);
            }
            if((nameEntered > 10.0f && nameEntered < 30.0f) || nameEntered > 50.0f)
            {
                berry.rectTransform.transform.Translate(-3.5f, 3.5f, 0.0f);
            }

            nameEntered += 0.5f;
        }
        if(nameEntered > 60.0f)
        {
            nameInput.gameObject.SetActive(false);
            introDialogue.text = "And sorry, strawberries don't have the best eyes. Are you a boy or a girl?";
            IntroDialogue dialogObj = introUI.gameObject.GetComponent(typeof(IntroDialogue)) as IntroDialogue;
            if(dialogObj)
                dialogObj.needFadeIn = true;
            nameEntered = 0.0f;
        }
        if(genderSelected > 0.0f && genderSelected < 40.0f)
        {
            if(genderSelected < 10.0f)
            {
                introDialogue.text = "Sweet. Hey, I have to go.";
            }
            if(genderSelected > 10.0f && genderSelected < 25.0f)
            {
                introDialogue.text = "The exit to this clearing is past the boulder behind you.";
            }
            if(genderSelected > 25.0f)
            {
                introDialogue.text = "Don't worry. I'm sure we'll see each other again.";
            }
            genderSelected += 0.1f;
        }
        if(genderSelected > 40.0f)
        {
            genderSelected = 0.0f;
            playerUI.gameObject.SetActive(true);
            introUI.gameObject.SetActive(false);
            //PixelCrushers.DialogueSystem.DialogueLua.GetVariable("SaveNumber").AsInt;
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("Aaaaaa", 1);
            playerObject.GetComponent<Transform>().position = new Vector3(-1.15f, -1.34f, 0f);
            playerObject.GetComponent<StateMachine>().ChangeState(GenericState.idle);
        }
    }

    public void SelectGender(int option)
    {
        selection.SetActive(false);
        if(option == 1)
        {
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("PlayerGender", 1);
        }
        else
        {
            PixelCrushers.DialogueSystem.DialogueLua.SetVariable("PlayerGender", 0);
        }
        genderSelected = 0.01f;
    }
}
