using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

class Program
{
    static string lastresult = "";
    static string ans = "";
    static char color = 'b';

    static string GetBestMove(string fen)
    {
        // Path to the Stockfish executable
        string stockfishPath = @"C:\stockfish\stockfish-windows-x86-64-avx2.exe";

        // Create a process to run Stockfish
        Process stockfishProcess = new Process();
        stockfishProcess.StartInfo.FileName = stockfishPath;
        stockfishProcess.StartInfo.RedirectStandardInput = true;
        stockfishProcess.StartInfo.RedirectStandardOutput = true;
        stockfishProcess.StartInfo.UseShellExecute = false;
        stockfishProcess.StartInfo.CreateNoWindow = true;

        stockfishProcess.Start();

        // Send the FEN to Stockfish
        stockfishProcess.StandardInput.WriteLine("uci"); // Initialize UCI protocol
        stockfishProcess.StandardInput.WriteLine("isready"); // Check if Stockfish is ready
        stockfishProcess.StandardInput.WriteLine("setoption name Threads value 16"); // Check if Stockfish is ready
        stockfishProcess.StandardInput.WriteLine($"position fen {fen}"); // Set the position
        stockfishProcess.StandardInput.WriteLine("go movetime 500"); // Calculate the best move in 1 second

        // Read the best move from Stockfish
        string bestMove = "";
        while (!stockfishProcess.StandardOutput.EndOfStream)
        {
            string line = stockfishProcess.StandardOutput.ReadLine();
            if (line.StartsWith("bestmove"))
            {
                bestMove = line; //line.Split(' ')[1];
                break;
            }
        }

        stockfishProcess.Kill(); // Terminate Stockfish process

        return bestMove;
    }

    static void capture_and_advise()
    {
        // Set the coordinates of the top-left and bottom-right corners
        int startX = 201, startY = 152;
        int endX = 1009, endY = 960;

        // Calculate the width and height of the area to capture
        int width = endX - startX;
        int height = endY - startY;


        string result = "";

        // Create a bitmap to store the screenshot
        using (Bitmap screenshot = new Bitmap(width, height))
        {
            // Create a Graphics object to copy from the screen
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                // Capture the screen area and copy it into the bitmap
                g.CopyFromScreen(startX, startY, 0, 0, new Size(width, height));
            }

            // Save the full screenshot to D:\screenshot.png
            screenshot.Save(@"D:\screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
            // Console.WriteLine("Full screenshot saved as D:\\screenshot.png.");

            // Set the grid size to 101x101
            int gridSize = 101;
            for (int row = 0; row < height / gridSize; row++)
            {
                for (int col = 0; col < width / gridSize; col++)
                {
                    // Calculate the bounds of the current 101x101 grid section
                    int x = col * gridSize;
                    int y = row * gridSize;
                    int gridWidth = gridSize;
                    int gridHeight = gridSize;

                    // Ensure the grid section doesn't exceed the image bounds
                    if (x + gridWidth > width) gridWidth = width - x;
                    if (y + gridHeight > height) gridHeight = height - y;

                    // Create a new bitmap for the current 101x101 square
                    using (Bitmap gridSection = screenshot.Clone(new Rectangle(x, y, gridWidth, gridHeight), screenshot.PixelFormat))
                    {
                        // Count the number of pixels that have RGB values in the range [240, 260]
                        int count = 0;
                        int count2 = 0;

                        for (int i = 0; i < gridWidth; i++)
                        {
                            for (int j = 0; j < gridHeight; j++)
                            {
                                // Get the pixel color
                                Color pixelColor = gridSection.GetPixel(i, j);

                                // Check if R, G, B values are in the range [240, 260]
                                if (pixelColor.R >= 240 && pixelColor.R <= 260 &&
                                    pixelColor.G >= 240 && pixelColor.G <= 260 &&
                                    pixelColor.B >= 240 && pixelColor.B <= 260)
                                {
                                    count++;
                                }

                                if (pixelColor.R >= 90 && pixelColor.R <= 94 &&
                                    pixelColor.G >= 87 && pixelColor.G <= 91 &&
                                    pixelColor.B >= 85 && pixelColor.B <= 89)
                                {
                                    count2++;
                                }
                            }
                        }

                        // Print the count of pixels that meet the condition for the current square
                        // Console.WriteLine($"Square [{row},{col}] - Pixels in range 240-260 (R,G,B): {count} {count2}");
                        if (count == 1301) result += 'P';
                        else if (count == 1986) result += 'R';
                        else if (count == 2280) result += 'N';
                        else if (count == 1899) result += 'B';
                        else if (count == 2459) result += 'Q';
                        else if (count == 2811) result += 'K';
                        else if (count2 == 1127) result += 'p';
                        else if (count2 == 1725) result += 'r';
                        else if (count2 == 1943) result += 'n';
                        else if (count2 == 1559) result += 'b';
                        else if (count2 == 2154) result += 'q';
                        else if (count2 == 2500) result += 'k';
                        else if (count + count2 == 0)
                        {
                            if (result.Length > 0 && result[result.Length - 1] >= '1' && result[result.Length - 1] <= '8')
                            {
                                char nextChar = (char)(result[result.Length - 1] + 1);
                                string result2 = result.Substring(0, result.Length - 1) + nextChar;
                                result = result2;
                            }
                            else result += '1';
                        }
                    }
                }

                if (row < width / gridSize - 1) result += '/';
            }
        }

        if (color == 'b')
        {
            string[] rows = result.Split('/');

            // Step 2: Reverse the rows
            Array.Reverse(rows);

            // Step 3: Join them back together with '/'
            string flippedPiecePlacement = string.Join("/", rows);
            result = flippedPiecePlacement;
        }


        if (lastresult != result)
        {
            Console.WriteLine("");
            Console.WriteLine("Finished: result " + result + " " + color);

            lastresult = result;
            ans = GetBestMove(result);
            Console.WriteLine("                      :  " + ans);
            Console.WriteLine("");
        }
    }

    static void Main()
    {
        // Wait for 5 seconds before starting the capture
        Console.WriteLine("Waiting for 5 seconds...");
        Thread.Sleep(5000);

        while (true)
        {
            if (ans.Length == 4)
            {
                Thread.Sleep(1000);
                // Console.WriteLine("sleep 1000");
            }
            else
            {
                Thread.Sleep(100);
                // Console.WriteLine("sleep 100");
            }
            capture_and_advise();
        }
    }
}
