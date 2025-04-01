using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput controls;
    public Vector2 direction;
    public float velocity = 10f;
    public static int lives = 10;
    public GameObject PauseMenu;
    public List<GameObject> enemies;
    void FixedUpdate()
    {
        if (WeaponManagment.impulse == false)
        {
            //si los controles no están desactivados se leen las entradas del action maps para moverse y en base a eso se le añade una velocidad al jugador
            direction = controls.actions["Moverse"].ReadValue<Vector2>();
            this.GetComponent<Rigidbody2D>().MovePosition(this.transform.position+ new Vector3(direction.x, direction.y, 0).normalized * velocity * Time.fixedDeltaTime);
        }
        //si te quedas sin vidas mueres (provisional)
        if (lives == 0)
        {
            Debug.Log("muelto");
        }
        enemies.RemoveAll(item => item == null);
    }
    void OnPausar()
    {
        if (Time.timeScale == 0)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Unpause()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
