using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using chessindicator;
using static System.Windows.Forms.AxHost;

static class Program
{
    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

    const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    const uint MOUSEEVENTF_LEFTUP = 0x0004;

    public static RedIconForm redIcon;
    public static BlueIconForm blueIcon;
    public static bool overlay_enabled = true;

    // Path to the Stockfish executable
    public static string stockfishPath = @"C:\stockfish\stockfish-windows-x86-64-avx2.exe";

    public static int starting_position_x = 224;
    public static int starting_position_y = 152;
    public static int chess_board_height_w = 808;

    public static char chess_color = 'w';
    public static string chess_speed = "100";

    public static Form1 f1;

    public static bool my_move = false;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        redIcon = new RedIconForm(new Point(starting_position_x, starting_position_y));
        redIcon.Show();

        // Blue icon at (200, 100)
        blueIcon = new BlueIconForm(new Point(starting_position_x, starting_position_y));
        blueIcon.Show();

        Thread backgroundThread = new Thread(MoveIconsLoop);
        backgroundThread.IsBackground = true;
        backgroundThread.Start();

        Thread backgroundThread2 = new Thread(UrMoveLoop);
        backgroundThread2.IsBackground = true;
        backgroundThread2.Start();

        Thread backgroundThread3 = new Thread(newgameloop);
        backgroundThread3.IsBackground = true;
        backgroundThread3.Start();

