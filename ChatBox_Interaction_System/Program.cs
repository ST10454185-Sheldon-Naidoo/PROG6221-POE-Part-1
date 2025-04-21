using System;
using System.Media;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace ChatBox_Interaction_System
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            ShowASCIIImage();
            chatbox_greeting();
            AudioGreeting();


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Cybersecurity Awareness Bot Active.");
            Console.ResetColor();

            chatbox_interaction();

            Console.ReadKey();
        }

        static void ShowASCIIImage()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Form imageForm = new Form
                {
                    Text = "Cybersecurity Awareness Bot",
                    ClientSize = new Size(600, 200),
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(@"Resources\ascii-text-art.jpg"),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill
                };

                imageForm.Controls.Add(pictureBox);
                Application.Run(imageForm);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Image load error: " + ex.Message);
            }
            
        }


        static void AudioGreeting()
        {
            try
            {
                SoundPlayer audio = new SoundPlayer(@"Resources\Chatbot_Greeting.wav");
                audio.Load();
                audio.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio playback error: " + ex.Message);
            }
        }

        static void chatbox_greeting()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Cybersecurity Bot!");
            Console.ResetColor();

            Console.Write("\nPlease enter your name: ");
            string userName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello, {userName}! 😊 I'm here to help you stay safe online.");
            Console.ResetColor();

        }

        static void chatbox_interaction()
        {
            Console.WriteLine("\n(Ask a question or type 'exit' to quit)");

            while (true)
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                string input = Console.ReadLine()?.Trim().ToLower();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: You didn't type anything. Please enter a question or type 'exit.");
                    Console.ResetColor();
                    continue;
                }

                if (input == "exit")
                {
                    Console.WriteLine("\nGoodbye! Stay safe online.");
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                switch (input)
                {
                    case "how are you?":
                        Console.WriteLine("Bot: I'm functioning at 100%! Ready to help you stay secure.");
                        break;
                    case "what's your purpose?":
                        Console.WriteLine("Bot: My purpose is to raise awareness about cybersecurity and help you avoid online threats.");
                        break;
                    case "qhat can i ask you about?":
                        Console.WriteLine("Bot: You can ask about password safety, phishing or safe browsing tips.");
                        break;
                    case "password safety":
                        Console.WriteLine("Bot: Use long, unique passwords and enable two-factor authentication wherever possible.");
                        break;
                    case "phishing":
                        Console.WriteLine("Bot: Never click on suspicious links or attachments. Always verify the sender!");
                        break;
                    case "safe browsing":
                        Console.WriteLine("Bot: Keep your browser up to date and avoid untrusted websites.");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bot: I didn't quite understand that. Could your rephrase?");
                        break;
                }
                Console.ResetColor();
            }
        }
    }
}
