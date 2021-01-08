using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public float startTime = 500;

    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI blueCounter;
    public TextMeshProUGUI redCounter;

    public GameObject blueBall;
    public GameObject redBall;
    public GameObject FPSarms;

    public GameObject endScreen;
    public GameObject pauseScreen;
    public TextMeshProUGUI endPoints;

    /* RED FIRST TIME ANIMATION */
    public GameObject redPickupAnim;
    private float _redPickupAnimTime = 1f;
    private bool _redPickupAnimActive;
    private Animation _animRed;

    /* BLUE FIRST TIME ANIMATION */
    public GameObject bluePickupAnim;
    private float _bluePickupAnimTime = 1f;
    private bool _bluePickupAnimActive;
    private Animation _animBlue;

    public int redBalls = 0;
    public int blueBalls = 0;
    public int highScore = 0;

    private bool _isPaused;
    private bool _isFinished;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateScore(0);
        UpdateBlueCounter(0);
        UpdateRedCounter(0);

        blueBall.SetActive(false);
        redBall.SetActive(false);
        endScreen.SetActive(false);
        pauseScreen.SetActive(false);

        _animRed = redPickupAnim.GetComponent<Animation>();
        _animBlue = bluePickupAnim.GetComponent<Animation>();
        //PauseGame();
    }

    void Update()
    {
        startTime -= Time.deltaTime;
        int intTimer = (int)startTime;
        UpdateTimer(intTimer);

        if (startTime <= 0)
        {
            startTime = 0;
            EndGame();
        }

        if (redBalls <= 0)
        {
            redBalls = 0;
            redBall.SetActive(false);
        }

        if (blueBalls <= 0)
        {
            blueBalls = 0;
            blueBall.SetActive(false);
        }

        if (blueBalls == 0 && redBalls != 0)
        {
            PickUpRed();
        }
        else if (blueBalls != 0 && redBalls == 0)
        {
            PickUpBlue();
        }
        if (_redPickupAnimActive)
        {
            _redPickupAnimTime -= Time.deltaTime;
            if (_redPickupAnimTime <= 0)
            {
                _redPickupAnimActive = false;
                _redPickupAnimTime = 1f;
                if (redBalls > 0) { 
                    redBall.SetActive(true);
                }
                redPickupAnim.SetActive(false);
            }
        }
        if (_bluePickupAnimActive)
        {
            _bluePickupAnimTime -= Time.deltaTime;
            if (_bluePickupAnimTime <= 0)
            {
                _bluePickupAnimActive = false;
                _bluePickupAnimTime = 1f;
                if (blueBalls > 0)
                {
                    blueBall.SetActive(true);
                }
                bluePickupAnim.SetActive(false);
            }
        }

    }

    public void UpdateTimer(int newValue)
    {
        timer.SetText(newValue.ToString("000"));
    }

    public void UpdateScore(int newValue)
    {
        highScore = highScore + (newValue);
        score.SetText(highScore.ToString("0000"));
    }

    public void UpdateBlueCounter(int newValue)
    {
        blueBalls = blueBalls + (newValue);
        blueCounter.SetText(blueBalls.ToString("0"));
    }

    public void UpdateRedCounter(int newValue)
    {
        redBalls = redBalls + (newValue);
        redCounter.SetText(redBalls.ToString("0"));
    }

    public void PickUpRed()
    {
        if (redBalls == 0) {
            redPickupAnim.SetActive(true);
            redBall.SetActive(false);
            _redPickupAnimActive = true;
            _animRed.Play("RedPickUpAnimation");
        }
    }

    public void PickUpBlue()
    {
        if (blueBalls == 0)
        {
            bluePickupAnim.SetActive(true);
            blueBall.SetActive(false);
            _bluePickupAnimActive = true;
            _animBlue.Play("BluePickUpAnimation");
        }
    }

    public void PickUpNone()
    {
        blueBall.SetActive(false);
        redBall.SetActive(false);
    }

    public void PauseGame()
    {
        if (!_isFinished)
        {
            if (_isPaused)
            {
                Time.timeScale = 1;
                _isPaused = false;
                AudioManager.Instance.bgm.Play();
                pauseScreen.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                AudioManager.Instance.bgm.Pause();
                pauseScreen.SetActive(true);
                _isPaused = true;
            }
        } else
        {
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            _isFinished = false;
        }
    }

    public void EndGame()
    {
        pauseScreen.SetActive(false);
        string pointsText = "Final score is " + highScore.ToString() + " points";
        endPoints.SetText(pointsText);
        endScreen.SetActive(true);
        _isFinished = true;
        Time.timeScale = 0;
        AudioManager.Instance.bgm.Stop();
        if (AudioManager.Instance.levelEndMusic.isPlaying == false)
        {
            AudioManager.Instance.levelEndMusic.Play();
        }

    }

}
