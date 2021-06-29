using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private Bird _bird;
	[SerializeField] private Generater _generater;
	[SerializeField] private StartScreen _startScreen;
	[SerializeField] private GameOverScreen _gameOverScreen;	

	private void OnEnable()
	{
		_startScreen.PlayButtonClick += OnPlayButtonClick;
		_gameOverScreen.RestartButtonClick += OnRestartButtonClick;
		_bird.GameOver += OnGameOver;
	}

	private void OnDisable()
	{
		_startScreen.PlayButtonClick -= OnPlayButtonClick;
		_gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
		_bird.GameOver -= OnGameOver;
	}

	private void Start()
	{
		Time.timeScale = 0;
		_startScreen.Open();
		_gameOverScreen.Close();
	}

	private void OnPlayButtonClick()
	{
		_startScreen.Close();
		StartGame();
	}

	private void OnRestartButtonClick()
	{
		_gameOverScreen.Close();
		_generater.ResetPoll();
		StartGame();
	}

	private void StartGame()
	{
		Time.timeScale = 1;
		_bird.ResetPlayer();
	}

	public void OnGameOver()
	{
		Time.timeScale = 0;
		_gameOverScreen.Open();
	}
}
