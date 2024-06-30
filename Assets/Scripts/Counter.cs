using UnityEngine;
using System.Collections;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private bool _counting = false;
    private float _count = 0;

    private void Start()
    {
        StartCoroutine(IncrementCounter());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _counting = _counting == false;
        }
    }

    IEnumerator IncrementCounter()
    {
        bool isRunning = true;

        while (isRunning)
        {
            yield return new WaitForSeconds(0.5f);

            if (_counting)
            {
                _count++;
                _text.text = "—чет: " + _count;
            }
        }
    }
}