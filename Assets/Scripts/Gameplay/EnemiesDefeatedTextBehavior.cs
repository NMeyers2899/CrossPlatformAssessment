using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesDefeatedTextBehavior : MonoBehaviour
{
    [SerializeField]
    private Text _enemiesDefeatedText;

    // Update is called once per frame
    void Update()
    {
        _enemiesDefeatedText.text = "Enemies Defeated : " + GameManagerBehavior.EnemiesDefeated;
    }
}
