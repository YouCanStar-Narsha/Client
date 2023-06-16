using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	public GameObject doNotTouchUI;
	public GameObject doNotTouchPanel;

	public Transform startPanelPos;
	public Transform endPanelPos;

	private Vector3 currentPos;
	private Vector3 nomalPos;

	private void Awake()
	{
		doNotTouchUI.SetActive(false);
		doNotTouchPanel.SetActive(false);
	}

	private void Update()
	{
		
	}

	public void DownUI()
	{

	}

	public void UpUI()
	{

	}
}
