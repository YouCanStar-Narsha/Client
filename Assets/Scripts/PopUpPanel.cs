using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPanel : PopUp
{

	public override void EnablePopUp()
	{
		ui.DownUI();
		StartCoroutine("ShowPanel");
	}

	public override void DisablePopUp()
	{
		ui.UpUI();
		StartCoroutine("DownPanel");
	}

	private IEnumerator ShowPanel()
	{
		RectTransform panel = popUpObject.GetComponent<RectTransform>();
		ui.doNotTouchUI.SetActive(true);
		ui.doNotTouchPanel.SetActive(true);
		popUpObject.SetActive(true);
		panel.position = ui.startPanelPos.position;
		Vector3 targetPos = ui.endPanelPos.position;

		while (true)
		{
			panel.position = Vector3.Lerp(panel.position, targetPos, Time.deltaTime * 10);
			if (Vector3.Distance(panel.position, targetPos) < 1)
			{
				panel.position = targetPos;
				ui.doNotTouchPanel.SetActive(false);
				yield break;
			}

			yield return null;
		}
	}
	private IEnumerator DownPanel()
	{
		ui.doNotTouchUI.SetActive(false);
		ui.doNotTouchPanel.SetActive(true);
		RectTransform panel = popUpObject.GetComponent<RectTransform>();
		panel.position = ui.endPanelPos.position;
		Vector3 targetPos = ui.startPanelPos.position;

		while (true)
		{
			panel.position = Vector3.Lerp(panel.position, targetPos, Time.deltaTime * 10);
			if (Vector3.Distance(panel.position, targetPos) < 1)
			{
				panel.position = targetPos;
				popUpObject.SetActive(false);
				ui.doNotTouchPanel.SetActive(false);
				yield break;
			}

			yield return null;
		}
	}
}
