using System.Collections;
using UnityEngine;

public class DialogoSecuencia : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lineasDeDialogo;

    public bool iniciarAlComenzar = true;

    private void Start()
    {
        if (iniciarAlComenzar)
        {
            IniciarDialogo();
        }
    }

    public void IniciarDialogo()
    {
        StartCoroutine(MostrarDialogoSecuencia());
    }

    IEnumerator MostrarDialogoSecuencia()
    {
        foreach (string linea in lineasDeDialogo)
        {
            DialogoUI.Instance.EscribirTexto(linea, 0.03f);

            // Esperar a que el jugador presione una tecla o haga clic
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));

            // Esperar a que suelte para evitar que pase varias líneas con un solo toque
            yield return new WaitUntil(() => !Input.GetKey(KeyCode.Space) && !Input.GetMouseButton(0));
        }

        DialogoUI.Instance.OcultarDialogo(); // Si tu sistema tiene esto
    }
}
