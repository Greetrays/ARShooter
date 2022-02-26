using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private Player _player;
    [SerializeField] private int _spawnRadius;
    [SerializeField] private float _spawnSecondsDelay;

    public event UnityAction<int> DiedEnemy;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            var newEnemy = Instantiate(_enemys[Random.Range(0, _enemys.Length)], _player.transform.position + GetShperePosition(), Quaternion.identity);
            Vector3 lookRotation = _player.transform.position - newEnemy.transform.position;
            newEnemy.transform.rotation = Quaternion.LookRotation(lookRotation);
            newEnemy.Died += OnDied;
            newEnemy.TargetInit(_player);
            yield return new WaitForSeconds(_spawnSecondsDelay);
        }
    }

    private void OnDied(int reward, Enemy enemy)
    {
        DiedEnemy?.Invoke(reward);
        enemy.Died -= OnDied;
    }

    private Vector3 GetShperePosition()
    {
        Vector3 distanceFromPlayer = Vector3.one * 3;
        return distanceFromPlayer + Random.insideUnitSphere * _spawnRadius;
    }
}