        f1 = new Form1();
        f1.Show();
        Application.Run();
    }

    static void newgameloop()
    {
        Console.WriteLine("Waiting for 3 seconds...");
        Thread.Sleep(3000);
        while (true)
        {
            Thread.Sleep(10000);

            if (Program.f1.checkBox5.Checked)
            {
                Rectangle captureArea = new Rectangle(489, 376, 266, 500);

                // Capture the screenshot from the screen
                using (Bitmap screenshot = new Bitmap(266, 500))
                {
                    using (Graphics g = Graphics.FromImage(screenshot))
                    {
                        g.CopyFromScreen(captureArea.Location, Point.Empty, captureArea.Size);
                    }

                    for (int y = 0; y < screenshot.Height; y++)
                    {
                        int greenPixelCount = 0;
                        for (int x = 0; x < screenshot.Width; x++)
                        {
                            Color pixel = screenshot.GetPixel(x, y);

                            bool isMatch = pixel.G >= 180 && pixel.R < 160 && pixel.B < 100;


                            if (isMatch)
                                greenPixelCount++;
                        }

                        // If more than half of the row is green
                        if (greenPixelCount > screenshot.Width / 4 * 3)
                        {
                            Console.WriteLine($"Line {y} is mostly green. ({greenPixelCount} matching pixels)");
                            redIcon?.Invoke(new Action(() =>
                            {
                                var redLocation = new Point(554, y + 92 + 376);

                                ClickAt(redLocation);
                            }));
                            break;
                        }
                    }
                }

                Program.f1.textBox3?.Invoke(new Action(() =>
                {
                    if (my_move) Program.f1.textBox3.Text = "ur move";
                    else Program.f1.textBox3.Text = "";
                }));
            }

        }
    }

    static void UrMoveLoop()
    {
        Console.WriteLine("Waiting for 3 seconds...");
        Thread.Sleep(3000);
        while (true)
        {
            Thread.Sleep(100);
            redIcon?.Invoke(new Action(() =>
            {
                redIcon?.Invalidate();
                blueIcon?.Invalidate();
            }));

            if (Program.f1.checkBox2.Checked)
            {
                int regionWidth = 32;
                int regionHeight = 897;
                int blockHeight = 30;
                double threshold = 50.0;

                int topOutliers = 0;
                int bottomOutliers = 0;

                Rectangle captureArea = new Rectangle(899, 109, regionWidth, regionHeight);

                // Capture the screenshot from the screen
                using (Bitmap screenshot = new Bitmap(regionWidth, regionHeight))
                {
                    using (Graphics g = Graphics.FromImage(screenshot))
                    {
                        g.CopyFromScreen(captureArea.Location, Point.Empty, captureArea.Size);
                    }

                    topOutliers = CountOutliers(screenshot, 0, blockHeight, threshold);
                    bottomOutliers = CountOutliers(screenshot, regionHeight - blockHeight, regionHeight, threshold);
                }

                Console.WriteLine($"Top outlier count: {topOutliers}");
                Console.WriteLine($"Bottom outlier count: {bottomOutliers}");

                my_move = (bottomOutliers > topOutliers + 100);
                Program.f1.textBox3?.Invoke(new Action(() =>
                {
                    if (my_move) Program.f1.textBox3.Text = "ur move";
                    else Program.f1.textBox3.Text = "";
                }));
            }
        }
    }

    static int CountOutliers(Bitmap bmp, int startY, int endY, double threshold)
    {
        int width = bmp.Width;
        int height = endY - startY;

        long totalR = 0, totalG = 0, totalB = 0;
        for (int y = startY; y < endY; y++)
            for (int x = 0; x < width; x++)
            {
                Color pixel = bmp.GetPixel(x, y);
                totalR += pixel.R;
                totalG += pixel.G;
                totalB += pixel.B;
            }

        double avgR = totalR / (double)(width * height);
        double avgG = totalG / (double)(width * height);
        double avgB = totalB / (double)(width * height);

        int count = 0;
        for (int y = startY; y < endY; y++)
            for (int x = 0; x < width; x++)
            {
                Color pixel = bmp.GetPixel(x, y);
                double dist = Math.Sqrt(
                    Math.Pow(pixel.R - avgR, 2) +
                    Math.Pow(pixel.G - avgG, 2) +
                    Math.Pow(pixel.B - avgB, 2));
                if (dist > threshold)
                    count++;
            }

        return count;
    }

    static void MoveIconsLoop()
    {
        // Wait for 5 seconds before starting the capture
        Console.WriteLine("Waiting for 3 seconds...");
        Thread.Sleep(3000);

        while (true)
        {
            if (Program.f1.checkBox2.Checked)
            {
                // my move detection mode
                if (!Program.my_move)
                {
                    Thread.Sleep(100);
                    continue;
                }

                Thread.Sleep(100);
            }
            else
            {
                // default mode, sleep for 1 second if engine gives a result, sleep 0.1 second if not
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

                // slow down this is a bot play
                if (Program.f1.checkBox4.Checked)
                    Thread.Sleep(4000);
            }

            string result = capture_and_advise();

            if (result.Length >= 4 && result[0]>='a' && result[0] <= 'h' && result[2] >= 'a' && result[2] <= 'h' && result[1] >= '1' && result[1] <= '8' && result[3] >= '1' && result[3] <= '8')
            {
                Console.WriteLine();
                
                if (Program.chess_color == 'b')
                {
                    if (overlay_enabled)
                    {
                        redIcon?.Invoke(new Action(() =>
                        {
                            redIcon.Location = new Point((result[0] - 'a') * chess_board_height_w / 8 + starting_position_x + 5, ((result[1] - '1')) * chess_board_height_w / 8 + starting_position_y + 5);
                        }));

                        blueIcon?.Invoke(new Action(() =>
                        {
                            blueIcon.Location = new Point((result[2] - 'a') * chess_board_height_w / 8 + starting_position_x + 5, ((result[3] - '1')) * chess_board_height_w / 8 + starting_position_y + 5);
                        }));

                        redIcon?.Invoke(new Action(() =>
                        {
                            redIcon.Visible = true;
                        }));
                    }

                    if (f1.checkBox3.Checked && my_move || f1.checkBox4.Checked)
                    {
                        // auto move
                        redIcon?.Invoke(new Action(() =>
                        {
                            var redLocation = new Point((result[0] - 'a') * chess_board_height_w / 8 + starting_position_x + 10, ((result[1] - '1')) * chess_board_height_w / 8 + starting_position_y + 10);
                            var blueLocation = new Point((result[2] - 'a') * chess_board_height_w / 8 + starting_position_x + 10, ((result[3] - '1')) * chess_board_height_w / 8 + starting_position_y + 10);

                            ClickAt(redLocation);
                            Thread.Sleep(50); // optional delay

                            // Click blue icon
                            ClickAt(blueLocation);

                            // for pawn promotion
                            if (ans.Length > 4)
                            {
                                Thread.Sleep(50);
                                ClickAt(blueLocation);
                            }
                        }));

                        if (ans.Length > 4)
                            Thread.Sleep(100);
                    }
                }
                else
                {
                    if (overlay_enabled)
                    {
                        redIcon?.Invoke(new Action(() =>
                        {
                            redIcon.Location = new Point((result[0] - 'a') * chess_board_height_w / 8 + starting_position_x + 5, (7 - (result[1] - '1')) * chess_board_height_w / 8 + starting_position_y + 5);
                        }));

                        blueIcon?.Invoke(new Action(() =>
                        {
                            blueIcon.Location = new Point((result[2] - 'a') * 101 + starting_position_x + 5, (7 - (result[3] - '1')) * chess_board_height_w / 8 + starting_position_y + 5);
                        }));

                        redIcon?.Invoke(new Action(() =>
                        {
                            redIcon.Visible = true;
                        }));
                    }

                    if (f1.checkBox3.Checked && my_move || f1.checkBox4.Checked)
                    {
                        // auto move
                        redIcon?.Invoke(new Action(() =>
                        {
                            var redLocation = new Point((result[0] - 'a') * chess_board_height_w / 8 + starting_position_x + 10, (7 - (result[1] - '1')) * chess_board_height_w / 8 + starting_position_y + 10);
                            var blueLocation = new Point((result[2] - 'a') * 101 + starting_position_x + 10, (7 - (result[3] - '1')) * chess_board_height_w / 8 + starting_position_y + 10);

                            ClickAt(redLocation);
                            Thread.Sleep(50); // optional delay

                            // Click blue icon
                            ClickAt(blueLocation);

                            // for pawn promotion
                            if (ans.Length > 4)
                            {
                                Thread.Sleep(50);
                                ClickAt(blueLocation);
                            }
                        }));

                        if (ans.Length > 4)
                            Thread.Sleep(100);
                    }
                }
            }
        }
       }

    static string lastresult = "";
    public static string ans = "";

    static int? ExtractCentipawnScore(string info)
    {
        var match = Regex.Match(info, @"score cp (-?\d+)");
        if (match.Success && int.TryParse(match.Groups[1].Value, out int cp))
        {
            return cp;
        }
        return null;
    }

    static void ClickAt(Point location)
    {
        Cursor.Position = location;
        Thread.Sleep(30); // brief delay to allow positioning
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
    }

    static int? ExtractCentipawnScore2(string info)
    {
        var match = Regex.Match(info, @"score mate (-?\d+)");
        if (match.Success && int.TryParse(match.Groups[1].Value, out int cp))
        {
            return cp;
        }
        return null;
    }

    static double CpToBar(double cp)
    {
        return 1.0 / (1.0 + Math.Exp(-0.004 * cp));
    }

    static string GetBestMove(string fen)
    {
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
        stockfishProcess.StandardInput.WriteLine($"position fen {fen}"); // Set the position
        int speed = 100;
        int.TryParse(chess_speed, out speed);
        if (speed >= 100)
            stockfishProcess.StandardInput.WriteLine("go movetime " + speed); // Calculate the best move in 1 second
        else
            stockfishProcess.StandardInput.WriteLine("go depth " + speed);
        // Read the best move from Stockfish
        string bestMove = "";
        while (!stockfishProcess.StandardOutput.EndOfStream)
        {
            string line = stockfishProcess.StandardOutput.ReadLine();
            f1.AppendToConsole(line + "\n");

            if (line.IndexOf("score cp") >= 0)
            {
                int? cp = ExtractCentipawnScore(line);
                if (cp.HasValue)
                {
                    f1.evalBarValue = CpToBar(cp.Value);
                    f1.panel3.Invalidate();
                    f1.Invoke(new Action(() =>
                    {
                        f1.textBox2.Text = cp.Value.ToString();
                    }));
                }
                else
                {
                    Console.WriteLine("No cp score found.");
                }
            }
            else if (line.IndexOf("score mate") >= 0)
            {
                int? cp = ExtractCentipawnScore2(line);
                if (cp.HasValue)
                {
                    f1.Invoke(new Action(() =>
                    {
                        f1.textBox2.Text = "mate " + cp.Value.ToString();
                    }));
                }
                else
                {
                    Console.WriteLine("No cp score found.");
                }
            }

            if (line.StartsWith("bestmove"))
            {
                bestMove = line.Split(' ')[1]; // Extract the move from the line
                break;
            }
        }

        stockfishProcess.Kill(); // Terminate Stockfish process

        return bestMove;
    }

    static string capture_and_advise()
    {
        // Set the coordinates of the top-left and bottom-right corners
        int startX = starting_position_x, startY = starting_position_y;
        int endX = starting_position_x + chess_board_height_w, endY = starting_position_y + chess_board_height_w;

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
            // screenshot.Save(@"D:\screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
            // Console.WriteLine("Full screenshot saved as D:\\screenshot.png.");

            int gridSize = chess_board_height_w / 8;
            for (int row = 0; row < height / gridSize; row++)
            {
                for (int col = 0; col < width / gridSize; col++)
                {
                    int x = col * gridSize;
                    int y = row * gridSize;
                    int gridWidth = gridSize;
                    int gridHeight = gridSize;

                    // Ensure the grid section doesn't exceed the image bounds
                    if (x + gridWidth > width) gridWidth = width - x;
                    if (y + gridHeight > height) gridHeight = height - y;

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

        int piececount = 0;
        for (int i = 0; i < result.Length; i++) if (result[i] >= 'A' && result[i] <= 'Z' || result[i] >= 'a' && result[i] <= 'z') piececount++;
        if (Program.f1.checkBox6.Checked && piececount >= 30)
        {
            // this looks like start of the game. lets guess black or white.
            string[] rows = result.Split('/');
            string tp = rows[rows.Length - 1];
            int bcount = 0;
            int wcount = 0;
            foreach (char c in tp)
            {
                if (c >= 'A' && c <= 'Z') wcount++;
                if (c >= 'a' && c <= 'z') bcount++;
            }

            if (wcount > bcount)
            {
                Program.chess_color = 'w';
                f1.radioButton1?.Invoke(new Action(() =>
                {
                    f1.radioButton1.Checked = true;
                    f1.radioButton2.Checked = false;
                }));
            }
            else
            {
                Program.chess_color = 'b';
                f1.radioButton1?.Invoke(new Action(() =>
                {
                    f1.radioButton2.Checked = true;
                    f1.radioButton1.Checked = false;
                }));
            }
        }

        if (Program.chess_color == 'b')
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
            Console.WriteLine("Finished: result " + result);

            lastresult = result;
            result = lastresult + " " + Program.chess_color;
            ans = GetBestMove(result);
            Console.WriteLine("                   " + Program.chess_color + ":  " + ans);
            Console.WriteLine("");

            return ans;
        }

        return "";
    }
}
