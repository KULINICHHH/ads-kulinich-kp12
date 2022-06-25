using System;

class Program
{
    static void Main()
    {
        ArrayLine<string> line = new ArrayLine<string>(1);
        while (true)
        {
            Console.WriteLine("Input new string: (To first out write 'out'. To quit write 'quit' )");
            string temp = Console.ReadLine();
            if (temp == "quit")
                break;
            if (temp == "out")
            {
                line.OutLine();
                line.WriteArray();
            }
            else
            {
                line.InLine(temp);
                line.WriteArray();
            }
            
            
        }
    }
}

public class ArrayLine<STR>
{
    STR[] line;
    int head;
    int tail;
    int lenght;
    int _lineSize;

    public ArrayLine(int lineSize)
    {
        line = new STR[lineSize];
        _lineSize = lineSize;
        head = lineSize - 1;
    }

    public bool isEmpty
    {
        get { return lenght == 0; }
    }

    public bool isFull
    {
        get { return lenght == _lineSize; }
    }

    private int Next(int pos)
    {
        return (pos + 1) % _lineSize;
    }

    public void OutLine()
    {
        if (isEmpty)
        {
            Console.WriteLine("Line is empty");
        }
        else
        {
            for (int i = 0; i < lenght; i++)
            {
                line[i] = line[i+1];
            }
            line[head] = default(STR);
            head--;
            lenght--;
        }
    }
    
    public void InLine(STR toAdd)
    {
        //head = Next(head);
        //line[head] = toAdd;
        if (isFull)
        {
            Console.WriteLine("Line is full, doubling it's size");
            _lineSize *= 2;
            lenght++;
            Array.Resize(ref line, _lineSize);

        }
            
        else
            lenght++;
        head = Next(head);
        line[head] = toAdd;
    }

    public void WriteArray()
    {
        Console.WriteLine("Current line: ");
        foreach (var line in line)
        {
            if (line != null)
                Console.Write(line + "\n");
        }
    }
}
