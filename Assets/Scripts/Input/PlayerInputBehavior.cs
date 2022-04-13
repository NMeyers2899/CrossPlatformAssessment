using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputBehavior : MonoBehaviour
{
    /// <summary>
    /// The behavior attached to the player that will spawn bullets.
    /// </summary>
    [SerializeField]
    private ProjectileSpawnerBehavior _gun;

    /// <summary>
    /// The main camera for the scene.
    /// </summary>
    [SerializeField]
    private Camera _mainCamera;

    [SerializeField]
    private Button _returnButton;

    private void Update()
    {
        // The information of what the ray will hit.
        RaycastHit hitInfo;

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hitInfo))
            _gun.transform.LookAt(hitInfo.point);

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
        _returnButton.gameObject.SetActive(true);
    }
}
