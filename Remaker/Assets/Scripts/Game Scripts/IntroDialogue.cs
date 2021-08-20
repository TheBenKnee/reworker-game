using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class IntroDialogue : MonoBehaviour
{
    [SerializeField] private GameSaveManager saveManager;
    [SerializeField] private PlayableDirector introCutscene;

    [SerializeField] private int fadeTime;
    public bool needFadeIn = false;

    [SerializeField] private Image boyImage;
    [SerializeField] private Image girlImage;

    // [SerializeField] private Button maleButton;
    // [SerializeField] private Button femaleButton;

    // private Image mButtonImage;
    // private Image fButtonImage;

    private Color previewColor;
    private Color buttonColor;

    void FixedUpdate()
    {
        if(needFadeIn)
        {

            // if(!maleButton.gameObject.activeSelf || !femaleButton.gameObject.activeSelf)
            // {
            //     maleButton.gameObject.SetActive(true);
            //     femaleButton.gameObject.SetActive(true);
            // }
            boyImage.color = previewColor;
            girlImage.color = previewColor;
            // mButtonImage.color = buttonColor;
            // fButtonImage.color = buttonColor;
            if(previewColor.a < 1)
            {
                previewColor.a += 0.01f;
            }
            // if(buttonColor.a < 1)
            // {
            //     buttonColor.a += 0.01f;
            // }
            fadeTime--;
            if(fadeTime <= 0)
            {
                needFadeIn = false;
            }
        }
    }

    void Awake()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<GameSaveManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // mButtonImage = maleButton.transform.GetComponent<Image>();
        // fButtonImage = femaleButton.transform.GetComponent<Image>();
        
        previewColor = boyImage.color;
        // buttonColor = mButtonImage.color;
        
        previewColor.a = 0f;
        // buttonColor.a = 0f;

        boyImage.color = previewColor;
        girlImage.color = previewColor;
        // mButtonImage.color = buttonColor;
        // fButtonImage.color = buttonColor;

        // maleButton.gameObject.SetActive(false);
        // femaleButton.gameObject.SetActive(false);

        introCutscene.Play();
    }
}
