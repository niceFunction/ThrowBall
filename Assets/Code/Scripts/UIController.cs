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

    private Animation _anim;

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

        _anim = FPSarms.GetComponent<Animation>();
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
        //_anim.Play("FPS_unequp");
        redBall.SetActive(true);
    }

    public void PickUpBlue()
    {
        //_anim.Play("FPS_unequp");
        blueBall.SetActive(true);
    }

    public void PickUpNone()
    {
        //_anim.Play("FPS_unequp");
        blueBall.SetActive(false);
        redBall.SetActive(false);
    }

}
