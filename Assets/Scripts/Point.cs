using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
	[SerializeField] public string stageTitle = "Null";

    private CameraController camera;
    private UIController ui;

    private void Awake()
    {
        camera = Camera.main.GetComponent<CameraController>();
        ui = FindObjectOfType<UIController>();
    }

    private void OnMouseDown()
    {
        if (camera.targetTransform==transform)
        {
			Close();
		}
        else
        {
			Open();
		}
    }

    public void Close()
    {
		ui.isShow = false;
		camera.MoveToZero();
		ui.UpUI();
		StopCoroutine("ShowPanel");
		StartCoroutine("DownPanel");
	}

	public void Open()
	{
		ui.isShow = true;
		camera.MoveToPoint(transform);
		ui.DownUI();
		StopCoroutine("DownPanel");
		StartCoroutine("ShowPanel");
	}

	private IEnumerator ShowPanel()
	{
		ui.stagePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stageTitle + " Stage";
		RectTransform panel = ui.stagePanel.GetComponent<RectTransform>();
		ui.doNotTouchUI.SetActive(true);
		ui.doNotTouchPanel.SetActive(true);
		ui.stagePanel.SetActive(true);
		panel.position = ui.startPanelPos.position;
		Vector3 targetPos = ui.stagePos;

		while (true)
		{
			panel.position = Vector3.Lerp(panel.position, targetPos, Time.deltaTime * 10);
			if (Vector3.Distance(panel.position, targetPos) < 1)
			{
				ui.isShow = false;
				panel.position = targetPos;
				ui.doNotTouchPanel.SetActive(false);
				yield break;
			}

			yield return null;
		}
	}

	private IEnumerator DownPanel()
	{
		RectTransform panel = ui.stagePanel.GetComponent<RectTransform>();
		ui.doNotTouchUI.SetActive(false);
		ui.doNotTouchPanel.SetActive(true);
		panel.position = ui.stagePos;
		Vector3 targetPos = ui.startPanelPos.position;

		while (true)
		{
			panel.position = Vector3.Lerp(panel.position, targetPos, Time.deltaTime * 10);
			if (Vector3.Distance(panel.position, targetPos) < 1)
			{
				panel.position = targetPos;
				ui.stagePanel.SetActive(false);
				ui.doNotTouchPanel.SetActive(false);
				yield break;
			}
			if (ui.isShow)
			{
				yield break;
			}
			yield return null;
		}
	}
}
