using UnityEngine;
using System.Collections;

public class ClassTester : MonoBehaviour {

    int Life;
    Auto MioVeicolo1;
    Auto MioVeicolo2;
    Auto MioVeicolo3;
    Motociclo MiaMoto1;

    // Use this for initialization
    void Start () {
        // Catena di montaggio
        //MioVeicolo1 = new Auto(50);
        MioVeicolo2 = new Auto(100);
        MioVeicolo3 = new Auto();
        MiaMoto1 = new Motociclo();

        MioVeicolo3.CarburanteRimanente = MioVeicolo2.CarburanteRimanente;
        MioVeicolo1 = MioVeicolo2;
        MioVeicolo3 = MioVeicolo2;

        //MioVeicolo1.CarburanteRimanente = 100;
        //MioVeicolo2.CarburanteRimanente = 99;
        //MioVeicolo3.CarburanteRimanente = 100;

        // post vendita
        MioVeicolo3.CarburanteRimanente = MioVeicolo3.CarburanteRimanente - 20;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
