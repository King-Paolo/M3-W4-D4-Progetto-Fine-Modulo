using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Enemy enemyPreFab;
    [SerializeField] Enemy silverEnemyPreFab;
    [SerializeField] Enemy goldenEnemyPreFab;
    [SerializeField] GameObject spawnPointAssaultRifle;
    [SerializeField] GameObject spawnPointShotgun;
    [SerializeField] Gun assaultRiflePreFab;
    [SerializeField] Gun shotgunPreFab;
    [SerializeField] Bomb targetPoint;
    bool _waveStarted;
    bool _firstWaveIsSpawned;
    bool _secondWaveIsSpawned;
    bool _thirdWaveIsSpawned;
    bool _lastWaveIsSpawned;
    private int firsWave = 1;
    private int secondWave = 5;
    private int thirdWave = 17;
    private int lastWave = 30;
    private float _spawnTime;

    public void FirstWave()
    {
        for (int i = 0; i < firsWave; i++)
        {
            Instantiate(enemyPreFab, gameObject.transform);
            Instantiate(silverEnemyPreFab, gameObject.transform);
            Instantiate(goldenEnemyPreFab, gameObject.transform);
        }
        Debug.Log("ATTENTO! STANNO ARRIVANDO!");
    }
    public void SecondWave()
    {
        Instantiate(shotgunPreFab, spawnPointShotgun.transform.position, spawnPointShotgun.transform.rotation);
        for (int i = 0; i < secondWave; i++)
        {
            Instantiate(enemyPreFab, gameObject.transform);
            Instantiate(silverEnemyPreFab, gameObject.transform);
            Instantiate(goldenEnemyPreFab, gameObject.transform);
        }
        Debug.Log("Ne arrivano altri, resisti! Dovrebbe esserci uno Shotgun nel parco. Potrebbe tornarti utile!");
    }
    public void ThirdWave()
    {
        Instantiate(assaultRiflePreFab, spawnPointAssaultRifle.transform.position, spawnPointAssaultRifle.transform.rotation);
        for (int i = 0; i < thirdWave; i++)
        {
            Instantiate(enemyPreFab, gameObject.transform);
            Instantiate(silverEnemyPreFab, gameObject.transform);
            Instantiate(goldenEnemyPreFab, gameObject.transform);
        }
        Debug.Log("Ma quanti sono!? ATTENTO FRANK! Prendi il Fucile, nel parcheggio e falli fuori!");
    }
    public void LastWave()
    {
        Instantiate(targetPoint);
        for (int i = 0; i < lastWave; i++)
        {
            Instantiate(enemyPreFab, gameObject.transform);
            Instantiate(silverEnemyPreFab, gameObject.transform);
            Instantiate(goldenEnemyPreFab, gameObject.transform);
        }
        Debug.Log("CE NE SONO TROPPI!! VIENI IN FONDO ALLA STRADA, A DESTRA, SGANCEREMO UNA BOMBA!!");
    }
    public void SpawnWave()
    {
        if (Time.time - _spawnTime >= 3 && _firstWaveIsSpawned == false)
        {
            FirstWave();
            _firstWaveIsSpawned = true;
        }
        if (Time.time - _spawnTime >= 20 && _secondWaveIsSpawned == false)
        {
            SecondWave();
            _secondWaveIsSpawned = true;
        }
        if (Time.time - _spawnTime >= 50 && _thirdWaveIsSpawned == false)
        {
            ThirdWave();
            _thirdWaveIsSpawned = true;
        }
        if (Time.time - _spawnTime >= 80 && _lastWaveIsSpawned == false)
        {
            LastWave();
            _lastWaveIsSpawned = true;
        }
    }
    public void StartWave()
    {
        _waveStarted = true;
        _spawnTime = Time.time;
    }
    private void Update()
    {
        if (_waveStarted)
        {
            SpawnWave();
        }
    }
}

