using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] protected GameObject popUpObject;
	protected UIController ui;

	private void Awake()
	{
		ui = FindObjectOfType<UIController>();
	}
	public virtual void EnablePopUp()
    {
        popUpObject.SetActive(true);
    }

    public virtual void DisablePopUp()
    {
        popUpObject.SetActive(false);
    }
}
