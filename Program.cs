using System;
using System.Collections.Generic;
using System.Linq;

public class EmployeeDatabase
{
    private readonly List<Employee> _employees = new();
    private int _nextId = 0;

    public void AddEmployee(string lastName, string firstName, string patronymic, string position, decimal salary)
    {
        var employee = new Employee(_nextId++, lastName, firstName, patronymic, position, salary);
        _employees.Add(employee);
        Console.WriteLine("Сотрудник добавлен: " + employee);
    }

    public void SelectAll()
    {
        if (_employees.Count == 0)
        {
            Console.WriteLine("База данных пуста.");
            return;
        }
        foreach (var emp in _employees)
            Console.WriteLine(emp);
    }

    public void SelectWhere(string field, string value)
    {
        var found = _employees.Where(e => e.HasFieldValue(field, value)).ToList();
        if (found.Count == 0)
        {
            Console.WriteLine("Нет записей, удовлетворяющих запросу.");
            return;
        }
        foreach (var emp in found)
            Console.WriteLine(emp);
    }
}