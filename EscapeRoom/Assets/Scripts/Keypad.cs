using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    List<int> inputted = new List<int>();
    List<int> answer;
    // Start is called before the first frame update
    void Start()
    {
        answer = new List<int>() {1,2,3};
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
    }

    public void ButtonSubmit() {
        bool check = true;

        if(inputted.Count != answer.Count){
            check = false;
            print("false");
        }
        if(inputted.Count == answer.Count){
            for (int k = 0; k < inputted.Count; k++) {
                if (answer[k] != inputted[k]) {
                    check = false;
                    print("false");
                }
            }
        }
    }
}
