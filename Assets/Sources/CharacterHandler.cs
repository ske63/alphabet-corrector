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
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveRightKey : " + ConstValues.MoveRightKey );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveLeftKey : " + ConstValues.MoveLeftKey );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveUpKey : " + ConstValues.MoveUpKey );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveDownKey : " + ConstValues.MoveDownKey );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.MoveJumpKey : " + ConstValues.MoveJumpKey );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.RunForce : " + ConstValues.RunForce );
		Debug.Log ( "CharacterHandler-Class Start-Method  ConstValues.JumpForce : " + ConstValues.JumpForce );
		
		// Rigidbody2Dの取得
		MainRigidbody2D = GetRigidbody2D ();
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
		if ( Input.GetKey ( ConstValues.MoveRightKey ) )
		{
			// デバッグログ
			Debug.Log ( "CharacterHandler-Class MoveCharacter-Method  Pressing Key : " + ConstValues.MoveRightKey );
			
			MoveRight ( ConstValues.RunForce );
		}
		else if ( Input.GetKey ( ConstValues.MoveLeftKey ) )
		{
			// デバッグログ
			Debug.Log ( "CharacterHandler-Class MoveCharacter-Method  Pressing Key : " + ConstValues.MoveLeftKey );
			
			MoveLeft ( ConstValues.RunForce );
		}
		
		// ジャンプ
		if ( Input.GetKeyDown ( ConstValues.MoveJumpKey ) )
		{
			// デバッグログ
			Debug.Log ( "CharacterHandler-Class MoveCharacter-Method  Pressed Key : " + ConstValues.MoveJumpKey );
			
			MoveJump ( ConstValues.JumpForce );
		}
	}

	// 右に動く
	private void MoveRight ( float moveForce )
	{
		// デバッグログ
		Debug.Log ( "CharacterHandler-Class MoveRight-Method  moveForce : " + moveForce );
		
		MainRigidbody2D.AddForce ( transform.right * moveForce );
	}

	// 左に動く
	private void MoveLeft ( float moveForce )
	{
		// デバッグログ
		Debug.Log ( "CharacterHandler-Class MoveLeft-Method  moveForce : " + moveForce );
		
		MainRigidbody2D.AddForce ( transform.right * moveForce * -1 );
	}

	// ジャンプする
	private void MoveJump ( float moveForce )
	{
		// デバッグログ
		Debug.Log ( "CharacterHandler-Class MoveJump-Method  moveForce : " + moveForce );
		
		MainRigidbody2D.AddForce ( transform.up * moveForce );
	}

	// Rigidbody2DComponentを取得する
	private Rigidbody2D GetRigidbody2D ()
	{
		return gameObject.GetComponent<Rigidbody2D> ();
	}
}
