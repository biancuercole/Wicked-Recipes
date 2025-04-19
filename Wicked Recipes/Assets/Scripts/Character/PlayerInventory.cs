using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool tienePan = false;
    public bool tieneTomate = false;

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
