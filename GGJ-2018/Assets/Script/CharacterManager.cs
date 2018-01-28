using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

	public GameObject character;

	private int numChars = 20;

	// Use this for initialization
	void Start () {
		Vector3 newPosition;

		for(int i = 0; i < numChars; i++){
			newPosition = new Vector3 (Random.Range(-34.0f, 32.0f), 0.5f, Random.Range(-38.0f, 28.0f));

			Collider[] col = Physics.OverlapBox(newPosition, new Vector3(1f, 0f,1f));

			if(col.Length == 0){
				var newCharacter = Instantiate (character, newPosition, Quaternion.identity);

				newCharacter.transform.parent = gameObject.transform;
				newCharacter.transform.Rotate (new Vector3 (0f, Random.Range (-180.0f, 180.0f), 0f));
			} else {
				i--;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
