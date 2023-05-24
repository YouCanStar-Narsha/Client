using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] protected GameObject popUpObject;

    public virtual void EnablePopUp()
    {
        popUpObject.SetActive(true);
    }

    public virtual void DisablePopUp()
    {
        popUpObject.SetActive(false);
    }
}
