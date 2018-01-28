using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

	public GameObject character;

	public int _sick_count = 0;
	public int _immune_count = 0;

	public float _immunization_time;
	public _CharacterStatus[] _characterstatus;
	private float _time_counter;
	private int _aux;

	private int numChars = 20;

	// Use this for initialization
	void Start () {
		Vector3 newPosition;
		_characterstatus = new _CharacterStatus[numChars];

		for(int i = 0; i < numChars; i++){
			newPosition = new Vector3 (Random.Range(-34.0f, 32.0f), 0.5f, Random.Range(-38.0f, 28.0f));

			Collider[] col = Physics.OverlapBox(newPosition, new Vector3(1f, 0f,1f));

			if(col.Length == 0){
				var newCharacter = Instantiate (character, newPosition, Quaternion.identity);

				newCharacter.transform.parent = gameObject.transform;
				newCharacter.transform.Rotate (new Vector3 (0f, Random.Range (-180.0f, 180.0f), 0f));

				_characterstatus [i] = newCharacter.GetComponent<_CharacterStatus> ();

				if (i == 0) {
					_characterstatus [0]._status = _CharacterStatus._Modes.Sick;
					_characterstatus [0]._ChangeCollor (_CharacterStatus._Modes.Sick);
					_sick_count++;
				} else {
					_characterstatus [i]._status = _CharacterStatus._Modes.Vulnerable;
					_characterstatus [i]._ChangeCollor (_CharacterStatus._Modes.Vulnerable);
				}

			} else {
				i--;
			}
		}

		_characterstatus [0]._status = _CharacterStatus._Modes.Sick;
		_characterstatus [0]._ChangeCollor (_CharacterStatus._Modes.Sick);
	}
	
	// Update is called once per frame
	void Update () {
		if (_sick_count + _immune_count >= numChars) {
			Debug.Log("End of Game. Points: " + (_sick_count-1));

		}
		_time_counter += Time.deltaTime;
		if (_time_counter > _immunization_time) {
			_time_counter = 0;
			_aux = 1;
			while (_aux < numChars && _characterstatus [_aux]._status != _CharacterStatus._Modes.Vulnerable)
				_aux++;

			if (_aux < numChars && _characterstatus [_aux]._status == _CharacterStatus._Modes.Vulnerable) {
				_characterstatus [_aux]._status = _CharacterStatus._Modes.Immune;
				_characterstatus [_aux]._ChangeCollor (_CharacterStatus._Modes.Immune);
				_immune_count++;
			}
		}
	}
}
