using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPanel : PopUp
{
	[SerializeField] private float showTime = 0.5f;
	private UIController ui;

	private void Awake()
	{
		ui = FindObjectOfType<UIController>();
	}

	public override void EnablePopUp()
	{
		StartCoroutine("ShowPanel");
	}

	public override void DisablePopUp()
	{
		StartCoroutine("DownPanel");
	}

	private IEnumerator ShowPanel()
	{
		RectTransform panel = popUpObject.GetComponent<RectTransform>();
		ui.doNotTouchUI.SetActive(true);
		ui.doNotTouchPanel.SetActive(true);
		popUpObject.SetActive(true);
		panel.position = ui.startPanelPos.position;
		float time = 0;
		float t = time / showTime;
		while (time < showTime)
		{
			time += Time.deltaTime;
			t = time / showTime;
			t = Mathf.Sin(t * Mathf.PI * 0.51f);
			panel.position = Vector3.Lerp(ui.startPanelPos.position, ui.endPanelPos.position, t);
			yield return null;
		}
		ui.doNotTouchPanel.SetActive(false);
	}
	private IEnumerator DownPanel()
	{
		ui.doNotTouchUI.SetActive(false);
		ui.doNotTouchPanel.SetActive(true);
		RectTransform panel = popUpObject.GetComponent<RectTransform>();
		panel.position = ui.endPanelPos.position;
		float time = 0;
		float t = time / showTime;
		while (time < showTime)
		{
			time += Time.deltaTime;
			t = time / showTime;
			t = Mathf.Sin(t * Mathf.PI * 0.51f);
			panel.position = Vector3.Lerp(ui.endPanelPos.position, ui.startPanelPos.position, t);
			yield return null;
		}
		popUpObject.SetActive(false);
		ui.doNotTouchPanel.SetActive(false);
	}
}
