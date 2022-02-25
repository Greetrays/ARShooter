using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Spawner _spawner;

    private int _currentScore;

    private void OnEnable()
    {
        _spawner.DiedEnemy += OnDiedEnemy;
    }

    private void Start()
    {
        _currentScore = 0;
        _score.text = _currentScore.ToString();
    }

    private void OnDisable()
    {
        _spawner.DiedEnemy -= OnDiedEnemy;
    }

    private void OnDiedEnemy(int reward)
    {
        _currentScore += reward;
        Debug.Log(reward);
        _score.text = _currentScore.ToString();
    }
}
