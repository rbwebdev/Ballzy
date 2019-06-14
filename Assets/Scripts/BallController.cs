using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {
    
    private int score;
    private float time;
    private AudioSource MyAudioSource;
    private bool finish = false;

    public float ballSpeed;
    public TMP_Text ScoreText;
    public TMP_Text TimeText;
    public TMP_Text EndText;
    public TMP_Text EndScoreText;
    public TMP_Text HightScoreText;
    public GameObject endMenuUI;
    public AudioClip GameOverSound;
    public AudioClip TimeOverSound;


    void Start()
    {
        Cursor.visible = false;
        score = 0;
        SetScoreText();
        Time.timeScale = 1f;
        HightScoreText.text = "HIGHT SCORE : " + PlayerPrefs.GetInt("HightScore",0).ToString();
        MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {

        float xSpeed = Input.GetAxis("Vertical");
        float ySpeed = Input.GetAxis("Horizontal");

        Rigidbody body = GetComponent<Rigidbody>();

        body.AddTorque(new Vector3(xSpeed, 0 , ySpeed) * ballSpeed * Time.deltaTime);

        time = 30 - (int)Time.timeSinceLevelLoad;
        TimeText.text = "Temps : " + time.ToString() + "s";
        if (time == 0 && !finish)
        {
            MyAudioSource.PlayOneShot(TimeOverSound);
            Finish("TIME OVER");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedBall")
        {
            score = score + 1;
            SetScoreText();
        }

        if (other.gameObject.tag == "BlueBall")
        {
            score = score + 5;
            SetScoreText();
        }

        if (other.gameObject.tag == "Respawn" && !finish)
        {
            MyAudioSource.PlayOneShot(GameOverSound);
            Finish("GAME OVER");
        }
    }

    void SetScoreText()
    {
        ScoreText.text = "Score : " + score.ToString();
    }

    void Finish(string text)
    {
        finish = true;
        Cursor.visible = true;
        if (score > PlayerPrefs.GetInt("HightScore"))
        {
            PlayerPrefs.SetInt("HightScore",score);
        }
        HightScoreText.text = "HIGHT SCORE : " + PlayerPrefs.GetInt("HightScore").ToString();
        EndText.text = text;
        EndScoreText.text = "SCORE : " + score.ToString();
        transform.position = new Vector3(200, 200, 200);
        //Time.timeScale = 0f;
        endMenuUI.SetActive(true);
    }
} 
