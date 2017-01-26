using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MiscUtilities : MonoBehaviour {

  //##################################################
	//	ALVARO COROUTINES
	//##################################################
	IEnumerator ScaleTo (Vector3 i_scale, float i_time) {
		Vector3 scale = this.transform.localScale;

		for (float currentLerpTime = 0.0f; currentLerpTime < i_time; currentLerpTime += Time.deltaTime) {

			float t = currentLerpTime / i_time;
			t = t * t * t * (t * (6f * t - 15f) + 10f);

			this.transform.localScale = Vector3.Lerp (scale, i_scale, t);

			yield return null;
		}

		this.transform.localScale = i_scale;
	}

}
