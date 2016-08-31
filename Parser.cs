using System.Collections.Generic;

public class Parser{
    public static Ast Parse(string str){

        int brackets  = 0;
        string s = "";
        int state = 0;
        List<Expression> expressions = new List<Expression>();
        foreach (char c in str){
            if (c == '{'){
                brackets ++;
            }
            if (c == '}'){
                brackets --;
            }
            if (state != brackets){
                expressions.Add(NewExpression(s,state));
                s = "";
                state = brackets;
            }else{
                s+=c;
            }
        }
        expressions.Add(NewExpression(s,state));
        return new Ast(expressions);
    }

    private static Expression NewExpression(string s, int state){
        switch(state){
            case 0:
                return new TextExpression(s);
            case 2:
                return new VariableExpression(s);
        }
        return new EmptyExpression();
    }
}