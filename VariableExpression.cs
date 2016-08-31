using System;

public class VariableExpression : Expression
{
    private string variableName;
    public VariableExpression(string variableName){
        this.variableName=  variableName;
    }

    public string Evaluate(Context context){
        return context.GetScopeValue(variableName).ToString();
    }
}