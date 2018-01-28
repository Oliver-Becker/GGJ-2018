using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VRSlider : MonoBehaviour {
	public CharacterManager charactermanager;
	public PlayerController mosquitoflight;
	public _CharacterStatus _characterstatus;
    public float fillTime = 2f;
    private float timer;
    private Slider mySlider;
    //private bool gazedAt;
    private Coroutine fillBarRoutine;
    public GameObject Canvas;
    public bool TestCanvas;

	public Toggle toggle;
    // Use this for initialization
    void Start() {
		charactermanager = GameObject.FindGameObjectWithTag ("GameController").GetComponent <CharacterManager> ();
		toggle = GameObject.FindGameObjectWithTag ("Toggle").GetComponent <Toggle> ();
		mosquitoflight = GameObject.FindGameObjectWithTag ("Player").GetComponent <PlayerController> ();
		_characterstatus = GetComponentInParent<_CharacterStatus> ();
		if (_characterstatus == null)
		{
			Debug.Log("OOPS...no character status");
		}
        mySlider = GetComponent<Slider>();
        if (mySlider == null)
        {
            Debug.Log("OOPS...no slider");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Casos que não aparece o slider
        //mosquito sem doença e pessoa sem doença
        //mosquito com doença e pessoa com doença
        //pessoa vacinada
        //quando não puder aparecer slider, TestCanvas=false;
		if ((mosquitoflight.IsMosquitoInfected == false && _characterstatus._status != _CharacterStatus._Modes.Sick) ||
		    (mosquitoflight.IsMosquitoInfected == true && _characterstatus._status == _CharacterStatus._Modes.Sick) ||
		    (_characterstatus._status == _CharacterStatus._Modes.Immune))
			TestCanvas = false;
		else
			TestCanvas = true;

        if (TestCanvas == false)
        {
            Canvas.SetActive(false);
        }
		if (mySlider.isActiveAndEnabled)
			StartCoroutine(FillBar());
    }
   /* public void PointerEnter()
    {
        gazedAt = true;
        fillBarRoutine = StartCoroutine(FillBar());
    }*/
   /* public void PointerExit()
    {
        gazedAt = false;
        if (fillBarRoutine != null)
        {
            StopCoroutine(fillBarRoutine);
        }
        timer = 0f;
        mySlider.value = 0f;
    */
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
        Canvas.SetActive(false);

        //Realiza uma ação depois que preenche a barra
		if (_characterstatus._status == _CharacterStatus._Modes.Sick && mosquitoflight.IsMosquitoInfected == false) {
			mosquitoflight.IsMosquitoInfected = true;
			toggle.isOn = true;
		}
		if (_characterstatus._status == _CharacterStatus._Modes.Vulnerable && mosquitoflight.IsMosquitoInfected == true) {
			_characterstatus._status = _CharacterStatus._Modes.Sick;
			_characterstatus._ChangeCollor (_CharacterStatus._Modes.Sick);
			charactermanager._sick_count++;
		}
    }
}
