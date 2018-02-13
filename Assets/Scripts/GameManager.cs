using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public GameObject countDown;
	public GameObject countDownWall;
	public GameObject gameOverScreen;
	public GameObject startScreen;
	public GameObject pauseScreen;
	public GameObject slider;
	public GameObject startPos;
	public GameObject timerObject;
	
	public TextMeshProUGUI winMessage;
	public TextMeshProUGUI countDownText;
	public TextMeshProUGUI timer;

	public UpperPlayerUserController upperPlayer;
	public LowerPlayerUserControl lowerPlayer;

	private bool gameOver;
	private bool restart;
	private bool isGamePaused;
	private bool isGameStarted;
	private bool isCountDownStarted;

	public Slider upperSlider;
	public Slider lowerSlider;
	public float endPos;
	public float countDownTimer;

	public int minutes = 0;
    public int seconds = 0;
	private float m_leftTime;

	Scene currentScene;
	
	// Use this for initialization
	void Start () 
	{
		currentScene = SceneManager.GetActiveScene();

		isGameStarted = false;
		gameOver = false;
		restart = false;

		startScreen.SetActive(true);
		pauseScreen.SetActive(isGamePaused);
		gameOverScreen.SetActive(false);		

		upperPlayer = FindObjectOfType<UpperPlayerUserController>();
		lowerPlayer = FindObjectOfType<LowerPlayerUserControl>();

		slider.SetActive(false);
		upperSlider.minValue = startPos.transform.position.x;
		upperSlider.maxValue = endPos;
		lowerSlider.minValue = startPos.transform.position.x;
		lowerSlider.maxValue = endPos;

		countDownText.text = "5";
		countDownTimer = 5.0f;
		countDown.SetActive(false);
		m_leftTime = GetInitialTime();
		timerObject.SetActive(false);				
	}

	private void input()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			isGamePaused = !isGamePaused;
			pauseScreen.SetActive(isGamePaused);
			slider.SetActive(false);		
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameOver)
		{
			Time.timeScale = 0f;
		}
		else
		{
			if(isGamePaused || !isGameStarted)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = 1f;
			}
		}
		
		lowerSlider.value = lowerPlayer.transform.position.x;
		upperSlider.value = upperPlayer.transform.position.x;

		if(isCountDownStarted)
		{
			countDownTimer -= Time.deltaTime;
			if(countDownTimer < 4)
				countDownText.text = "4";
			if(countDownTimer < 3)
				countDownText.text = "3";
			if(countDownTimer < 2)
				countDownText.text = "2";
			if(countDownTimer < 1)
				countDownText.text = "1";
			if(countDownTimer < 0)
			{
				countDownText.text = "GO";
				countDownWall.SetActive(false);
			}
			if(countDownTimer < -1)
			{
				countDownText.text = "";				
			}
		}
		
		if(upperSlider.value >= upperSlider.maxValue)
		{			
			winningScreen("BLUE");
		}

		if(lowerSlider.value >= lowerSlider.maxValue)
		{
			winningScreen("RED");
		}

		if(m_leftTime > 0f && isGameStarted && countDownTimer < 0)
		{
			m_leftTime -= Time.deltaTime;
			minutes = GetLeftMinutes();
			seconds = GetLeftSeconds();

			if(m_leftTime > 0f)
			{
				timer.text = "Time: " + minutes + ":" + seconds.ToString("00");
			}
			else
			{
				timer.text = "Time: " + "0:00";		
				if(upperPlayer.getX() > lowerPlayer.getX())
				{
					winningScreen("BLUE");
				}
				else 
				{
					winningScreen("RED");
				}
			}
		}

		input();
	}

	public void winningScreen(string player)
	{		
		winMessage.text = "CONGRATULATIONS " + player + "! \n YOU WON!!!";
		gameOverScreen.SetActive(true);	
		gameOver = true;
	}

	public void StartGame()
	{
		startScreen.SetActive(false);
		countDown.SetActive(true);
		isGameStarted = true;
		isCountDownStarted = true;
		slider.SetActive(true);
		timerObject.SetActive(true);
	}

	public void ResumeGame()
	{
		pauseScreen.SetActive(false);
		slider.SetActive(true);
		isGamePaused = false;		
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(currentScene.name);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	private float GetInitialTime()
	{
		return minutes * 60f + seconds;
	}
 
     private int GetLeftMinutes()
     {
         return Mathf.FloorToInt(m_leftTime / 60f);
     }
 
     private int GetLeftSeconds()
     {
         return Mathf.FloorToInt(m_leftTime % 60f);
     }
}