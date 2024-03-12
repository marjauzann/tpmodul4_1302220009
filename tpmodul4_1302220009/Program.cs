using System;
using System.Collections.Generic;

public class DoorMachine
{
    private DoorState _currentState;

    public DoorMachine()
    {
        _currentState = new LockedState();
    }

    public void Lock()
    {
        _currentState = new LockedState();
        Console.WriteLine("Pintu terkunci");
    }

    public void Unlock()
    {
        _currentState = new UnlockedState();
        Console.WriteLine("Pintu tidak terkunci");
    }

    public void Open()
    {
        _currentState.Open(this);
    }

    public void Close()
    {
        _currentState.Close(this);
    }
}

public abstract class DoorState
{
    public abstract void Open(DoorMachine doorMachine);

    public abstract void Close(DoorMachine doorMachine);
}

public class LockedState : DoorState
{
    public override void Open(DoorMachine doorMachine)
    {
        Console.WriteLine("Pintu tidak dapat dibuka karena terkunci");
    }

    public override void Close(DoorMachine doorMachine)
    {
        Console.WriteLine("Pintu sudah terkunci");
    }
}

public class UnlockedState : DoorState
{
    public override void Open(DoorMachine doorMachine)
    {
        Console.WriteLine("Pintu terbuka");
    }

    public override void Close(DoorMachine doorMachine)
    {
        Console.WriteLine("Pintu tertutup");
        doorMachine.Lock();
    }
}

public class KodePos
{
    private readonly Dictionary<string, string> kodePosDictionary;

    public KodePos()
    {
        kodePosDictionary = new Dictionary<string, string>();
        kodePosDictionary.Add("Batununggal", "40266");
        kodePosDictionary.Add("Kujangsari", "40287");
        kodePosDictionary.Add("Mengger", "40267");
        kodePosDictionary.Add("Wates", "40256");
        kodePosDictionary.Add("Cijaura", "40287");
        kodePosDictionary.Add("Jatisari", "40286");
        kodePosDictionary.Add("Margasari", "40286");
        kodePosDictionary.Add("Sekejati", "40286");
        kodePosDictionary.Add("Kebonwaru", "40272");
        kodePosDictionary.Add("Maleer", "40274");
        kodePosDictionary.Add("Samoja", "40273");
    }

    public string GetKodePos(string kelurahan)
    {
        if (kodePosDictionary.ContainsKey(kelurahan))
        {
            return kodePosDictionary[kelurahan];
        }
        else
        {
            return string.Empty;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var doorMachine = new DoorMachine();
        var kodePos = new KodePos();

        Console.WriteLine("Masukkan nama kelurahan: ");
        var kelurahan = Console.ReadLine();

        var kodePosKelurahan = kodePos.GetKodePos(kelurahan);

        if (string.IsNullOrEmpty(kodePosKelurahan))
        {
            Console.WriteLine("Kelurahan tidak ditemukan!");
        }
        else
        {
            Console.WriteLine($"Kode pos untuk kelurahan {kelurahan} adalah {kodePosKelurahan}");
        }
        // STATE BASED
        Console.WriteLine("Apakah anda ingin mencoba teknik state-based? (Y/N)");
        
        char konfirmasi = Char.ToUpper(Console.ReadKey().KeyChar);

        if (konfirmasi == 'Y')
        {
            Console.WriteLine("\nAnda memilih untuk melanjutkan program.");
            doorMachine.Unlock();
            doorMachine.Open();
            doorMachine.Close();
        }
        else if (konfirmasi == 'N')
        {
            Console.WriteLine("\nAnda memilih untuk tidak melanjutkan program.");
        }
        else
        {
            Console.WriteLine("\nInput tidak valid. Silakan masukkan 'Y' untuk Ya atau 'N' untuk Tidak.");
        }

        Console.WriteLine("Program selesai.");
        Console.ReadLine();
    }
    }
