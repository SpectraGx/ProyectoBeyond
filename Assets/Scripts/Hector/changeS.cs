using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeS : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject botonPausa;
    // Start is called before the first frame update
    public void LoadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }


    public void pausa()
    {
        Time.timeScale = 0;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void despausa()
    {
        menuPausa.SetActive(false);
        botonPausa.SetActive(true);
        Time.timeScale = 1;
    }
}