using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _score;

	private void OnEnable()
	{
		_bird.ScoreChanget += OnScoreChanged;
	}

	private void OnDisable()
	{
		_bird.ScoreChanget -= OnScoreChanged;
	}

	private void OnScoreChanged(int score)
	{
		_score.text = score.ToString();
	}
}
