using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Fields

    [Header("Audio")]
    public AudioSource Music;
    public bool StartPlaying = false;

    [Header("Score")]
    public Slider HypeMeter;
    public int currentScore;
    public int scorePerNote = 100;
    public Text scoreTxt;

    public int Intervals = 1000;

    [Header("Audio")]
    // SFX
    public string NoteHitSfx;
    public string NoteMissedSfx;

    [Header("Feedback")]
    // Add
    private bool _addPPoints;
    private bool _minusPoints;

    // Font colour
    public Color normalTextColour;
    public Color redTextColour;
    public Color greenTextColour;

    // Font size
    private int normalSize = 50;
    private int enlarged = 60;

    [Header("Screens")]
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject gameScreen;
    public GameObject uiScreen;
    public GameObject screenDisappear;

    private string sceneName = "Main Menu";

    #endregion

    #region Initializations

    private void Start()
    {
        scoreTxt.text = "Score: 0";
        currentScore = 0;

        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        screenDisappear.SetActive(true);
    }

    #endregion

    #region Updates

    private void Update()
    {
        HypeMeter.value = currentScore;

        if (StartPlaying == false)
        {
            Time.timeScale = 0;
        }
        else if(StartPlaying == true)
        {
            Time.timeScale = 1;
        }

        if (!StartPlaying)
        {
            if (Input.anyKeyDown)
            {
                StartPlaying = true;

                Music.Play();
                screenDisappear.SetActive(false);
            }
        }

        // Normal state
        if (!_addPPoints && !_minusPoints)
        {
            scoreTxt.color = normalTextColour;
            scoreTxt.fontSize = normalSize;
        }
        // Minus points
        else if (!_addPPoints && _minusPoints)
        {
            scoreTxt.color = redTextColour;
            scoreTxt.fontSize = normalSize;
        }
        // Add points
        else if (_addPPoints && !_minusPoints)
        {
            scoreTxt.color = greenTextColour;
            scoreTxt.fontSize = enlarged;
        }

        scoreTxt.text = "Score: " + currentScore;

        // Lose
        if (currentScore <= -3000)
        {
            loseScreen.SetActive(true);
            gameScreen.SetActive(false);
            uiScreen.SetActive(false);
        }
        
        // Win
        if (currentScore >= 3000)
        {
            winScreen.SetActive(true);
            gameScreen.SetActive(false);
            uiScreen.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("End Game");

            loadScene();
        }
    }

    private void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    #endregion

    #region Notes

    #region Note Hit

    public void NoteHit()
    {
        // Debug.Log("Hit On Time");

        StartCoroutine(HitFont());

        currentScore += scorePerNote;
        scoreTxt.text = "Score: " + currentScore;

        if (currentScore % Intervals == 0)
        {
            HandleScoreInterval();
        }

        // Play Note Hit SFX
        GlobalAudioPlayer.PlaySFX(NoteHitSfx);
    }

    public IEnumerator HitFont()
    {
        _addPPoints = true;
        _minusPoints = false;

        yield return new WaitForSeconds(0.5f);

        _addPPoints = false;
        _minusPoints = false;
    }

    #endregion

    #region Note Missed

    public void NoteMissed()
    {
        // Debug.Log("Missed Note");

        StartCoroutine(MissedFont());

        currentScore -= 150;

        // Play Note Missed SFX
        GlobalAudioPlayer.PlaySFX(NoteMissedSfx);
    }

    public IEnumerator MissedFont()
    {
        _addPPoints = false;
        _minusPoints = true;

        yield return new WaitForSeconds(0.5f);

        _addPPoints = false; ;
        _minusPoints = false;
    }
    #endregion

    #region Score Interval

    private void HandleScoreInterval()
    {

        //StartPlaying = false;
        // Update the score text
        //scoreTxt.text = "Score: " + currentScore;

        // Provide feedback to the player
        //Debug.Log("Special Score Interval Reached! New Score: " + currentScore);

        // You could also play a sound effect or show a visual cue here

        //So here it will come the choices where you have to choose a line
    }
    #endregion

    #endregion
}
