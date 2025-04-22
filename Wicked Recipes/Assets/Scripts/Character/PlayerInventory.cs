using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public bool tienePan = false;
    public bool tieneTomate = false;
    public bool tieneLlave = false;
    public bool llaveEspecialObtenida = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 🔒 Se mantiene entre escenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    public bool TieneTodosLosIngredientes()
    {
        return tienePan && tieneTomate;
    }

    public void RecolectarIngrediente(string ingrediente)
    {
        if (ingrediente == "Pan")
        {
            tienePan = true;
            Debug.Log("Recolectaste Pan");
        }
        else if (ingrediente == "Tomate")
        {
            tieneTomate = true;
            Debug.Log("Recolectaste Tomate");
        }
    }
}
