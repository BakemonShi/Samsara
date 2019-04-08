using UnityEngine;
using System.Collections;

public class MapeadoJoystick : MonoBehaviour {


	void Update () {

		if (Input.GetButtonDown ("Quadrado")) {
			print ("Has pulsado el Quadrado");
		}
		if (Input.GetButtonDown ("X")) {
			print ("Has pulsado el X");
		}
		if (Input.GetButtonDown ("Redonda")) {
			print ("Has pulsado Redonda");
		}
		if (Input.GetButtonDown ("Triangulo")) {
			print ("Has pulsado Triangulo");
		}
		if (Input.GetButtonDown ("L1")) {
			print ("Has pulsado el L1");
		}
		if (Input.GetButtonDown ("R1")) {
			print ("Has pulsado R1");
		}
		if (Input.GetButtonDown ("L2")) {
			print ("Has pulsado L2");
		}
		if (Input.GetButtonDown ("R2")) {
			print ("Has pulsado R2");
		}
		if (Input.GetButtonDown ("Select")) {
			print ("Has pulsado Select");
		}
		if (Input.GetButtonDown ("Start")) {
			print ("Has pulsado Start");
		}
	}
}
