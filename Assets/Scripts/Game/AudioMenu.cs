using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] private GameObject volumenMenu;


    private static AudioMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ToggleVolumenMenu()
    {

        volumenMenu.SetActive(!volumenMenu.activeSelf);


    }
}
