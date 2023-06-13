using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputBehavior : MonoBehaviour
{
    [Tooltip("The behavior attached to the player that will spawn bullets.")]
    [SerializeField]
    private ProjectileSpawnerBehavior _gun;

    [Tooltip("The main camera in the scene.")]
    private Camera _mainCamera;

    [Tooltip("The button that appears on a game over that allows the player to return to the main menu.")]
    [SerializeField]
    private Button _returnButton;

    [Tooltip("The button that appears on a game over that tells the player how many enemies they beat.")]
    [SerializeField]
    private Text _enemiesDefeatedText;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        // The information of what the ray will hit.
        RaycastHit hitInfo;

        // Fire a ray.
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        // If it hit anything, tell the player's gun to look that way.
        if(Physics.Raycast(ray, out hitInfo))
            _gun.transform.LookAt(hitInfo.point);

        // When the player clicks or taps, tell their gun to fire.
        if (Input.GetMouseButtonDown(0))
            _gun.Fire();
    }

    public void Destroy()
    {
        OnDeath();
        Destroy(gameObject);
    }

    public void OnDeath()
    {
        // Set the return and enemies defeated text UI elements to active.
        _returnButton.gameObject.SetActive(true);
        _enemiesDefeatedText.gameObject.SetActive(true);
    }
}
