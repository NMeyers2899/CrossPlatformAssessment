using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatTextBehavior : MonoBehaviour
{
    [Tooltip("The text that will be modified.")]
    [SerializeField]
    private Text _text;

    [Tooltip("The preface to the stat.")]
    [SerializeField]
    private string _preface;

    [Tooltip("The number that represents the stat itself.")]
    [SerializeField]
    private float _stat;

    /// <summary>
    /// The number that represents the stat itself.
    /// </summary>
    public float Stat { get { return _stat; }  set { _stat = value; } }

    // Update is called once per frame
    void Update()
    {
        // If the stat is less than zero, set it to zero.
        if (_stat < 0)
            _stat = 0;

        // Set the text to be the preface followed by the actual stat itself.
        _text.text = _preface + " : " + _stat;
    }
}
