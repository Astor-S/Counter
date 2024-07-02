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
    
    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counting = _counting == false;
            
            if (_counting)
            {
                _coroutine = StartCoroutine(Increment());
            }
            else
            {
                StopCoroutine(_coroutine);
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