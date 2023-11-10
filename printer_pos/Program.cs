using ESC_POS_USB_NET.Printer;

namespace printer_twitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String printerName = "POS58 Printer";
            String text = "You can print with this printer!";

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--printer":
                        if (args.Length > i + 1 && args[i + 1].Length > 0)
                        {
                            printerName = args[i + 1];
                            i++;
                            break;
                        } // Missing argument?
                        break;
                    default:
                        text = args[i];
                        break;
                }
            }

            Printer printer = new Printer(printerName, "ascii"); 

            printer.Append(text);
            printer.FullPaperCut();
            printer.PrintDocument();
        }

        static void Help()
        {
            Console.WriteLine("Arguments: --printer \"PrinterName\" - Uses the device named \"PrinterName\" to print (Default:POS58 Printer)");
        }
    }
}
