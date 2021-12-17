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
    public Button DamageBtn;
    public void GameOver()
    {

        Lose_text.gameObject.SetActive(true);
        ResetBtn.gameObject.SetActive(true);
        DamageBtn.gameObject.SetActive(false);
    }

    public void OnClickReset()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
