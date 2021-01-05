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
    public TextMeshProUGUI yellowCounter;

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
        UpdateYellowCounter(0);

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
        _blueBalls = _blueBalls + newValue;
        blueCounter.SetText(newValue.ToString("0"));
    }

    public void UpdateYellowCounter(int newValue)
    {
        _redBalls = _redBalls + newValue;
        yellowCounter.SetText(newValue.ToString("0"));
    }

    public void PickUpRed()
    {
        //_anim.Play("FPS_unequp");
        blueBall.SetActive(false);
        redBall.SetActive(true);
        noBall.SetActive(false);

        UpdateYellowCounter(1);
    }

    public void PickUpBlue()
    {
        //_anim.Play("FPS_unequp");
        blueBall.SetActive(true);
        redBall.SetActive(false);
        noBall.SetActive(false);

        UpdateBlueCounter(1);
    }

    public void PickUpNone()
    {
        //_anim.Play("FPS_unequp");
        blueBall.SetActive(false);
        redBall.SetActive(false);
        noBall.SetActive(true);
    }

}
