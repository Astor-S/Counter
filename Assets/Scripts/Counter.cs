using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;

    private bool _counting = false;
    private float _count = 0;

    public void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Start()
    {
        StartCoroutine(Increment());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counting = _counting == false;
        }
    }

    private IEnumerator Increment()
    {
        bool isRunning = true;
        
        float frequencySecond = 0.5f;

        while (isRunning)
        {
            yield return new WaitForSeconds(frequencySecond);

            if (_counting)
            {
                _count++;
                _text.text = "—чет: " + _count;
            }
        }
    }
}