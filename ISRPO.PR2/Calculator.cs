using System;
using CalculatorLibrary;

namespace ISRPO.PR2
{
    class Calculator
    {
        static void Main(string[] args)
        {
            CalculatorLibraryClass clc = new CalculatorLibraryClass();
            bool endApp = false;
                // Отображаем название нашей программы
                Console.WriteLine(" Консольный калькулятор в C#\r");
                Console.WriteLine(" ------------------------\n ");

            // Создаем цикл для работы с приложением
            while (!endApp)
                {
                    //Объявление переменных и установление пустых значений.
                    string rawnum1 = "" ;
                    double cleannum1 = 0;
                    string rawnum2 = "" ;
                    double cleannum2 = 0;
                    double result = 0;
                    //Запрос ввода первого числа и его проверка
                    Console.Write(" Напишите первое число и нажмите Enter: ");
                    rawnum1 = Console.ReadLine();
                    while (!double.TryParse(rawnum1, out cleannum1))
                    {
                        Console.Write(" Введеное значение не корректно, введите снова: ");
                        rawnum1 = Console.ReadLine();
                    }
                    //Запрос ввода второго числа и его проверка
                    Console.Write(" Напишите второе число и нажмите Enter: ");
                    rawnum2 = Console.ReadLine();
                    while (!double.TryParse(rawnum2, out cleannum2))
                    {
                        Console.Write(" Введеное значение не корректно, введите снова: ");
                        rawnum2 = Console.ReadLine();
                    }
                    //Запрос какое математическое действие использовать
                    Console.WriteLine(" Выберите одно из действий приведенных ниже:");
                    Console.WriteLine("\t + ");
                    Console.WriteLine("\t - ");
                    Console.WriteLine("\t * ");
                    Console.WriteLine("\t / ");
                    Console.Write("\t");
                    string op = Console.ReadLine();
                    // Исполнение действия и вывод результатов
                    try
                    {
                        result = clc.Calculation(cleannum1, cleannum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine(" Данный оператор передал ошибку в вычеслении.\n ");
                        }
                        else Console.WriteLine(" Ваш результат: {0} ", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" При попытке дейтсвия произошла ошибка.\n Детали: " +e.Message);
                    }

                    Console.WriteLine(" ------------------------\n ");
                    //Ожидание ответа пользователя перед закрытием
                    Console.Write(" Нажмите n и Enter для закрытия приложения, или нажмите Enter для продолжения: ");
                    if (Console.ReadLine() == "n") endApp = true;
                    Console.WriteLine("\n "); // Тон преличия передпользователем.
                    }
            //Перед возвратом вызов формата JSON для закрытия
            clc.Finish();
            return;
            }
        
    }
}
