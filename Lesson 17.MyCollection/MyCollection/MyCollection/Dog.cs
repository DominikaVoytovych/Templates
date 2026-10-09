namespace MyCollection;

public class Dog : Animal
{
    public Dog() : base()
    {  }
    //ctor
    public Dog(string name, int age)
        : base(name, age) { }


    //Роблю перегрузку операторів == та != для класу Dog
    public static bool operator ==(Dog d1, Dog d2)
    {
        if (d1._name.Equals(d2._name) && d1._age == d2._age)
            return true;
        else
            return false;
    }

    public static bool operator !=(Dog d1, Dog d2)
    {
        return !(d1 == d2);
    }
    public override bool Equals(object? obj)
    {
        return obj is Dog dog && this == dog;
    }
    public override string ToString()
    {
        return $"Собака -> " + base.ToString();
    }
}
