using System.Runtime.InteropServices;

[DllImport("BinCore.dll")]
static extern bool IsRecycleBinEmpty();

[DllImport("BinCore.dll")]
static extern bool GetRecycleBinStatus(ref Int64 itemCount, ref Int64 total);

bool IsEmpty = IsRecycleBinEmpty();
Console.WriteLine($"Is the recycle bin empty? [{IsEmpty}]");

Int64 itemCount = 0;
Int64 totalSize = 0;

GetRecycleBinStatus(ref itemCount, ref totalSize);
Console.WriteLine($"Items in Recycle Bin: {itemCount}, Total Size: {totalSize} KB");