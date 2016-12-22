using UnityEngine;
using Bellali;

public class MyClass {

    string CosaDaLoggare;



    public MyClass() {
    
    }

    public MyClass(string _fraseDaLoggare) {
        CosaDaLoggare = _fraseDaLoggare;
    }

    public void LogMe() {
        Debug.Log(CosaDaLoggare);
    }

    

    public void Update() {
        //Debug.Log("MyClass Update");

        //if (CosaDaLoggare == "aaa") {
        //    // Fai 1
        //} else {
        //    // Fai 2
        //}

        //if (CosaDaLoggare == "aaa") {
        //    // Fai 1
        //} else if(CosaDaLoggare == "bbb") {
        //    // Fai 2
        //}



    }

}