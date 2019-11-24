using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
	// 操作キャラを設定
	public GameObject HeroCharacter;

	// カメラの最低高度を設定
	public float LowestHeight;


	private float OffsetHeight;		// カメラの高さのOffset
	private float CameraPositionZ;	// 固定値


	// Start is called before the first frame update
	void Start()
	{
		// カメラの高さのOffsetを取得
		OffsetHeight = transform.position.y - HeroCharacter.transform.position.y;

		// 固定値設定
		CameraPositionZ = -10.0f;

		// デバッグログ
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  OffsetHeight : " + OffsetHeight );
	}

	void LateUpdate()
	{
		// カメラの位置を取得
		Vector3 CameraPosition = transform.position;

		// 操作キャラの位置を取得
		Vector3 CharacterPosition = HeroCharacter.transform.position;

		// カメラと操作キャラの高さを取得
		float CameraHeight = CameraPosition.y;
		float CharacterHeight = CharacterPosition.y;

		// カメラの高さを計算
		float NewCameraHeight = CameraHeight;
		if ( CharacterHeight < CameraHeight + OffsetHeight )
		{
			// カメラの高さよりキャラが下にいる場合、基本的にはカメラの高さを変更しない
			if ( CharacterHeight < CameraHeight - OffsetHeight )
			{
				// 落下中の場合、キャラに追従する
				NewCameraHeight += CharacterHeight - ( CameraHeight - OffsetHeight );
			}
		}
		else
		{
			// ジャンプ中の場合、キャラに追従する
			NewCameraHeight += CharacterHeight - ( CameraHeight + OffsetHeight );
		}

		if ( NewCameraHeight < LowestHeight )
		{
			// 決められた高さより下には行かない
			NewCameraHeight = LowestHeight;
		}

		transform.position = new Vector3 (
			CharacterPosition.x
			, NewCameraHeight
			, CameraPositionZ
		);
	}
}
