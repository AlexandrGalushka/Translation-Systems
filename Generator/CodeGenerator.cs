using SyntaxParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{

    


   
    //public enum ItemType
    //{
    //    Operation = 1,
    //    Const
    //}
    //public enum Priority
    //{
    //    Low = 1,
    //    Middle,
    //    High 
    //}
    //public class CodeGenerator
    //{
        
    //    //public IList<OutArrayItem> CreateOutputArray (string expression)
    //    //{
    //    //    IList<OutArrayItem> outArray = new List<OutArrayItem>();
    //    //    Stack<Operation> operationStack = new Stack<Operation>(); 
    //    //    foreach(char symbol in expression)
    //    //    {
    //    //        string symb = symbol.ToString();
    //    //        if (IsConst(symb)) //если число
    //    //        {
    //    //            outArray.Add(CreateConst(symb));
    //    //        } 
    //    //        else if (IsOperation(symb)) //если операция
    //    //        {
    //    //            if (operationStack.Any()) {// если в стеке что-то есть
    //    //                Operation currentOperation = CreateOperation(symb);
    //    //                if (operationStack.Peek() > currentOperation || operationStack.Peek() == currentOperation)//если приоритет операции на верху стека выше или равен чем текущая операция
    //    //                {
    //    //                    Operation migrateOperation = operationStack.Peek();//забираем из вершины стека операцию
    //    //                    operationStack.Pop();
    //    //                    outArray.Add(migrateOperation as Operation); //добавляем её в выходном массив
    //    //                    operationStack.Push(currentOperation); //добавляем текущую операцию в стек
    //    //                } else if (currentOperation.Value == "(") //если текущая операция это скобка 
    //    //                {
    //    //                    operationStack.Push(currentOperation);//просто добавляем её в стек
    //    //                } else if (currentOperation.Value == ")")//если текущая операция это закрывающая скобка
    //    //                {
    //    //                    while(operationStack.Peek().Value != "(") //пока не встретим открывающую скобку
    //    //                    {
    //    //                        outArray.Add(operationStack.Peek()); //переносим все операции из стека в выходной массив
    //    //                        operationStack.Pop();
    //    //                    }
    //    //                    if (operationStack.Peek().Value == "(") //избавляемся от скобки
    //    //                        operationStack.Pop();
    //    //                }
    //    //            } else //если в стеке ничего нету просто добавляем операцию в стек
    //    //            {
    //    //                operationStack.Push(CreateOperation(symb));
    //    //            }
    //    //        }
    //    //    }
    //    //    while (operationStack.Any())
    //    //    {
    //    //        outArray.Add(operationStack.Peek());
    //    //        operationStack.Pop();
    //    //    }
    //    //    return outArray;
    //    //}

    //    //public double Execute(IList<OutArrayItem> outArray)
    //    //{
    //    //    IList<OutArrayItem> tmp = new List<OutArrayItem>();
    //    //    foreach(var currentItem in outArray)
    //    //    {
    //    //        if (currentItem is Const)
    //    //        {
    //    //            tmp.Add(currentItem);
    //    //        }
    //    //        if (currentItem is Operation)
    //    //        {
    //    //            switch (currentItem.Value)
    //    //            {
    //    //                case "*":
    //    //                    tmp[tmp.Count - 2].Value = (double.Parse(tmp[tmp.Count - 2].Value) * double.Parse(tmp[tmp.Count - 1].Value)).ToString();
    //    //                    tmp.RemoveAt(tmp.Count - 1);
    //    //                    break;
    //    //                case "/":
    //    //                    tmp[tmp.Count - 2].Value = (double.Parse(tmp[tmp.Count - 2].Value) / double.Parse(tmp[tmp.Count - 1].Value)).ToString();
    //    //                    tmp.RemoveAt(tmp.Count - 1);
    //    //                    break;
    //    //                case "+":
    //    //                    tmp[tmp.Count - 2].Value = (double.Parse(tmp[tmp.Count - 2].Value) + double.Parse(tmp[tmp.Count - 1].Value)).ToString();
    //    //                    tmp.RemoveAt(tmp.Count - 1);
    //    //                    break;
    //    //                case "-":
    //    //                    tmp[tmp.Count - 2].Value = (double.Parse(tmp[tmp.Count - 2].Value) - double.Parse(tmp[tmp.Count - 1].Value)).ToString();
    //    //                    tmp.RemoveAt(tmp.Count - 1);
    //    //                    break;
    //    //            }
    //    //        }
    //    //    }
    //    //    return double.Parse(tmp[0].Value);
    //    }
    //    private bool IsOperation(string symbol)
    //    {
    //        return symbol == "*" ||
    //            symbol == "/" ||
    //            symbol == "+" ||
    //            symbol == "-";
    //    }
    //    private  Operation CreateOperation(string symbol)
    //    {
    //        Priority priority;
    //        switch (symbol)
    //        {
    //            case "*": priority = Priority.High; break;
    //            case "/": priority = Priority.High; break;
    //            case "+": priority = Priority.Middle; break;
    //            case "-": priority = Priority.Middle; break;
    //            case "(": priority = Priority.Low; break;
    //            case ")": priority = Priority.Low; break;
    //            default:
    //                throw new Exception("That is not operation!");
    //        }
    //        return new Operation(symbol, priority);

    //    }
    //    private bool IsConst(string symbol)
    //    {
    //        double result;
    //        return double.TryParse(symbol, out result);
    //    }
    //    private Const CreateConst(string symbol)
    //    {
    //        return new Const(symbol);
    //    }
         
    //}
}
