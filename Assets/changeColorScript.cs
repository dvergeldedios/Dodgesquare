using UnityEngine;
using TMPro;

public class FadingText : MonoBehaviour
{
    private TextMeshProUGUI _textElement;
    private Color _color1;
    private Color _color2;
    private float _speed;
    private float _t;

    public FadingText()
    {
        this._color1 = Color.red;
        this._color2 = new Color(1f, 0.5f, 0f); // Orange
        this._speed = 1f; // <-- speed of fade
    }

    public void Awake()
    {
        _textElement = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        if (_textElement != null)
        {
            // Actual Transition
            _t = Mathf.PingPong(Time.time * _speed, 1);
            _textElement.color = Color.Lerp(_color1, _color2, _t);
        }
    }
}
