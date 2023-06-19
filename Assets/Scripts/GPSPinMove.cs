using System.Collections.Generic;
using UnityEngine;

// ����Ƽ ���� NativeGPS�� ��ũ��Ʈ ���
public class GPSPinMove : NativeGPSUI
{
	// double ���� 2���� �ִ� Ŭ���� TwinsDouble�� �̿��Ͽ� gps�� ������ �浵�� �޾ƿ�
	// �߽��� �Ǵ� gps ������ �浵��
	[SerializeField] private TwinsDouble gpsPath = new TwinsDouble(128.4137578, 35.6627655);
	// gps �� ���� ��, Ŭ���̾�Ʈ�� ������ �̵��ϴ� ��ġ ������
	[SerializeField] private float gpsPointMargin = 100000;
	// ȭ�� ������Ʈ ĳ��
	[SerializeField] private Transform parentTranform;
	// ���� ������Ʈ ĳ��
	[SerializeField] private GameObject pin;

	[SerializeField] private GameObject mark;
	[SerializeField] private List<TwinsDouble> placePinPath = new List<TwinsDouble>();
	
	// ������ ���� ������Ʈ
	private Transform pinClone;

	protected override void Start()
	{
		base.Start();
		// ���� ������Ʈ ���� �� ����
		pinClone = Instantiate(pin, parentTranform).GetComponent<Transform>();

		foreach (TwinsDouble d in placePinPath)
		{
			Transform trans = Instantiate(mark, parentTranform).GetComponent<Transform>();
			trans.localPosition = new Vector3((float)((d.x - gpsPath.x) * gpsPointMargin), 0, (float)((d.y - gpsPath.y) * gpsPointMargin));
		}
	}

	protected override void Update()
	{
		base.Update();
		/* NativeGPSPlugin.GetLongitude()�� ����, NativeGPSPlugin.GetLatitude()�� �浵�� �޾ƿ� 
		 * gpsPath ���� ���� gpsPath�� ������ �浵�� �߽����� ���� ��
		 * gpsPointMargin�� ���Ͽ� ���� �� ��ǥ �̵����� �����Ѵ�.
		 */
		pinClone.localPosition = new Vector3((float)((NativeGPSPlugin.GetLongitude() - gpsPath.x) * gpsPointMargin), 0, (float)((NativeGPSPlugin.GetLatitude() - gpsPath.y) * gpsPointMargin));
	}
}
