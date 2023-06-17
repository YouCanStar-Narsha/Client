using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	public GameObject doNotTouchUI;
	public GameObject doNotTouchPanel;
	public GameObject stagePanel;

	public Transform startPanelPos;
	public Transform endPanelPos;
	public Vector3 stagePos;
	
	public bool isShow = false;

	private Vector3 currentPos;
	private Vector3 nomalPos;

	private void Awake()
	{
		doNotTouchUI.SetActive(false);
		doNotTouchPanel.SetActive(false);
		nomalPos = transform.position;
		stagePos = stagePanel.transform.position;
	}

	public void DownUI()
	{
		currentPos = startPanelPos.position;
		StopCoroutine("UICo");
		StartCoroutine("UICo");
	}

	public void UpUI()
	{
		currentPos = nomalPos;
		StopCoroutine("UICo");
		StartCoroutine("UICo");
	}

	private IEnumerator UICo()
	{
		RectTransform rectTransform = GetComponent<RectTransform>();
		Vector3 targetPos = currentPos;
		doNotTouchUI.SetActive(true);

		while (true)
		{
			rectTransform.position = Vector3.Lerp(rectTransform.position, targetPos, Time.deltaTime * 10);
			if(Vector3.Distance(rectTransform.position, targetPos) < 1)
			{
				rectTransform.position = targetPos;
				doNotTouchUI.SetActive(false);
				yield break;
			}

			yield return null;
		}
	}
}
