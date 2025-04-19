using UnityEngine;
using UnityEngine.UI;

public class CutMinigame : MonoBehaviour
{
    public GameObject circuloPrefab;
    public Transform[] posicionesSpawn;
    public GameObject popupMinijuego;

    public int totalCirculos = 5;
    public float tiempoVida = 5f;

    public void IniciarMinijuego()
    {
        Time.timeScale = 0;
        popupMinijuego.SetActive(true);

        for (int i = 0; i < totalCirculos; i++)
        {
            SpawnCirculo();
        }
    }

    void SpawnCirculo()
    {
        int index = Random.Range(0, posicionesSpawn.Length);
        GameObject circulo = Instantiate(circuloPrefab, posicionesSpawn[index].position, Quaternion.identity, popupMinijuego.transform);

        // Añade el evento de click para eliminar el círculo
        Button boton = circulo.GetComponent<Button>();
        if (boton != null)
        {
            boton.onClick.RemoveAllListeners(); // Limpia por si acaso
            boton.onClick.AddListener(() =>
            {
                Destroy(circulo);
            });
        }

        StartCoroutine(DestruirCirculo(circulo));
    }

    System.Collections.IEnumerator DestruirCirculo(GameObject obj)
    {
        yield return new WaitForSecondsRealtime(tiempoVida);
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    public void FinalizarMinijuego()
    {
        popupMinijuego.SetActive(false);
        Time.timeScale = 1;
    }
}
