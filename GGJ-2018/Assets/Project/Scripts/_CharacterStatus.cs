using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterStatus : MonoBehaviour {

	public enum _Modes {Sick, Vulnerable, Immune};
	public _Modes _status;
	public SkinnedMeshRenderer mesh_rend;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void _ChangeCollor (_Modes stat) {
		switch (stat) {
			case _Modes.Sick :
				for (int i = 0; i < mesh_rend.materials.Length; ++i)
				mesh_rend.materials [i].color = new Color(255/255.0f, 65/255.0f, 0/255.0f);
				break;
			case _Modes.Vulnerable:
				for (int i = 0; i < mesh_rend.materials.Length; ++i)
				mesh_rend.materials [i].color = new Color(110/255.0f, 225/255.0f, 0/255.0f);
				break;
			case _Modes.Immune :
				for (int i = 0; i < mesh_rend.materials.Length; ++i)
				mesh_rend.materials [i].color = new Color(0/255.0f, 31/255.0f, 204/255.0f);
				break;
		}
	}
}
