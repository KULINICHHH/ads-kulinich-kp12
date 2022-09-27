using static System.Console;

public enum status
{
    empty,
    ocupied,
    removed
}
class GateHash
{
    int a = 3;
    int b = 6;
    static int arrLen = 5;

    public struct Gate
    {
        public int gate;
        public string flightCode;
        public status status = status.empty;
        public Gate(int gate, string flightCode)
        {
            this.gate = gate;
            this.flightCode = flightCode;
        }
    }
    Gate[] gates = new Gate[arrLen];

    private void arrResize()
    {
        arrLen = arrLen * 2;
        Gate[] arrRs = new Gate[arrLen];
        for (int i = 0; i < gates.Length; i++)
        {
            if (gates[i].status == status.ocupied)
            {
                InsertRes(gates[i].gate, gates[i].flightCode , arrRs);
            }
        }
        gates = arrRs;
    }

    public void InsertRes(int gate, string flightCode, Gate[] arrRs)
    {
        long index = Hash(flightCode);
        Gate hash = new Gate();
        hash.flightCode = flightCode;
        hash.gate = gate;
        hash.status = status.ocupied;
        while (arrRs[index].status == status.ocupied)
        {
            index = (index + 1) % arrLen;
        }
        arrRs[index] = hash;
    }

    public void Insert(int gate, string flightCode)
    {
        float loadness = gates.Length / arrLen;
        if (loadness >= 0.8)
        {
            arrResize();
        }
        long index = Hash(flightCode);
        Gate hash = new Gate();
        hash.flightCode = flightCode;
        hash.gate = gate;
        hash.status = status.ocupied;
        while (gates[index].status == status.ocupied)
        {
            index = (index + 1) % arrLen;
        }
        gates[index] = hash;
    }

    public Gate Find(int key)
    {
        long index = Hash(key.ToString());
        while (gates[index].status != status.empty)
        {
            if (gates[index].status == status.ocupied && key == gates[index].gate)
            {
                return gates[index];
            }
            index = (index + 1) % arrLen;
        }
        return new Gate();
    }

    public void Erase(int key)
    {
        long index = Hash(key.ToString());
        while (gates[index].status != status.empty)
        {
            if (gates[index].status == status.ocupied && key == gates[index].gate)
            {
                gates[index].status = status.removed;
            }
            index = (index + 1) % arrLen;
        }
    }

    private long Hash(string key)
    {
        long summHash = 0;
        for (int i = 0; i < key.Length; i++)
        {
            summHash += key[i] * a * b;
        }
        return summHash % gates.Length;
    }
}

class HashMap
{
    int a = 3;
    int b = 6;
    static int arrLen = 11;

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
        public int isDelayed = 0000;
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

    private void arrResize()
    {
        arrLen = arrLen * 2;
        HashSigment[] arrRs = new HashSigment[arrLen];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].status == status.ocupied)
            {
                InsertRes(arr[i].flightCode, arr[i].aeroportOfArival, arr[i].gate, arr[i].departureTime, arr[i].isDelayed, arrRs);
            }
        }
        arr = arrRs;
    }

    public void InsertRes(string flightCode, string aeroportOfArival, string gate, TimeDate departureTime, int isDelayed, HashSigment[] arrRs)
    {
        long index = Hash(flightCode);
        HashSigment hash = new HashSigment();
        hash.flightCode = flightCode;
        hash.aeroportOfArival = aeroportOfArival;
        hash.gate = gate;
        hash.departureTime = departureTime;
        hash.isDelayed = isDelayed;
        hash.status = status.ocupied;
        while (arrRs[index].status == status.ocupied)
        {
            index = (index + 1) % arrLen;
        }
        arrRs[index] = hash;
    }

    public void Insert(string flightCode, string aeroportOfArival, string gate, TimeDate departureTime, int isDelayed)
    {
        float loadness = arr.Length / arrLen;
        if (loadness >= 0.8)
        {
            arrResize();
        }
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
                index = (index + 1) % arrLen;
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



class Program
{
    static void Main()
    {

    }
}

