using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonTextBehavior : MonoBehaviour
{
    [SerializeField]
    private Text _textBox;

    [SerializeField]
    private string _upgradeText;

    [SerializeField]
    private float _cost;

    public float Cost
    {
        get { return _cost; }
        set { _cost = value; }
    }

    private void Update()
    {
        _cost = (Mathf.Round(_cost * 100)) / 100;
        _textBox.text = _upgradeText + " : $" + _cost; 
    }
}
