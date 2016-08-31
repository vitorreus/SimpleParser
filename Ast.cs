using System;
using System.Collections.Generic;

public class Ast : Expression{

    List< Expression> childs;

    public Ast( List< Expression> childs ){
        this.childs = childs;
    }

    public string Evaluate(Context context){
        string result = "";
        foreach (Expression e in childs){
            result += e.Evaluate(context);
        }
        return result;
    }
}