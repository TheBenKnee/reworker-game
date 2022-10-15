using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class BoulderDestruction : MonoBehaviour
{
    
    [SerializeField] private PlayableDirector maleDirector;
    [SerializeField] private PlayableDirector femaleDirector;
    private PlayableDirector activeDirector;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private Text myText;

    [SerializeField] GameObject boulder;
    [SerializeField] GameObject playerObject;

    private int gender;

    public void startBoulder()
    {
        gender = PixelCrushers.DialogueSystem.DialogueLua.GetVariable("PlayerGender").AsInt;
        myText.text = "Whoa whoa whoa. What are you doing there?";
        if(gender == 1)
        {
            activeDirector = femaleDirector;
        }
        else
        {     
            activeDirector = maleDirector;
            
        }
        activeDirector.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeDirector)
        {
            if(activeDirector.time > 7.00 && activeDirector.time < 10.07)
            {
                myText.text = "You don't break a rock with a sword!";
            }
            if(activeDirector.time > 10.07 && activeDirector.time < 13.07)
            {
                myText.text = "What were you? Made yesterday or something?";
            }
            if(activeDirector.time > 13.07 && activeDirector.time < 17.00)
            {
                myText.text = "Here, I got you.";
                if(maleDirector.time > 16.00)
                {
                    boulder.SetActive(false);
                }
            }
            if(activeDirector.time > 17.00)
            {
                myText.text = "Also, you swing a sword with space not e, dumbie.";
            }        
            if(activeDirector.time > 21.57)
            {
                endCutscene();
            }
        }

    }

    public void endCutscene()
    {
        dialogBox.SetActive(false);
        activeDirector.Stop();
        playerObject.GetComponent<StateMachine>().ChangeState(GenericState.idle);
    }
}
