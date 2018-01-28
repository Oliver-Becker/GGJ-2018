using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VRButton : MonoBehaviour {
	private float fillTime = 2f;
	private float timer;
	private Slider mySlider;
	private Coroutine fillBarRoutine;
	public GameObject slider;
	public string Scene;
	// Use this for initialization
	void Start () {
		mySlider = GetComponent<Slider>();
		if (mySlider == null)
		{
			Debug.Log("OOPS...no slider");
		}

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(FillBar());
	}
	private IEnumerator FillBar()
	{
		timer = 0f;

		while (timer < fillTime)
		{
			timer += Time.deltaTime;
			mySlider.value = timer / fillTime;

			yield return null;



		}

		OnBarFilled();


	}
	private void OnBarFilled()
	{	
		Debug.Log ("carrega cena");
		slider.SetActive(false);
		SceneManager.LoadScene (Scene);
	}

}
