using System;
using System.Media;
using System.Threading;
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
            ClearAndShowWelcome();
            //chatbox_greeting();
            AudioGreeting();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Cybersecurity Awareness Bot Active.");
            Console.ResetColor();

            string userName = AskUserName();
            ChatboxInteraction(userName);

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
            string greeting = "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.";
            SoundPlayer audio = new SoundPlayer(@"Resources\Chatbot_Greeting.wav");

            Thread audioThread = new Thread(() =>
            {
                try
                {
                    //audio.Load();
                    audio.PlaySync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Audio playback error: " + ex.Message);
                }
            });

            /*
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
            */

            Thread textThread = new Thread(() =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                TypeWithEffect(greeting, 62);
                Console.ResetColor();
            });

            audioThread.Start();
            textThread.Start();

            audioThread.Join();
            textThread.Join();
        }

        static void ClearAndShowWelcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintDivider();
            TypeWithEffect("Welcome to the Cybersecurity Awareness Bot");
            PrintDivider();
            Console.ResetColor();

        }

        static string AskUserName()
        {
            Console.Write("\nWhat's your name? ");
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            TypeWithEffect($"Nice to meet you, {name}! Let's stay safe online together.");
            Console.ResetColor();
            return name;
        }

        /*
        static void chatbox_greeting()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Cybersecurity Bot!");
            Console.ResetColor();

            Console.Write("\nPlease enter your name: ");
            string userName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello, {userName}! I'm here to help you stay safe online.");
            Console.ResetColor();
        }
        */

        static void ChatboxInteraction(string userName)
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("\nYou can ask chatbot any question.");
            Console.WriteLine("\n(Type questions like 'How are you?', 'Phishing', 'Safe browsing' or type 'exit' to quit)");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                string input = Console.ReadLine()?.Trim().ToLower();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: You didn't type anything. Please re-enter a question or type 'exit.");
                    Console.ResetColor();
                    continue;
                }

                if (input == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nGoodbye! Stay safe online, " + userName + "!");
                    Console.ResetColor();
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                switch (input)
                {
                    case "How are you":
                    case "How are you?":
                    case "how are you":
                    case "how are you?":
                        TypeWithEffect("Bot: I'm functioning at full capacity and ready to provide you my assistance!");
                        break;


                    case "What's your purpose":
                    case "What's your purpose?":
                    case "what's your purpose":
                    case "what's your purpose?":
                    case "whats your purpose":
                    case "whats your purpose?":
                        TypeWithEffect("Bot: My purpose is to raise cybersecurity awareness, help in avoiding online threats and protect you as you browse online.");
                        break;


                    case "What can I ask you about":
                    case "What can I ask you about?":
                    case "What can i ask you about":
                    case "What can i ask you about?":
                    case "what can I ask you about":
                    case "what can I ask you about?":
                    case "what can i ask you about":
                    case "what can i ask you about?":
                        TypeWithEffect("Bot: You can ask about password safety, phishing or safe browsing tips.");
                        break;


                    case "Password Safety":
                    case "Password Safety?":
                    case "Password safety":
                    case "Password safety?":
                    case "password safety":
                    case "password safety?":
                        TypeWithEffect("Bot: Use long, unique passwords and enable two-factor authentication wherever possible.");
                        break;


                    case "Phishing":
                    case "Phishing?":
                    case "phishing":
                    case "phishing?":
                        TypeWithEffect("Bot: Be cautious of unsolicited messages. Don't click suspicious links.");
                        break;


                    case "Safe Browsing":
                    case "Safe Browsing?":
                    case "Safe browsing":
                    case "Safe browsing?":
                    case "safe browsing":
                    case "safe browsing?":
                        TypeWithEffect("Bot: Always up your web browser and avoid unfamiliar/untrusted websites.");
                        break;


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypeWithEffect("Bot: I didn't quite understand that. Could your rephrase?");
                        break;
                }
                Console.ResetColor();
            }
        }

        static void PrintDivider()
        {
            Console.WriteLine(new string('=', 60));
        }

        static void TypeWithEffect(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
    }
}
