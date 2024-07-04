using System.Collections;
using TMPro;
using UnityEngine;

public class MessageDisplayer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private TMP_Text _text;

    private Coroutine _previousCoroutine;

    public void DisplayInteractionZoneEntered(string text) => _text.text = text;
    public void DisplayInteractionZoneExit(string text) => _text.text = text;

    public void DisplayInteractionHappened(string text)
    {
        if (_previousCoroutine != null)
            StopCoroutine(_previousCoroutine);

        _previousCoroutine = StartCoroutine(DisplayRoutine(text));
    }

    private IEnumerator DisplayRoutine(string text)
    {
        _text.text = text;
        yield return new WaitForSeconds(_duration);
        _text.text = string.Empty;
    }
}
