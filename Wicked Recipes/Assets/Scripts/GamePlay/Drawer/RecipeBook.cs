using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public GameObject popupRecetario; // asignás el GameObject del popup

    void OnMouseDown()
    {
        if (popupRecetario != null)
        {
            popupRecetario.SetActive(true);
        }
    }

    public void CloseBook() {
        popupRecetario.SetActive(false);
    }
}
