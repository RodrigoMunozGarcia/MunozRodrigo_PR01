using UnityEngine;
using TMPro;


public class TimerController : MonoBehaviour
{

    [SerializeField] float tiempoInicial = 60f;

    [SerializeField] TMP_Text textoTemporizador;
    [SerializeField] GameObject panelDerrota;

    [SerializeField] BolaController controlBola;
    [SerializeField] Rigidbody rbBola;

    float tiempoRestante;
    bool partidaTerminada = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tiempoRestante = tiempoInicial;

        panelDerrota.SetActive(false);

        ActualizarTemporizador();
    }

    // Update is called once per frame
    void Update()
    {
        if (partidaTerminada)
            return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            PerderPartida();
        }

        ActualizarTemporizador();
    }

    void ActualizarTemporizador()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);

        textoTemporizador.text =
            string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void PerderPartida()
    {
        partidaTerminada = true;

        controlBola.enabled = false;

        rbBola.linearVelocity = Vector3.zero;
        rbBola.angularVelocity = Vector3.zero;

        panelDerrota.SetActive(true);
    }

}

