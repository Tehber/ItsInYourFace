using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Opciones : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject menu;
    public Slider slider;
    public AudioMixer musicMixer;
    void Start()
    {
        
    }
    void Update()
    {
    }
    public void OptionEnters()
    {
        optionsMenu.SetActive(true);
        menu.SetActive(false);
    }
    public void OptionExit()
    {
        optionsMenu.SetActive(false);
        menu.SetActive(true);
    }
    public void MusicChange()
    {
        musicMixer.SetFloat("MusicaVolumen", Mathf.Log10(slider.value) * 20);
    }
}
