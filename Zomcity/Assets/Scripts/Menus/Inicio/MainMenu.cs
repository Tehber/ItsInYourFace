using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject news;
    //cambia la escena a la del juego
    public void Play() 
    {
        SceneManager.LoadScene(1);
    }
    //vuelve al main menu
    public void Back()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
        news.SetActive(false);
    }
    //lleva a los creditos
    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
    //lleva a las noticias
    public void News()
    {
        news.SetActive(true);
        mainMenu.SetActive(false);
    }
    //quita el juego
    public void Quit()
    {
        Application.Quit();
    }
}
