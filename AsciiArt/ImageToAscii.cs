using System;
using System.Drawing;

namespace AsciiArt
{
    static class ImageToAscii
    {
        static char[] asciiGrayscale =
        {
            ' ',
            '.',
            ':',
            '*',
            'T',
            'X',
            '#',
            '0',
            '@'
        };

        public static void DrawToFile(string pictureFilename, string outputFilename)
        {
            outputFilename += ".txt";

            var basePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var pictureFilepath = System.IO.Path.Combine(basePath, pictureFilename);
            var outputFilepath = System.IO.Path.Combine(basePath, outputFilename);

            if(!System.IO.File.Exists(outputFilepath))
            {
                var image = GetBitmap(pictureFilepath);
                var imageString = ConvertToAsciiWhole(image);

                System.IO.File.WriteAllText(outputFilepath, imageString);
            }
            else
            {
                throw new Exception(string.Format("File {0} already exists. Cannot write over it.", outputFilename));
            }
        }

        public static void DrawToConsole(string pictureFilename)
        {
            var basePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var pictureFilepath = System.IO.Path.Combine(basePath, pictureFilename);

            var image = GetBitmap(pictureFilepath);
            var imageString = ConvertToAsciiWhole(image);

            Console.BufferWidth = Math.Max(image.Width + 1, Console.BufferWidth);
            Console.BufferHeight = Math.Max(image.Height + 1, Console.BufferHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("");
            Console.WriteLine(imageString);

            Console.ResetColor();
        }


        public static string ConvertToAsciiWhole(Bitmap image)
        {
            int total = image.Width * image.Height;
            int current = 0;

            int cursorX = Console.CursorLeft;
            int cursorY = Console.CursorTop;

            string imageString = "";
            for (int x = 0; x < image.Height - 1; x += 2)
            {
                for (int y = 0; y < image.Width; y++)
                {
                    Color pixelColorTop = image.GetPixel(y, x);
                    Color pixelColorBottom = image.GetPixel(y, x + 1);

                    double pixelTopBrightness = pixelColorTop.GetBrightness();
                    double pixelBottomBrightness = pixelColorBottom.GetBrightness();

                    double averageBrightness = (pixelTopBrightness + pixelBottomBrightness) / 2;

                    imageString += asciiGrayscale[Math.Min((int)(9 - 9 * averageBrightness), 8)];
                    current = x * image.Width + y;
                }
                imageString += "\n\r";
                Console.SetCursorPosition(cursorX, cursorY);
                Console.WriteLine("     " + (int)(100 * ((float)current / total)) + "%");
            }
            Console.SetCursorPosition(cursorX, cursorY);
            Console.WriteLine("     " + 100 + "%");

            return imageString;
        }

        public static Bitmap GetBitmap(string pictureFilepath)
        {
            Bitmap image;

            try
            {
                image = new Bitmap(pictureFilepath);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Could not find image {0}.", pictureFilepath), e);
            }

            return image;
        }
    }
}
