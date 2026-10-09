
using MyCollection;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Колекція об'єктів --");

//List<int> items = new List<int>();
//items.Add(23);
//items.Add(18);
/*
MyGeneric myList = new MyGeneric();

myList.Add(12);
myList.Add(23);
myList.Add(16);
myList.Add("Світлана");
myList.Add("Надія");
myList.Add(false);
if (1 == 1)
{
    Dog barbos = new Dog("Барбос", 3);
    myList.Add(barbos);
}

myList.ViewItems();

var item = myList.Find(12);
Console.WriteLine("Find 12 "+item);

item = myList.Find("Надія");


//item = myList.Find(barbos);
//Console.WriteLine("Find \"Надія\" " + item);
*/

int action = 0;
MyGeneric myList = new MyGeneric();
do
{
    Console.WriteLine("\n--- Меню ---");
    Console.WriteLine("0. Вийти");
    Console.WriteLine("1. Додати собаку у притулок");
    Console.WriteLine("2. Додати кота у притулок");
    Console.WriteLine("3. Показати усіх тварин притулку");
    Console.WriteLine("4. Пошук тварини ");
    Console.WriteLine("5. Забрати тваринку");
    Console.WriteLine("6. Забрати декілька тварин");
    Console.Write("Виберіть дію: ");

    if (!int.TryParse(Console.ReadLine(), out action))
    {
        Console.WriteLine("Невірний ввід. Спробуйте ще раз.");
        continue;
    }

    switch (action)
    {
        case 1:
            AddAnimal<Dog>("собаки");
            break;
        case 2:
            AddAnimal<Cat>("кота");
            break;
        case 3:
            myList.ViewItems();
            break;
        case 4:
            FindAnimal();
            break;
        case 5:
            DeleteAnimal();
            break;
        case 6:
            RemoveRangeAnimals();
            break;
        default:
            Console.WriteLine("До побачення!");
            break;
    }

} while (action != 0);

void AddAnimal<T>(string animalTypeName) where T : Animal
{
    Console.Write($"Введіть ім'я {animalTypeName}: ");
    string name = Console.ReadLine();
    Console.Write($"Введіть вік {animalTypeName}: ");
    if (int.TryParse(Console.ReadLine(), out int age))
    {
        Animal animal = typeof(T) == typeof(Dog) ? (Animal)new Dog(name, age) : new Cat(name, age);
        myList.Add(animal);
        Console.WriteLine("Тварину успішно додано до притулку!");
    }
}

void FindAnimal()
{
    Console.WriteLine("Кого шукаємо? 1 - Собаку, 2 - Кота");
    string typeChoice = Console.ReadLine();

    Console.Write("Введіть ім'я: ");
    string name = Console.ReadLine();
    Console.Write("Введіть вік: ");
    if (int.TryParse(Console.ReadLine(), out int age))
    {
        Animal searchTarget = typeChoice == "2" ? (Animal)new Cat(name, age) : new Dog(name, age);

        var found = myList.Find(searchTarget);
        if (found != null)
            Console.WriteLine("Тварина знайдена:\n" + found);
        else
            Console.WriteLine("Тварина не знайдена");
    }
}

void DeleteAnimal()
{
    Console.WriteLine("Кого видаляємо? 1 - Собаку, 2 - Кота");
    string typeChoice = Console.ReadLine();

    Console.Write("Введіть ім'я тварини: ");
    string name = Console.ReadLine();
    Console.Write("Введіть вік тварини: ");
    if (int.TryParse(Console.ReadLine(), out int age))
    {
        Animal target = typeChoice == "2" ? (Animal)new Cat(name, age) : new Dog(name, age);
        bool success = myList.Delete(target);
        if (success)
            Console.WriteLine("Тварину успішно забрано");
        else
            Console.WriteLine("Тварину не знайдено щою забрати");
    }
}

void RemoveRangeAnimals()
{
    Console.Write("Введіть початковий індекс: ");
    if (int.TryParse(Console.ReadLine(), out int begin))
    {
        Console.Write("Введіть кінцевий індекс: ");
        if (int.TryParse(Console.ReadLine(), out int end))
        {
            myList.RemoveRange(begin, end);
            Console.WriteLine("Діапазон індексів успішно оброблено.");
        }
    }
}
