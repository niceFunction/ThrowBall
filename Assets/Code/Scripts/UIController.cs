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

        _animRed = redPickupAnim.GetComponent<Animation>();
        _animBlue = bluePickupAnim.GetComponent<Animation>();
    }

    void Update()
    {
        startTime -= Time.deltaTime;
        int intTimer = (int)startTime;
        UpdateTimer(intTimer);

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

}
