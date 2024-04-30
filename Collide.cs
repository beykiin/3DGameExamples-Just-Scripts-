using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private int health = 3;
    [SerializeField] GameObject[] _healthUI;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _fadePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sphere"))
        {
            health--;
            _healthUI[health].gameObject.SetActive(false);
            if (health==0)
            {
                _gameOver.SetActive(true);
                _fadePanel.SetActive(true);
                StartCoroutine(Fade());
            }
        }
        if (other.gameObject.CompareTag("UI"))
        {
            var a = other.gameObject.transform.GetChild(0).gameObject;
            a.SetActive(true);
            Debug.Log("UI Activated");
        
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("UI"))
        {
            var a = other.gameObject.transform.GetChild(0).gameObject;
            a.SetActive(false);
            Debug.Log("UI Deactivated");

        }
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1.9f);
        Time.timeScale = 0;
    }
}
