namespace ConsoleApp;

public class CustomArrayList
{
    private int[] _array;
    private int _length;

    public int Count { get; private set; }

    public CustomArrayList()
    {
        _array = new int[4];
        _length = _array.Length;
    }

    public CustomArrayList(int element)
    {
        _array = new int[4];
        _array[0] = element;

        Count = 1;
    }

    public CustomArrayList(int[] elements)
    {
        var arrayLength = (int)((elements.Length * 1.5) + elements.Length);
        _array = new int[arrayLength];

        for (int i = 0; i < elements.Length; i++)
        {
            _array[i] = elements[i];
            Count++;
        }

        _length = _array.Length;
    }

    /// <summary>
    /// Добавление одного элемента
    /// </summary>
    /// <param name="element"></param>
    public void Add(int element)
    {
        _length *= 2;
        Array.Resize(ref _array, _length);
        _array[Count++] = element;
    }

    /// <summary>
    /// Добавление массива элементов
    /// </summary>
    /// <param name="element"></param>
    public void Add(int[] element)
    {
        if (_length < element.Length)
        {
            _length = (_length + element.Length) * 2;
        }

        _length *= 2;
        Array.Resize(ref _array, _length);
        for (int i = 0; i < element.Length; i++)
        {
            _array[i + Count] = element[i];
            Count++;
        }
    }

    /// <summary>
    /// Добавление элемента по индексу
    /// </summary>
    /// <param name="element"></param>
    public void Add(int element, int index)
    {
        _length *= 2;
        Array.Resize(ref _array, _length);

        var elementToSave = _array[index];
        _array[index] = element;

        for (int i = index + 1; i <= Count; i++)
        {
            var tmp = _array[i];
            _array[i] = elementToSave;
            elementToSave = tmp;
        }

        Count++;
    }

    /// <summary>
    /// Добавление массива элементов по индексу
    /// </summary>
    /// <param name="element"></param>
    public void Add(int[] element, int index)
    {
        if (_length < element.Length)
        {
            _length = (_length + element.Length) * 2;
        }

        _length *= 2;
        Array.Resize(ref _array, _length);
        int[] tmpArr = new int[Count - index  ];

        for (int i = 0, k = index;  i < tmpArr.Length; i++, k++)
        {
            tmpArr[i] = _array[k];
        }
        
        for (int i = 0, k = index ; k < element.Length+index && i < _length; k++, i++)
        {
            _array[k] = element[i];
        }

        for (int i = index + element.Length,  k = 0; k<tmpArr.Length &&  i < index + element.Length + tmpArr.Length ; k++, i++)
        {
            _array[i] = tmpArr[k];
            Count++;
        }
    }

    /// <summary>
    /// Сортирова любым алгоритмом (кроме пузырьковой)
    /// </summary>
    /// <param name="element"></param>
    public void Sort()
    {
    }

    public void Print()
    {
        Console.WriteLine($"CountElement: {Count}");
        Console.WriteLine(String.Join("; ", _array));
    }
}