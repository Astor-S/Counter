using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private bool _counting = false;
    
    private float _count = 0;
    private float _delay = 0.5f;
    
    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counting)
            {
                StopCoroutine(_coroutine);
                _counting = false;
            }
            else
            {
                _coroutine = StartCoroutine(Increment());
                _counting = true;
            }
        }
    }

    private IEnumerator Increment()
    {
        bool isRunning = true;

        while (isRunning)
        {
            yield return _wait;

            if (_counting)
            {
                _count++;
                _text.text = "—чет: " + _count;
            }
        }
    }
}