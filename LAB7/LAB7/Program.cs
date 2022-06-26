using static System.Console;

class HashMap
{
    int a = 3;
    int b = 6;
    static int arrLen = 27644437;

    public struct TimeDate
    {
        public int year;
        public int month;
        public int day;
        public int time;
        public TimeDate(int year, int month, int day, int time)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.time = time;
        }
    }
    public struct HashSigment
    {
        public string flightCode;
        public string aeroportOfArival;
        public string gate;
        public TimeDate departureTime;
        public int isDelayed;
        public status status = status.empty;

        public HashSigment(string flightCode, string aeroportOfArival, string gate, TimeDate departureTime, int isDelayed)
        {
            this.flightCode = flightCode;
            this.aeroportOfArival = aeroportOfArival;
            this.gate = gate;
            this.departureTime = departureTime;
            this.isDelayed = isDelayed;
        }
    }
    HashSigment[] arr = new HashSigment[arrLen];

    

    public void Insert(string flightCode, string aeroportOfArival, string gate, TimeDate departureTime, int isDelayed)
    {
        long index = Hash(flightCode);
        HashSigment hash = new HashSigment();
        hash.flightCode = flightCode;
        hash.aeroportOfArival = aeroportOfArival;
        hash.gate = gate;
        hash.departureTime = departureTime;
        hash.isDelayed = isDelayed;
        hash.status = status.ocupied;
        while (arr[index].status == status.ocupied)
        {
            index = (index + 1)%arrLen;
        }
        arr[index] = hash;
    }

    public HashSigment Find(string key)
    {
        long index = Hash(key);
        while (arr[index].status != status.empty)
        {
            if (arr[index].status == status.ocupied && key == arr[index].flightCode)
            {
                return arr[index];
            }
            index = (index + 1)%arrLen;
        }
        return new HashSigment();
    }

    public void Erase(string key)
    {
        long index = Hash(key);
        while (arr[index].status != status.empty)
        {
            if (arr[index].status == status.ocupied && key == arr[index].flightCode)
            {
                arr[index].status = status.removed;
            }
            index = (index + 1) % arrLen;
        }
    }

    public void Print()
    {
        
    }

    private long Hash(string key)
    {
        long summHash = 0;
        for (int i = 0; i < key.Length; i++)
        {
            summHash += key[i] * a * b;
        }
        return summHash % arr.Length;
    }
}

public enum status
{
    empty,
    ocupied,
    removed
}

class Program
{
    static void Main()
    {

    }
}

