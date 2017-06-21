using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDropDown : MonoBehaviour {
    private Dropdown dropdown;
	// Use this for initialization
	void Start () {
        dropdown = GetComponent<Dropdown>();
	}

    public void ValueChange()
    {
        int _value=dropdown.value;
        Debug.Log("value_" + _value);
        ScoreManager.Instance.SetPlayerNum(_value + 1);
    }
}
