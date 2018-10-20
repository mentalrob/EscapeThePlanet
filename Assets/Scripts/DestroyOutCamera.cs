using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutCamera : MonoBehaviour {
	void OnBecameInvisible () {
        Destroy(gameObject);
	}
}
