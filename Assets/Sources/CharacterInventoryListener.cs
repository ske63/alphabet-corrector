using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInventoryListener : MonoBehaviour
{
	public Text AcquiredAlphabetCountText;
	public Text AcquiredAlphabetListText;

	private CharacterHandler MainCharacterHandler;


	// Start is called before the first frame update
	void Start ()
	{
		MainCharacterHandler = GetCharacterHandler ();
	}

	// Update is called once per frame
	void Update ()
	{
		// 取得したAlphabetの一覧
		List<string> AcquiredAlphabetList = MainCharacterHandler.GetAcquiredAlphabetList ();

		string Output = "";
		foreach ( string AlphabetCharacter in AcquiredAlphabetList )
		{
			Output += AlphabetCharacter;
			Output += " ";
		}

		AcquiredAlphabetCountText.text = AcquiredAlphabetList.Count.ToString ();
		AcquiredAlphabetListText.text = Output;
}


	// CharacterHandlerComponentを取得する
	private CharacterHandler GetCharacterHandler ()
	{
		return gameObject.GetComponent<CharacterHandler> ();
	}
}
