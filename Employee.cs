using System;

public class Employee
{
    public int Id { get; }
    public string LastName { get; }
    public string FirstName { get; }
    public string Patronymic { get; }
    public string Position { get; }
    public decimal Salary { get; }

    public Employee(int id, string lastName, string firstName, string patronymic, string position, decimal salary)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
        Patronymic = patronymic;
        Position = position;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"ID: {Id} | {LastName} {FirstName} {Patronymic} | Должность: {Position} | Зарплата: {Salary} руб.";
    }

    public bool HasFieldValue(string field, string value)
    {
        switch (field.ToLower())
        {
            case "id":
                return Id.ToString() == value;
            case "lastname":
                return string.Equals(LastName, value, StringComparison.OrdinalIgnoreCase);
            case "firstname":
                return string.Equals(FirstName, value, StringComparison.OrdinalIgnoreCase);
            case "patronymic":
                return string.Equals(Patronymic, value, StringComparison.OrdinalIgnoreCase);
            case "position":
                return string.Equals(Position, value, StringComparison.OrdinalIgnoreCase);
            case "salary":
                return Salary.ToString() == value;
            default:
                return false;
        }
    }
}