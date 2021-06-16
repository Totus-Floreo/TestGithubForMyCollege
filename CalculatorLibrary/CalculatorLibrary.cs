using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class CalculatorLibraryClass
    {
        JsonWriter writer;
        public CalculatorLibraryClass()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
        public double Calculation(double x, double y, string op)
        {
            double result = double.NaN; // Присваеваем выходному значению стандартное значение для избежания ошибок
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(x);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(y);
            writer.WritePropertyName("Operation");
            switch (op) // С помощью оператора switch и значению переменной op, выбирается действия калькулятора
            {
                case "+":
                    result = x + y;
                    writer.WriteValue("Add");
                    break;
                case "-":
                    result = x - y;
                    writer.WriteValue("Subtract");
                    break;
                case "*":
                    result = x * y;
                    writer.WriteValue("Multiply");
                    break;
                case "/":
                    if (y != 0) // проверка на то, что бы 2 число не было
                    {
                        result = x / y;
                        writer.WriteValue("Divide");
                    }
                    else
                    {
                        //Запрос ввода делителя (не ноль)
                        while (y == 0)
                        {
                            Console.WriteLine(" Введите число отличное от 0: ");
                            y = Convert.ToDouble(Console.ReadLine());
                        }
                        result = x / y;
                        writer.WriteValue("Divide");
                    }
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();
            return result; // Возврощаем результат действия
        }
    }
}
