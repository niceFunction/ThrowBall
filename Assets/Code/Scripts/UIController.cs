using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public float startTime = 500;

    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI blueCounter;
    public TextMeshProUGUI redCounter;

    public GameObject blueBall;
    public GameObject redBall;
    public GameObject noBall;
    public GameObject FPSarms;

    private Animation _anim;

    private int _redBalls = 0;
    private int _blueBalls = 0;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScore(0);
        UpdateBlueCounter(0);
        UpdateRedCounter(0);

        blueBall.SetActive(false);
        redBall.SetActive(false);
        noBall.SetActive(true);

        _anim = FPSarms.GetComponent<Animation>();
    }

    void Update()
    {
        startTime -= Time.deltaTime;
        int intTimer = (int)startTime;
        UpdateTimer(intTimer);

        if (_blueBalls == 0 && _redBalls == 0)
        {
            PickUpNone();
        }
        else if (_blueBalls == 0 && _redBalls != 0)
        {
            PickUpRed();
        }
        else if (_blueBalls != 0 && _redBalls == 0)
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
        score.SetText(newValue.ToString("0000"));
    }

    public void UpdateBlueCounter(int newValue)
    {
        _blueBalls = _blueBalls + (newValue);
        blueCounter.SetText(_blueBalls.ToString("0"));
    }

    public void UpdateRedCounter(int newValue)
    {
        _redBalls = _redBalls + (newValue);
        redCounter.SetText(_redBalls.ToString("0"));
    }

    public void PickUpRed()
    {
        //_anim.Play("FPS_unequp");
        blueBall.SetActive(false);
        redBall.SetActive(true);
        noBall.SetActive(false);
    }

    public void PickUpBlue()
    {
        //_anim.Play("FPS_unequp");
        blueBall.SetActive(true);
        redBall.SetActive(false);
        noBall.SetActive(false);
    }

    public void PickUpNone()
    {
        //_anim.Play("FPS_unequp");
        blueBall.SetActive(false);
        redBall.SetActive(false);
        noBall.SetActive(true);
    }

}
