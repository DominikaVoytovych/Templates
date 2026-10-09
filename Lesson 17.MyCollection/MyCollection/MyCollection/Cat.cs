using MyCollection;
using System.Xml.Linq;

public class Cat : Animal
{
    public Cat() : base() { }

    public Cat(string name, int age) : base(name, age) { }

    public static bool operator ==(Cat c1, Cat c2)
    {
        if (ReferenceEquals(c1, c2)) return true;
        if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null)) return false;
        return c1._name.Equals(c2._name) && c1._age == c2._age;
    }

    public static bool operator !=(Cat c1, Cat c2)
    {
        return !(c1 == c2);
    }

    public override bool Equals(object? obj)
    {
        return obj is Cat cat && this == cat;
    }


    public override string ToString()
    {
        return $"Кіт -> " + base.ToString();
    }
}