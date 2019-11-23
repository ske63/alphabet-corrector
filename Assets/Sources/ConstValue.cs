using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


// 定数クラス
public class ConstValue : MonoBehaviour
{
	// 移動系
	public KeyCode MoveRightKey;	// 右移動
	public KeyCode MoveLeftKey;		// 左移動
	public KeyCode MoveUpKey;		// 上移動
	public KeyCode MoveDownKey;		// 下移動
	public KeyCode MoveJumpKey;		// ジャンプ

	// 移動値系
	public float RunForce;							// 左右の初速移動力
	public float RunSpeed;							// 左右の移動速度
	public float RunThreshold;						// 速度切替判定のためのしきい値
	public float InertiaAttenuationValueAtStop;		// 停止時の慣性の減衰値  1より小さくすると逆に加速するので注意
	public float JumpForce;							// ジャンプの上昇力
	public float JumpThreshold;						// ジャンプ中か判定するためのしきい値
	public int TimesJumpableInAir;					// 空中でジャンプできる回数


	// Start is called before the first frame update
	void Start()
	{
		// デバッグログ
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  MoveRightKey : " + MoveRightKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  MoveLeftKey : " + MoveLeftKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  MoveUpKey : " + MoveUpKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  MoveDownKey : " + MoveDownKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  MoveJumpKey : " + MoveJumpKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  RunForce : " + RunForce );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  RunSpeed : " + RunSpeed );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  RunThreshold : " + RunThreshold );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  InertiaAttenuationValueAtStop : " + InertiaAttenuationValueAtStop );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  JumpForce : " + JumpForce );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  JumpThreshold : " + JumpThreshold );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  TimesJumpableInAir : " + TimesJumpableInAir );
	}
}
