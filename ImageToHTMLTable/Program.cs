using System.Text;
using System.Drawing;
using System.IO;

namespace ImageToHTMLTable
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                System.Console.WriteLine("2 params required: script <source path> <output destination path>");
                return;
            }
            Bitmap image = new Bitmap(@args[0]);
            int w = image.Width;
            int h = image.Height;
            StringBuilder sb = new StringBuilder();
            Color pixel = new Color();
            sb.AppendLine("<table>");
            for (int i = 0; i < h; ++i)
            {
                sb.AppendLine("\t<tr>");
                for (int j = 0; j < w; ++j)
                {
                    pixel = image.GetPixel(j, i);
                    sb.AppendLine("\t\t<td style=\"background-color:" + GetHex(pixel) + "\"></td>");
                }
                sb.AppendLine("\t</tr>");
            }
            sb.AppendLine("</table>");

            File.WriteAllText(@args[1], sb.ToString());
        }

        // Converts argb to hex
        static string GetHex(Color argb)
        {
            return string.Format("#{1:X2}{2:X2}{3:X2}", argb.A, argb.R, argb.G, argb.B);
        }
    }
}