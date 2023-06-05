using UnityEngine;

// ����Ƽ ���� NativeGPS�� ��ũ��Ʈ ���
public class GPSPinMove : NativeGPSUI
{
	// double ���� 2���� �ִ� Ŭ���� TwinsDouble�� �̿��Ͽ� gps�� ������ �浵�� �޾ƿ�
	// �߽��� �Ǵ� gps ������ �浵��
	[SerializeField] private TwinsDouble gpsPath = new TwinsDouble(128.5350104, 35.8223217);
	// gps �� ���� ��, Ŭ���̾�Ʈ�� ������ �̵��ϴ� ��ġ ������
	[SerializeField] private float gpsPointMargin = 100000;
	// ȭ�� ������Ʈ ĳ��
	[SerializeField] private Transform parentTranform;
	// ���� ������Ʈ ĳ��
	[SerializeField] private GameObject pin;

	// ������ ���� ������Ʈ
	private RectTransform pinClone;

	protected override void Start()
	{
		base.Start();
		// ���� ������Ʈ ���� �� ����
		pinClone = Instantiate(pin, parentTranform).GetComponent<RectTransform>();
	}

	protected override void Update()
	{
		base.Update();
		/* NativeGPSPlugin.GetLongitude()�� ����, NativeGPSPlugin.GetLatitude()�� �浵�� �޾ƿ� 
		 * gpsPath ���� ���� gpsPath�� ������ �浵�� �߽����� ���� ��
		 * gpsPointMargin�� ���Ͽ� ���� �� ��ǥ �̵����� �����Ѵ�.
		 */
		pinClone.localPosition = new Vector3((float)((NativeGPSPlugin.GetLongitude() - gpsPath.x) * gpsPointMargin), (float)((NativeGPSPlugin.GetLatitude() - gpsPath.y) * gpsPointMargin));
	}
}
