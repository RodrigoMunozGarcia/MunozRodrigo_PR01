using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene("Laberinto");
    }
}
