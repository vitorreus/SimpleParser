using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class AbstractController : MonoBehaviour, Controller, Context {

    GameObject container;
    Text[] texts;

    Dictionary<Text,Ast> ast = new Dictionary<Text,Ast>();

    public virtual void Start(){
        if (transform.childCount != 1){
            Debug.LogError("AbstractController should have exactly one child to act as content holder");
        }
        container = transform.GetChild(0).gameObject;
        compile();
    }

    public void compile(){
        texts = GetComponentsInChildren<Text>();
        //TODO: Compile text to AST optimize further binding
        foreach (Text text in texts){
            ast[text] = Parser.Parse(text.text);
        }
    }

    public virtual void Hide(){
        container.SetActive(false);

    }
    public virtual void Show(){
        container.SetActive(true);
        compile();
    }
    public virtual void Toggle(){
        container.SetActive(!container.activeSelf);
    }

    public virtual void LateUpdate(){
        //todo improve this:
        foreach(Text text in texts){
            text.text = ast[text].Evaluate(this);
        }
    }

    public object GetScopeValue(string name){
        //Todo: cache field
        //Todo: GetProperty
        return GetType()
            .GetField(name)
            .GetValue(this);
    }
}
