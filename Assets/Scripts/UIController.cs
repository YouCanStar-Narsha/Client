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

	private void Awake()
	{
		doNotTouchUI.SetActive(false);
		doNotTouchPanel.SetActive(false);
	}}
