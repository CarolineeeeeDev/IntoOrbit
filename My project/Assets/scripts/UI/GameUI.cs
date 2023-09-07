using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject pressSpaceText;
    [SerializeField] private TMP_Text powerText;
    [SerializeField] private Slider slider;

    private void Start() {
        scoreText.text = "SCORE " + ScoreManager.Instance.currentScore;
        livesText.text = "LIVES " + Dome.Instance.GetLives();
        powerText.text = "<" + (Player.Instance.G / 100).ToString()+">";

        ScoreManager.Instance.OnScoreChange += ScoreManager_OnScoreChange;
        Dome.Instance.OnLivesChange += Dome_OnLivesChange;
        GameInput.Instance.OnAction += GameInput_OnAction;
        GameStateManager.Instance.OnStateChanged += GameStateManager_OnStateChanged;
        GameInput.Instance.OnIncrease += GameInput_OnIncrease; ;
        GameInput.Instance.OnDecrease += GameInput_OnDecrease; ;

        pressSpaceText.gameObject.SetActive(false);
    }

    private void GameStateManager_OnStateChanged(object sender, System.EventArgs e) {
        if (GameStateManager.Instance.IsGamePlaying()) {
            pressSpaceText.gameObject.SetActive(true);
        }
    }

    private void GameInput_OnAction(object sender, System.EventArgs e) {
        if (GameStateManager.Instance.IsGamePlaying()) {
            pressSpaceText.gameObject.SetActive(false);
        }
    }

    private void ScoreManager_OnScoreChange(object sender, System.EventArgs e) {
        scoreText.text = "SCORE " + ScoreManager.Instance.currentScore;

    }

    private void Dome_OnLivesChange(object sender, System.EventArgs e) {
        livesText.text = "LIVES " + Dome.Instance.GetLives();
        slider.value = Dome.Instance.GetNormalizeLives();
    }

    private void GameInput_OnIncrease(object sender, System.EventArgs e) {
        if (Player.Instance.G <= Player.Instance.maxG) {
            if (Player.Instance.G==Player.Instance.maxG)
            {
                powerText.text = "Max";
            }
            else
            {
                powerText.text = "<" + (Player.Instance.G / 100).ToString()+">";
            }
        }
    }
    private void GameInput_OnDecrease(object sender, System.EventArgs e) {
        if (Player.Instance.G >= Player.Instance.minG) {
            if (Player.Instance.G==Player.Instance.minG)
            {
                powerText.text = "Min";
            }
            else
            {
                powerText.text = "<" + (Player.Instance.G / 100).ToString()+">";
            }
        }
    }
}
