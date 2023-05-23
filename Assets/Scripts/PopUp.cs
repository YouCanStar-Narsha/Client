using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] private GameObject popUpObject;

    public void EnablePopUp()
    {
        popUpObject.SetActive(true);
    }

    public void DisablePopUp()
    {
        popUpObject.SetActive(false);
    }
}
