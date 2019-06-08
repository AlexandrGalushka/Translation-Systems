
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxParser
{
    public interface IState
    {
        string Name { get; set; }
    }
    public class Operation : IState
    {
        public string Name { get; set; }
        public Operation(string name)
        {
            Name = name;
        }
        public string toString(ref int iterator, IList<Label> labels)
        {
            string result;
            switch (Name)
            {
                case "if_after_condition":
                    result = Name + ":\n";
                    labels.Add(new Label(iterator, true));
                    result += four("put_tagged_label", labels.Last().ToString(), "", "N");
                    iterator++;
                    result += "it = it + 1\n";
                    result += four("compare", "SOM", "true", "N");
                    var label4 = labels.Last(x => x.isTagged);
                    result += four("jn", label4.ToString(), "", "N");
                    return result;
                case "if_end":
                    result = Name + ":\n";
                    var label7 = labels.Last(x => x.isTagged);
                    result += four("put_label", label7.ToString(), "", "N");
                    labels.Remove(label7);
                    return result;
                case "add_shift":
                    result = Name + ":\n";
                    result += "shift <- BSSP \n";
                    result += "id_addres <- BSSP \n";
                    result += four("shift_addres", "id_addres", "shift", "new_addres");
                    result += four("put", "BSSP", "new_adress", "N");
                    return result;
                case "push_literal": 
                    result = Name + ":\n";
                    result += "lit <- SOM\n";
                    result += "BSSP <- lit\n";
                    return result;
                case "for_return_on_condition":
                    result = Name + ":\n";
                    labels.Add(new Label(iterator, false));
                    result += four("put label", labels.Last().ToString(), "", "N");
                    iterator++;
                    result += "it = it + 1\n";
                    return result;
                case "for_after_condition":
                    result = Name + ":\n";
                    labels.Add(new Label(iterator, true));
                    result += four("put_tagged_label", labels.Last().ToString(), "", "N");
                    iterator++;
                    result += "it = it + 1\n";
                    result += four("compare", "SOM", "true", "N");
                    result += four("jn", labels.Last(x => x.isTagged).ToString(), "", "N");
                    return result;
                case "for_end_opers":
                    result = Name + ":\n";
                    var label5 = labels.Last(x => !x.isTagged);
                    result += four("jmp", label5.ToString(), "", "N");
                    labels.Remove(label5);
                    return result;
                case "for_end_body": 
                    result = Name + ":\n";
                    var label6 = labels.Last(x => x.isTagged);
                    labels.Remove(label6);
                    result += four("put_label", label6.ToString(), "", "N");
                    return result;
                case "while_return_on_condition":
                    result = Name + ":\n";
                    labels.Add(new Label(iterator, false));
                    result += four("put_label", labels.Last().ToString(), "", "N");
                    iterator++;
                    result += "it = it + 1\n";
                    return result;
                case "while_after_condition":
                    result = Name + ":\n";
                    labels.Add(new Label(iterator, true));
                    result += four("put_tagged_label", labels.Last().ToString(), "", "N");
                    iterator++;
                    result += "it = it + 1\n";
                    result += four("compare", "SOM", "true", "N");
                    var label = labels.Last(x => x.isTagged);
                    result += four("jn", label.ToString(), "", "N");
                    return result;
                case "while_end_opers":
                    result = Name + ":\n";
                    var label2 = labels.Last(x => !x.isTagged);
                    labels.Remove(label2);
                    result += four("jmp", label2.ToString(), "", "N");
                    return result;
                case "while_end_body":
                    result = Name + ":\n";
                    var label3 = labels.Last(x => x.isTagged);
                    labels.Remove(label3);
                    result += four("put_label", label3.ToString(), "", "N");
                    return result;
                case "do_while_start_body":
                    result = Name + ":\n";
                    labels.Add(new Label(iterator, false));
                    result += four("put_label", labels.Last().ToString(), "", "N");
                    iterator++;
                    result += "it = it + 1 \n";
                    return result;
                case "do_while_after_cond":
                    result = Name + ":\n";
                    result += four("compare", "BSSP", "true", "N");
                    var label1 = labels.Last();
                    labels.RemoveAt(labels.Count - 1);
                    result += "label <- SOM";
                    result += four("jnz", label1.ToString(), "", "N");
                    return result;
                case "assign":
                    result = Name + ":\n";
                    result += four("assign", "val1", "val2", "N") ;
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "sub":
                    result = Name + ":\n";
                    result += four("sub", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "add":
                    result = Name + ":\n";
                    result += four("add", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "mul":
                    result = Name + ":\n";
                    result += four("mul", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "div":
                    result = Name + ":\n";
                    result += four("div", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "bool_equal":
                    result = Name + ":\n";
                    result += four("be", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "bool_non_equal":
                    result = Name + ":\n";
                    result += four("bne", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "bool_more":
                    result = Name + ":\n";
                    result += four("bm", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "bool_less":
                    result = Name + ":\n";
                    result += four("bl", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "bool_less_equal":
                    result = Name + ":\n";
                    result += four("ble", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "bool_more_equal":
                    result = Name + ":\n";
                    result += four("bme", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "bool_or":
                    result = Name + ":\n";
                    result += four("bo", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "bool_and":
                    result = Name + ":\n";
                    result += four("ba", "val1", "val2", "N");
                    result += four("put", "N", "BSSP", "N1");
                    return result;
                case "push_id":
                    result = Name + ":\n";
                    result += "id <- SOM\n";
                    result += "BSSP <- lit\n";
                    return result;
            }
            return "";
        }
        private string four(string action, string op1, string op2, string result)
        {
            return "(4) " + action + "; " + op1 + "; " + op2 + "; " + result + "\n";
        }
    }

    public class Label
    {
        public int Id { get; set; }
        public bool isTagged { get; set; }
        public string Addres
        {
            get => "0x000" + Id;
        }
        public Label(int id, bool tagged)
        {
            Id = id;
            isTagged = tagged;
        }
        public override string ToString()
        {
            return Addres;
        }
    }
}
