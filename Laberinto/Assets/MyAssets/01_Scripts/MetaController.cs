using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MetaController : MonoBehaviour
{

    [SerializeField] GameObject pantallaVictoria;
    [SerializeField] float tiempoEspera = 3f;

    bool nivelCompletado = false;
  
    private void OnTriggerEnter(Collider other)
    {
        if (nivelCompletado) return;

        if (other.CompareTag("Player"))
        {
            nivelCompletado = true;

            pantallaVictoria.SetActive(true);

            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(tiempoEspera);

        SceneManager.LoadScene(0);
    }
}
