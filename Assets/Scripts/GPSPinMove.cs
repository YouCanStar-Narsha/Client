using UnityEngine;

// 유니티 에셋 NativeGPS의 스크립트 상속
public class GPSPinMove : NativeGPSUI
{
	// double 변수 2개가 있는 클래스 TwinsDouble을 이용하여 gps의 위도와 경도를 받아옴
	// 중심이 되는 gps 위도와 경도값
	[SerializeField] private TwinsDouble gpsPath = new TwinsDouble(128.5350104, 35.8223217);
	// gps 값 변경 시, 클라이언트의 맵핀이 이동하는 수치 조정값
	[SerializeField] private float gpsPointMargin = 100000;
	// 화면 오브젝트 캐싱
	[SerializeField] private Transform parentTranform;
	// 맵핀 오브젝트 캐싱
	[SerializeField] private GameObject pin;

	// 생성한 맵핀 오브젝트
	private RectTransform pinClone;

	protected override void Start()
	{
		base.Start();
		// 맵핀 오브젝트 생성 후 저장
		pinClone = Instantiate(pin, parentTranform).GetComponent<RectTransform>();
	}

	protected override void Update()
	{
		base.Update();
		/* NativeGPSPlugin.GetLongitude()로 위도, NativeGPSPlugin.GetLatitude()로 경도를 받아와 
		 * gpsPath 값을 빼서 gpsPath의 위도와 경도를 중심으로 만든 후
		 * gpsPointMargin을 곱하여 게임 내 좌표 이동값을 조정한다.
		 */
		pinClone.localPosition = new Vector3((float)((NativeGPSPlugin.GetLongitude() - gpsPath.x) * gpsPointMargin), (float)((NativeGPSPlugin.GetLatitude() - gpsPath.y) * gpsPointMargin));
	}
}
