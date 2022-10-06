using info_protection_lab_3;

internal class Program
{
    public static void Main(string[] args)
    {
        Coder coder = new Coder();

        coder.Decode(@"3.bmp", @"3.txt");

        coder.Encode(@"14.bmp");
        coder.Decode();
    }
}