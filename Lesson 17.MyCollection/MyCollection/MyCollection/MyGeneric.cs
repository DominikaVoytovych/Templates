namespace MyCollection;

public class MyGeneric
{
    private object[] _items;

    public MyGeneric()
    {
        //на початку список пустий
        _items = new object[0];
    }
    public void Add(object item) // Додати новий елемент у масив
    {
        int count = _items.Length;
        object[] temp = new object[count + 1];
        //копіюю із одного масиву в інший
        for(int i=0; i<count; i++)
            temp[i] = _items[i];
        temp[count] = item; //зберігаю у кінцець масиву
        _items = temp; //оновляю новим даними старий масив
    }

    public object? Find(object item) //пошук елемента
    {
        foreach(var i in _items)
        {
            if(i is int)
            {
                try
                {
                    int myInt = (int)i;
                    if (myInt == (int)item)
                        return i;
                }
                catch { }
            }
            if(i is Dog)
            {
                try
                {
                    Dog myDog = (Dog)i;
                    Dog searchDog = (Dog)item;
                    if (myDog == searchDog)
                        return i;
                }
                catch { }
            }
            if(i == item) return i;
        }
        return null; 
    }
    public bool Delete(object item)
    {
        int index = -1;
        for (int k = 0; k < _items.Length; k++)
        {
            var current = _items[k];
            if (current is Dog && item is Dog && (Dog)current == (Dog)item)
            {
                index = k;
                break;
            }
            else if (current is Cat && item is Cat && (Cat)current == (Cat)item)
            {
                index = k;
                break;
            }
            else if (current != null && current.Equals(item))
            {
                index = k;
                break;
            }
        }

        if (index == -1) return false;

        object[] temp = new object[_items.Length - 1];
        for (int i = 0, j = 0; i < _items.Length; i++)
        {
            if (i == index) continue;
            temp[j] = _items[i];
            j++;
        }
        _items = temp;
        return true;
    }

    // метод RemoveRange 
    public void RemoveRange(int indexBegin, int indexEnd)
    {
        if (indexBegin < 0) indexBegin = 0;
        if (indexEnd >= _items.Length) indexEnd = _items.Length - 1;

        if (indexBegin > indexEnd || _items.Length == 0) return;

        int removeCount = (indexEnd - indexBegin) + 1;
        int newLength = _items.Length - removeCount;
        if (newLength < 0) newLength = 0;

        object[] temp = new object[newLength];
        for (int i = 0, j = 0; i < _items.Length; i++)
        {
            if (i >= indexBegin && i <= indexEnd)
            {
                continue; 
            }
            temp[j] = _items[i];
            j++;
        }
        _items = temp;
    }

    public void ViewItems() //відображення колекції
    {
        foreach(object item in _items)
            Console.WriteLine(item);
    }
}
