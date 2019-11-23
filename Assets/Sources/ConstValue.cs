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
	public float RunForce;			// 左右の初速移動力
	public float JumpForce;			// ジャンプの上昇力


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
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  JumpForce : " + JumpForce );
	}
}
