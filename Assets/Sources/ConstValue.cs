using System.Collections;
using System.Collections.Generic;
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
		Debug.Log ( "ConstValue-Class Start-Method  MoveRightKey : " + MoveRightKey );
		Debug.Log ( "ConstValue-Class Start-Method  MoveLeftKey : " + MoveLeftKey );
		Debug.Log ( "ConstValue-Class Start-Method  MoveUpKey : " + MoveUpKey );
		Debug.Log ( "ConstValue-Class Start-Method  MoveDownKey : " + MoveDownKey );
		Debug.Log ( "ConstValue-Class Start-Method  MoveJumpKey : " + MoveJumpKey );
		Debug.Log ( "ConstValue-Class Start-Method  RunForce : " + RunForce );
		Debug.Log ( "ConstValue-Class Start-Method  JumpForce : " + JumpForce );
	}
}
