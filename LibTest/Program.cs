using System.Runtime.InteropServices;

[DllImport("BinCore.dll")]
static extern bool IsRecycleBinEmpty();

bool IsEmpty = IsRecycleBinEmpty();
Console.WriteLine($"Is the recycle bin empty? {IsEmpty}");