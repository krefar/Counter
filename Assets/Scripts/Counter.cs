using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] float _interval = 0.5f;

    private int _current = 0;
    private bool _isRunning = false;
    private IEnumerator countRuotine;

    private void Start()
    {
        countRuotine = LogIncrement();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print($"Left mouse click");

            if (_isRunning)
            {
                _isRunning = false;
                StopCoroutine(countRuotine);
            }
            else
            {
                _isRunning = true;
                StartCoroutine(countRuotine);
            }
        }
    }

    private IEnumerator LogIncrement()
    {
        var wait = new WaitForSeconds(_interval);

        while (enabled)
        {
            print($"Counter:{_current++}");

            yield return wait;
        }
    }
}
