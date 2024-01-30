using CoreTest;
using System.Runtime.InteropServices;

[DllImport("BinCore.dll")]
static extern bool EmptyRecycleBin();

[DllImport("BinCore.dll")]
static extern bool IsRecycleBinEmpty();

[DllImport("BinCore.dll")]
static extern void GetRecycleBinStatus(ref Int64 itemCount, ref Int64 totalSize);

void ClearBin() {
    EmptyRecycleBin();
}

bool IsBinEmpty() {
    return IsRecycleBinEmpty();
}

BinStatus GetBinStatus() {
    Int64 itemCount = 0;
    Int64 totalSize = 0;
    GetRecycleBinStatus(ref itemCount, ref totalSize);

    return new BinStatus {
        ItemCount = itemCount,
        TotalSize = totalSize
    };
}

void Run() {
    bool isBinEmpty = IsBinEmpty();
    Console.WriteLine($"Is bin empty? {isBinEmpty}");
    if(!isBinEmpty) {
        BinStatus binStatus = GetBinStatus();
        Console.WriteLine($"Bin status: {binStatus.ItemCount} items, {binStatus.TotalSize} bytes");

        ClearBin();
        Console.WriteLine("Bin cleared");
    }

}

Run();