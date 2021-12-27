using System;

namespace Lab4
{
    public class DLNode
    {
        public class Node
        {
            public int data;
            public Node next;
            public Node prev;

            public Node(int data)
            {
                this.data = data;
            }

            public Node(int data, Node next, Node prev)
            {
                this.data = data;
                this.next = next;
                this.prev = prev;
            }
        }

        public Node tail;
        public DLNode(int data)
        {
            tail = new Node(data);
            tail.next = tail;
            tail.prev = tail;
        }

        public void AddLast(int data)
        {
            Node current = new Node(data);
            current.prev = tail;
            current.next = tail.next;
            tail.next = current;
            tail = current;
        }

        public void AddFirst(int data)
        {
            Node current = new Node(data);
            current.prev = tail;
            current.next = tail.next;
            tail.next = current;
            current.next.prev = current;
        }

        public void DeleteFirst()
        {
            tail.next = tail.next.next;
            tail.next.prev = tail;

        }

        public void DeleteLast()
        {
            tail.prev.next = tail.next;
            tail = tail.prev;
        }

        public void DeleteAtPosition(int pos)
        {
            Node current = tail.next;
            for (int i = 1; i < pos; i++)
            {
                current = current.next;
            }
            current.next.prev = current.prev;
            current.prev.next = current.next;
            current.next = null;
            current.prev = null;
        }

        public void AddAtPosition(int data, int pos)
        {
            Node current = new Node(data);
            Node temp = tail.next;
            for (int i = 1; i < pos; i++)
            {
                temp = temp.next;
            }
            current.next = temp;
            current.prev = temp.prev;
            temp.prev.next = current;
            temp.prev = current;
        }

        public void AddAfterMin(int data)
        {
            Node current, stop_current, temp, min;
            current = tail.next;
            stop_current = current.next;
            int count = 0, part;
            do
            {
                count++;
                current = current.next;
            }
            while (current.next != stop_current);
            part = (count / 2)+1;
            temp = tail;
            min = tail;
            do
            {
                if (min.data < temp.data)
                {
                    min = temp;
                }
                temp = temp.prev;
                count--;
            }
            while (count > part);
            Node newNode = new Node(data);
            newNode.next = temp;
            newNode.prev = temp.prev;
            temp.prev.next = newNode;
            temp.prev = newNode;
        }

        public void Print()
        {
            Node current, stop_current;
            current = tail.next;
            stop_current = current.next;
            Console.Write("Current list: ");
            do
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            while (current.next != stop_current);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть перший елемент");
            int n = int.Parse(Console.ReadLine());
            DLNode list = new DLNode(n);
            bool mn = true;
            int data, pos;
            do
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Для того, щоб додати елемент у початок введіть 1;" +
                "\nДля того, щоб додати елемент у кінець списку введіть 2;" +
                "\nДля того, щоб видалити перший елемент введіть 3;" +
                "\nДля того, щоб видалити останній елемент введіть 4;" +
                "\nДля того, щоб додати елемент на певну позицію натисніть 5;" +
                "\nДля того, щоб видалити елемент з певної позиції натисніть 6;" +
                "\nДля того, щоб додати елемент після найменшого у другій половині натисніть 7;" +
                "\nЩоб закрити програму введыть 0");
                n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Введіть елемент");
                        data = int.Parse(Console.ReadLine());
                        list.AddFirst(data);
                        list.Print();
                        break;
                    case 2:
                        Console.WriteLine("Введіть елемент");
                        data = int.Parse(Console.ReadLine());
                        list.AddLast(data);
                        list.Print();
                        break;
                    case 3:
                        list.DeleteFirst();
                        list.Print();
                        break;
                    case 4:
                        list.DeleteLast();
                        list.Print();
                        break;
                    case 5:
                        Console.WriteLine("Введіть елемент");
                        data = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введіть позицію");
                        pos = int.Parse(Console.ReadLine());
                        list.AddAtPosition(data, pos);
                        list.Print();
                        break;
                    case 6:
                        Console.WriteLine("Введіть позицію");
                        pos = int.Parse(Console.ReadLine());
                        list.DeleteAtPosition(pos);
                        list.Print();
                        break;
                    case 7:
                        Console.WriteLine("Введіть елемент");
                        data = int.Parse(Console.ReadLine());
                        list.AddAfterMin(data);
                        list.Print();
                        break;
                    case 0:
                        mn = false;
                        break;
                }
            }
            while (mn == true);
        }
    }
}
