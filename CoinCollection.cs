using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CoinRand;
using System.Linq;
using System;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    private CoinInst randomizer;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private TMP_Text _text;
    private int count=0;
    private AudioSource click;
    private int totalSpawnPoints;
    int y;
    private void Start()
    {
        click= GetComponent<AudioSource>();
        randomizer = _gameObject.GetComponent(typeof(CoinInst)) as CoinInst;
        totalSpawnPoints = randomizer.spawnPoints.Count();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("para"))
        {
            //Destroy(other.gameObject);
            count++;
            _text.text = count.ToString();
            other.gameObject.SetActive(false);
            click.Play();
            StartCoroutine(Spawn(other.gameObject));
        }
    }

    IEnumerator Spawn(GameObject gameObject)
    {
        int x = randomizer.spawnPoints.IndexOf(gameObject.transform.parent.transform);
        
        randomizer.randomValues.Remove(x);
        while (randomizer.randomValues.Count < Math.Ceiling(totalSpawnPoints/2.0f))
        {
            y = randomizer.r.Next(0, randomizer.spawnPoints.Count - 1);
            randomizer.randomValues.Add(y);
        }
        yield return new WaitForSeconds(3);
        
        gameObject.transform.position = randomizer.spawnPoints[y].transform.position;
        gameObject.SetActive(true);
    }
}
