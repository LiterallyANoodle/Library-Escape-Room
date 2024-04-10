using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : PuzzleManager
{
    public bool check = false;
    private List<MeshRenderer> buttonMeshes;
    List<int> inputted = new List<int>();
    List<int> answer;
    public Material initialMat;
    // Start is called before the first frame update
    void Start()
    {
        answer = new List<int>() {3,4,8,1,9,0,6,2,7,5};
        buttonMeshes = new(GetComponentsInChildren<MeshRenderer>());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Testfun(int i) {
        inputted.Add(i);
        foreach (int j in inputted)
        {
            print(j);
        }
    }

    public void ButtonClear() {
        inputted = new List<int>();
        foreach(MeshRenderer mr in buttonMeshes) {
            if (mr.CompareTag("Button")) {
            mr.material = initialMat;
            }
        }
    }

    public void ButtonSubmit() {
        check = true;
        if(inputted.Count != answer.Count){
            print("false");
            check = false;
            ButtonClear();
        }
        if(inputted.Count == answer.Count){
            for (int k = 0; k < inputted.Count; k++) {
                if (answer[k] != inputted[k]) {
                    print("false");
                    check = false;
                    ButtonClear();
                }
            }
        }
    }
    public override bool verifySolved() {
        return check;
    }
}
