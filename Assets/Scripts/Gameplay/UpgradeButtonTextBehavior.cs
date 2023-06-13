using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonTextBehavior : MonoBehaviour
{
    [Tooltip("The text box being modified.")]
    [SerializeField]
    private Text _textBox;

    [Tooltip("The specific text for this upgrade.")]
    [SerializeField]
    private string _upgradeText;

    [Tooltip("The cost of the upgrade.")]
    [SerializeField]
    private float _cost;

    /// <summary>
    /// The cost of the upgrade.
    /// </summary>
    public float Cost { get { return _cost; } set { _cost = value; } }

    private void Update()
    {
        // Show the cost and the upgrade text.
        _cost = (Mathf.Round(_cost * 100)) / 100;
        _textBox.text = _upgradeText + " : $" + _cost; 
    }
}
