using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private Player _player;
    [SerializeField] private int _spawnRadius;
    [SerializeField] private float _spawnSecondsDelay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            var obj = Instantiate(_template, _player.transform.position + GetShperePosition(), Quaternion.identity);
            Vector3 lookRotation = _player.transform.position - obj.transform.position;
            obj.transform.rotation = Quaternion.LookRotation(lookRotation);
            yield return new WaitForSeconds(_spawnSecondsDelay);
        }
    }

    private Vector3 GetShperePosition()
    {
        return Random.insideUnitSphere * _spawnRadius;
    }
}
