using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 定数クラス
public class ConstValue : MonoBehaviour
{
	// 移動系
	public KeyCode MoveRight;	// 右移動
	public KeyCode MoveLeft;	// 左移動
	public KeyCode MoveUp;		// 上移動
	public KeyCode MoveDown;	// 下移動
	public KeyCode MoveJump;	// ジャンプ
	
	// 移動値系
	public float LeftRightMoveValue;	// 左右の移動値
	public float JumpUpwardValue;		// ジャンプの上昇値

	// Start is called before the first frame update
	void Start()
	{
		// デバッグログ
		Debug.Log ( "ConstValue-Class Start-Method  MoveRight : " + MoveRight );
		Debug.Log ( "ConstValue-Class Start-Method  MoveLeft : " + MoveLeft );
		Debug.Log ( "ConstValue-Class Start-Method  MoveUp : " + MoveUp );
		Debug.Log ( "ConstValue-Class Start-Method  MoveDown : " + MoveDown );
		Debug.Log ( "ConstValue-Class Start-Method  MoveJump : " + MoveJump );
		Debug.Log ( "ConstValue-Class Start-Method  LeftRightMoveValue : " + LeftRightMoveValue );
		Debug.Log ( "ConstValue-Class Start-Method  JumpUpwardValue : " + JumpUpwardValue );
	}
}
