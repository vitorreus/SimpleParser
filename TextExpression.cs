using System;

public class TextExpression  : Expression {
    private string text;
    public TextExpression(string text){
        this.text = text;
    }

    public string Evaluate(Context context){
        return text;
    }
}