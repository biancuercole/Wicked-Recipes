using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public bool tieneGusanos = false;
    public bool tieneMasa = false;
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
        return tieneGusanos && tieneMasa;
    }

    public void RecolectarIngrediente(string ingrediente)
    {
        if (ingrediente == "Gusano")
        {
            tieneGusanos = true;
            Debug.Log("Recolectaste Pan");
        }
        else if (ingrediente == "Masa")
        {
            tieneMasa = true;
            Debug.Log("Recolectaste Tomate");
        }
    }
}
