using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// キャラの移動を扱うクラス
public class CharacterHandler : MonoBehaviour
{
	// 定数クラス
	private ConstValue ConstValues;
	
	// キャラのRigidbody2DComponent
	private Rigidbody2D MainRigidbody2D;
	
	
	// Start is called before the first frame update
	void Start()
	{
		// 定数クラスの取得
		GameObject GameManager = GameObject.Find ( "GameManager" );
		ConstValues = GameManager.GetComponent<ConstValue> ();
		
		// デバッグログ
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveRight : " + ConstValues.MoveRight );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveLeft : " + ConstValues.MoveLeft );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveUp : " + ConstValues.MoveUp );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveDown : " + ConstValues.MoveDown );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveJump : " + ConstValues.MoveJump );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.LeftRightMoveValue : " + ConstValues.LeftRightMoveValue );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.JumpUpwardValue : " + ConstValues.JumpUpwardValue );
		
		// Rigidbody2Dの取得
		MainRigidbody2D = getRigidbody2D ();
	}

	// Update is called once per frame
	void Update()
	{
		MoveCharacter ();
	}

	// キャラを動かす
	private void MoveCharacter ()
	{
		// 左右移動
		if ( Input.GetKey ( ConstValues.MoveRight ) )
		{
			// デバッグログ
			Debug.Log ( "CharacterHandler-Class MoveCharacter-Method  Pressing Key : " + ConstValues.MoveRight );
			
			MoveRight ( ConstValues.LeftRightMoveValue );
		}
		else if ( Input.GetKey ( ConstValues.MoveLeft ) )
		{
			// デバッグログ
			Debug.Log ( "CharacterHandler-Class MoveCharacter-Method  Pressing Key : " + ConstValues.MoveLeft );
			
			MoveLeft ( ConstValues.LeftRightMoveValue );
		}
	}

	// 右に動く
	private void MoveRight ( float moveValue )
	{
		// デバッグログ
		Debug.Log ( "CharacterHandler-Class MoveRight-Method  moveValue : " + moveValue );
		
		MainRigidbody2D.AddForce ( transform.right * moveValue );
	}

	// 左に動く
	private void MoveLeft ( float moveValue )
	{
		// デバッグログ
		Debug.Log ( "CharacterHandler-Class MoveLeft-Method  moveValue : " + moveValue );
		
		MainRigidbody2D.AddForce ( transform.right * moveValue * -1 );
	}


	// Rigidbody2DComponentを取得する
	private Rigidbody2D getRigidbody2D ()
	{
		return gameObject.GetComponent<Rigidbody2D> ();
	}
}
