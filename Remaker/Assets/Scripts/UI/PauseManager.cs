using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private bool isPaused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private FloatValue gameSpeed;  //Making this a FloatValue instead of a hardcoded '1' allows us to preserve the speed of the game in the event of a game speed change (slow mo/speed up)
    [SerializeField] private string menuSceneString;
    [SerializeField] private GameSaveManager gameSave;

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButtonUp("Pause"))
        // {
        //     for(int i = 0; i < this.gameObject.transform.childCount; i++)
        //     {
        //         if(this.gameObject.transform.GetChild(i).gameObject.activeSelf && this.gameObject.transform.GetChild(i).gameObject != pauseMenu)
        //         {
        //             this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        //             Time.timeScale = gameSpeed.value;
        //         }
        //     }
        //     ChangePauseValue();
        // }
    }

    void ChangePauseValue()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = gameSpeed.value;
        }
    }

    public void ResumeButton()
    {
        ChangePauseValue();
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(menuSceneString);
    }
}