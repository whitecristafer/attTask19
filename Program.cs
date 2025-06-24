using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var db = new EmployeeDatabase();
        Console.WriteLine("База данных сотрудников автобусного парка.");
        Console.WriteLine("Доступные команды:");
        Console.WriteLine("ADD(Фамилия, Имя, Отчество, Должность, Зарплата);");
        Console.WriteLine("SELECT *;");
        Console.WriteLine("SELECT поле=значение;");
        Console.WriteLine("Примеры: SELECT id=0; SELECT lastname=Иванов;");

        while (true)
        {
            Console.Write("\nВведите команду: ");
            string input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input))
                continue;

            try
            {
                if (input.StartsWith("ADD(", StringComparison.OrdinalIgnoreCase) && input.EndsWith(");"))
                {
                    var paramStr = input.Substring(4, input.Length - 6);
                    var parts = paramStr.Split(',');
                    if (parts.Length != 5)
                    {
                        Console.WriteLine("Ошибка: необходимо 5 параметров.");
                        continue;
                    }
                    string lastName = parts[0].Trim();
                    string firstName = parts[1].Trim();
                    string patronymic = parts[2].Trim();
                    string position = parts[3].Trim();
                    if (!decimal.TryParse(parts[4].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal salary))
                    {
                        Console.WriteLine("Ошибка: некорректная зарплата.");
                        continue;
                    }
                    db.AddEmployee(lastName, firstName, patronymic, position, salary);
                }
                else if (string.Equals(input, "SELECT *;", StringComparison.OrdinalIgnoreCase))
                {
                    db.SelectAll();
                }
                else if (input.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase) && input.EndsWith(";"))
                {
                    var paramStr = input.Substring(6, input.Length - 7).Trim();
                    if (paramStr == "*")
                    {
                        db.SelectAll();
                        continue;
                    }
                    var eqIdx = paramStr.IndexOf('=');
                    if (eqIdx == -1)
                    {
                        Console.WriteLine("Ошибка: неверный синтаксис SELECT.");
                        continue;
                    }
                    var field = paramStr.Substring(0, eqIdx).Trim();
                    var value = paramStr.Substring(eqIdx + 1).Trim();
                    db.SelectWhere(field, value);
                }
                else
                {
                    Console.WriteLine("Ошибка: команда не распознана.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}