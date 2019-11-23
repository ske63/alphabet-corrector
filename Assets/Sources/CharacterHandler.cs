using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


// キャラを扱うクラス
public class CharacterHandler : MonoBehaviour
{

// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 
// Member変数 public
// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 

	// 各移動状態のSpriteを設定
	public Sprite IdleSprite;	// 待機
	public Sprite MoveSprite;	// 移動
	public Sprite JumpSprite;	// ジャンプ


// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 
// Member変数 private
// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 

	// 定数クラス
	private ConstValue ConstValues;

	// キャラのRigidbody2DComponent
	private Rigidbody2D MainRigidbody2D;

	// キャラのSpriteRendererのComponent
	private SpriteRenderer MainSpriteRenderer;

	// 水平移動方向  -1:左, 0:無, 1:右
	private int HorizontalMoveDirection;
//	private int PreviousHorizontalMoveDirection = 0;  // 1つ前の状態

	// 垂直移動方向  -1:下, 0:無, 1:上
	private int VerticalMoveDirection;
//	private int PreviousVerticalMoveDirection = 0;  // 1つ前の状態

	// ジャンプするか
	private bool IsJump;
//	private bool WasJump = false;  // 1つ前の状態

	// 判定系
	private bool IsGround;	// 接地しているか


// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 
// いつものStartとUpdate
// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 

	// Start is called before the first frame update
	void Start()
	{
		// 定数クラスの取得
		GameObject GameManager = GameObject.Find ( "GameManager" );
		ConstValues = GameManager.GetComponent<ConstValue> ();

		// デバッグログ
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  ConstValues.MoveRightKey : " + ConstValues.MoveRightKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  ConstValues.MoveLeftKey : " + ConstValues.MoveLeftKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  ConstValues.MoveUpKey : " + ConstValues.MoveUpKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  ConstValues.MoveDownKey : " + ConstValues.MoveDownKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  ConstValues.MoveJumpKey : " + ConstValues.MoveJumpKey );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  ConstValues.RunForce : " + ConstValues.RunForce );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  ConstValues.JumpForce : " + ConstValues.JumpForce );

		// Rigidbody2Dの取得
		MainRigidbody2D = GetRigidbody2D ();

		// SpriteRendererComponentを取得
		MainSpriteRenderer = GetSpriteRenderer ();
	}

	// Update is called once per frame
	void Update()
	{
		GetInputKey ();
		MoveCharacter ();
		UpdateSprite ();
	}


// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 
// 当たり判定の取得
// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 

	// Objectに触れたときに自動で呼び出し
	void OnCollisionEnter2D ( Collision2D collision )
	{
		// デバッグログ
		// 触れられているObject(される側)
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Touched Object name :" + collision.gameObject.name );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Touched Object tag :" + collision.gameObject.tag );

		if ( collision.gameObject.tag == "Ground" )
		{
			IsGround = true;

			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  IsGround :" + IsGround );
		}
	}

	// Objectから離れたときに自動で呼び出し
	void OnCollisionExit2D ( Collision2D collision )
	{
		// デバッグログ
		// 触れられているObject(される側)
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Touched Object name :" + collision.gameObject.name );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Touched Object tag :" + collision.gameObject.tag );

		if ( collision.gameObject.tag == "Ground" )
		{
			IsGround = false;

			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  IsGround :" + IsGround );
		}
	}


// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 
// キー入力の取得
// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 

	// 入力しているキーを取得する
	private void GetInputKey ()
	{
//		PreviousHorizontalMoveDirection = HorizontalMoveDirection;
//		PreviousVerticalMoveDirection = VerticalMoveDirection;
//		WasJump = IsJump;

		HorizontalMoveDirection = GetKeyInputHorizontalDirection ();
		VerticalMoveDirection = GetKeyInputVerticalOrientation ();
		IsJump = HasEnteredJumpKey ();
	}

	// 水平方向の入力しているキーを取得する
	// -1     0     1
	// ←    ・    →
	private int GetKeyInputHorizontalDirection ()
	{
		// 左右移動
		if ( Input.GetKey ( ConstValues.MoveRightKey ) )
		{
			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Pressing Key : " + ConstValues.MoveRightKey );

			return 1;
		}
		else if ( Input.GetKey ( ConstValues.MoveLeftKey ) )
		{
			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Pressing Key : " + ConstValues.MoveLeftKey );

			return -1;
		}

		return 0;
	}

	// 垂直方向の入力しているキーを取得する
	// ↑ 1
	//     
	// ・ 0
	//     
	// ↓ -1
	private int GetKeyInputVerticalOrientation ()
	{
		// 上下移動
		if ( Input.GetKey ( ConstValues.MoveUpKey ) )
		{
			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Pressing Key : " + ConstValues.MoveUpKey );

			return 1;
		}
		else if ( Input.GetKey ( ConstValues.MoveDownKey ) )
		{
			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Pressing Key : " + ConstValues.MoveDownKey );

			return -1;
		}

		return 0;
	}

	// ジャンプのキーが入力されているか
	private bool HasEnteredJumpKey ()
	{
		// ジャンプ
		if ( Input.GetKeyDown ( ConstValues.MoveJumpKey ) )
		{
			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Pressed Key : " + ConstValues.MoveJumpKey );

			return true;
		}

		return false;
	}


// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 
// Characterの動作
// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 

	// キャラを動かす
	private void MoveCharacter ()
	{
		if ( HorizontalMoveDirection != 0 )
		{
			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  HorizontalMoveDirection : " + HorizontalMoveDirection );

			MoveHorizontalDirection (
				HorizontalMoveDirection
				, ConstValues.RunForce
				, ConstValues.RunSpeed
				, ConstValues.RunThreshold
			);
		}
		else
		{
			AttenuateHorizontalOrientationInertia ( ConstValues.InertiaAttenuationValueAtStop );
		}

		if ( IsJump )
		{
			// デバッグログ
			Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  IsJump : " + IsJump );

			MoveJump ( ConstValues.JumpForce );
		}
	}

	// 水平方向に動く
	private void MoveHorizontalDirection (
		int horizontalMoveDirection
		, float moveForce
		, float moveSpeed
		, float moveThreshold
	)
	{
		// デバッグログ
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  horizontalMoveDirection : " + horizontalMoveDirection );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  moveForce : " + moveForce );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  moveSpeed : " + moveSpeed );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  moveThreshold : " + moveThreshold );

		// 現在の水平の移動速度
		// しきい値に達するまではAddforceで力を加え、それ以降はtransform.positionを直接書き換えて同一速度で移動する
		float CurrentInHorizontalMoveSpeed = Mathf.Abs ( MainRigidbody2D.velocity.x );
		if ( CurrentInHorizontalMoveSpeed < moveThreshold )
		{
			MainRigidbody2D.AddForce ( transform.right * horizontalMoveDirection * moveForce );
		}
		else
		{
			transform.position += new Vector3 ( horizontalMoveDirection * moveSpeed * Time.deltaTime, 0, 0 );
		}

		// デバッグログ
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  CurrentInHorizontalMoveSpeed : " + CurrentInHorizontalMoveSpeed );
	}

	// ジャンプする
	private void MoveJump ( float moveForce )
	{
		// デバッグログ
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  moveForce : " + moveForce );

		MainRigidbody2D.AddForce ( transform.up * moveForce );
	}

	// 水平方向の慣性を減衰させる
	private void AttenuateHorizontalOrientationInertia ( float AttenuationValue )
	{
		if ( MainRigidbody2D.velocity.x == 0 )
		{
			return;
		}

		// デバッグログ
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  AttenuationValue : " + AttenuationValue );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  MainRigidbody2D.velocity.x : " + MainRigidbody2D.velocity.x );

		MainRigidbody2D.velocity = new Vector2 (
			MainRigidbody2D.velocity.x / AttenuationValue
			, MainRigidbody2D.velocity.y
		);
	}


// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 
// Characterの見た目の変更
// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 

	// キャラの状態に応じてSpriteを更新する
	private void UpdateSprite ()
	{
		if ( !IsGround )
		{
			// 接地していないときはジャンプSpriteに更新
			UpdateSprite ( JumpSprite, HorizontalMoveDirection );
		}
		else if ( HorizontalMoveDirection != 0 )
		{
			// 接地していて水平移動しているときは移動Spriteに更新
			UpdateSprite ( MoveSprite, HorizontalMoveDirection );
		}
		else
		{
			// 何もしていないときは待機Spriteに更新
			UpdateSprite ( IdleSprite, HorizontalMoveDirection );
		}
	}

	// Spriteを更新する
	private void UpdateSprite ( Sprite sprite, int horizontalFacing )
	{
		if (
			MainSpriteRenderer.sprite == sprite
			&& ( horizontalFacing == 0 || transform.localScale.x == ( float ) horizontalFacing )
		)
		{
			return;
		}

		// デバッグログ
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  Update to sprite : " + sprite.name );
		Debug.Log ( "Class-" + this.GetType().Name + " Method-" + MethodBase.GetCurrentMethod().Name + "  horizontalFacing : " + horizontalFacing );

		MainSpriteRenderer.sprite = sprite;

		if ( horizontalFacing != 0 )
		{
			transform.localScale = new Vector3 ( horizontalFacing, 1, 1 );
		}
	}


// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 
// Member変数のProperty
// ==== ==== ==== ==== ==== ==== ==== ==== ==== ==== 

	// Rigidbody2DComponentを取得する
	private Rigidbody2D GetRigidbody2D ()
	{
		return gameObject.GetComponent<Rigidbody2D> ();
	}

	// SpriteRendererComponentを取得する
	private SpriteRenderer GetSpriteRenderer ()
	{
		return gameObject.GetComponent<SpriteRenderer> ();
	}
}
