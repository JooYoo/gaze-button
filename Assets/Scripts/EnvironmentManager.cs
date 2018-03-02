using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject theCube;

    private bool isObjectActive;
	
	void Update ()
	{
	    isObjectActive = theCube.activeInHierarchy;
	}

    public void OnClickBt()
    {
        theCube.SetActive(!isObjectActive);
    }
}
