using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public TMP_Text Lose_text;
    public Button ResetBtn;
    public List<Button> buttons;
    public void GameOver()
    {
        Lose_text.gameObject.SetActive(true);
        ResetBtn.gameObject.SetActive(true);
        foreach(var i in buttons)
        {
            i.interactable = false;
        }
    }

    public void OnClickReset()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
