using System;
using System.Media;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;


namespace ChatBox_Interaction_System
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            // Displays the ASCII image
            ShowASCIIImage();

            // Displays the welcome message
            WelcomeTitle();

            // Plays the audio greeting with the synchronized text
            AudioGreeting();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Cybersecurity Awareness Bot is now active.");
            Console.ResetColor();

            // User input for the name of the user
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

                // Set up of a new windows form for the image to display separately from the main application
                Form imageForm = new Form
                {
                    Text = "Cybersecurity Awareness Bot",
                    ClientSize = new Size(600, 200),
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false
                };

                // Setting up the loading and configuration of the ASCII image
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

            // Thread to allow playback of audio
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

            // Thread to allow playback of text
            Thread textThread = new Thread(() =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                TextEffect(greeting, 64);
                Console.ResetColor();
            });

            // Thread is synchronized for both text and audio
            audioThread.Start();
            textThread.Start();

            audioThread.Join();
            textThread.Join();
        }

        static void WelcomeTitle()
        {
            // Welcome message for the application
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            PrintDivider();
            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot");
            PrintDivider();

            Console.ResetColor();
        }

        static string AskUserName()
        {
            // Method that takes the input name of the user
            Console.Write("\nWhat is your name? ");
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            TextEffect($"Nice to meet you, {name}! I am available to assist you in staying safe online.");
            Console.ResetColor();
            return name;
        }

        static void ChatboxInteraction(string userName)
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("\nYou can ask chatbot any of the following questions.");
            Console.WriteLine("Type any of the questions below: ");
            Console.WriteLine("\n- How are you?");
            Console.WriteLine("- What's your purpose?");
            Console.WriteLine("- What can I ask you about?");
            Console.WriteLine("- Can you help me?");
            Console.WriteLine("- Password safety");
            Console.WriteLine("- Phishing");  
            Console.WriteLine("- Safe browsing");
            Console.WriteLine("\nType 'exit' to close the application.");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                string input = Console.ReadLine()?.Trim().ToLower();    // Each input value will be change to lowercase so that any input both upper or lower case will be accepted
                Console.ResetColor();

                // If statements are used for the exitting of the application
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bot: You didn't type anything. Please re-enter a question or type 'exit'.");
                    Console.ResetColor();
                    continue;
                }

                if (input == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TextEffect("\nGoodbye! Stay safe online, " + userName + "!");
                    Console.ResetColor();
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Green;

                // Switch case that allows the chatbot to respond to each question
                switch (input)
                {
                    case "how are you":
                    case "how are you?":
                        TextEffect("Bot: I am fully operational and ready to assist you.");
                        break;


                    case "what is your purpose":
                    case "what is your purpose?":
                    case "what's your purpose":
                    case "what's your purpose?":
                    case "whats your purpose":
                    case "whats your purpose?":
                        TextEffect("Bot: My purpose is to raise cybersecurity awareness, help in avoiding online threats and protect you as you browse online.");
                        break;


                    case "what can I ask you about":
                    case "what can I ask you about?":
                        TextEffect("Bot: You can ask me about information based on password safety, phishing or safe browsing tips.");
                        break;


                    case "can you help me":
                    case "can you help me?":
                        TextEffect("Bot: Of course. My primary design is to spread awareness about cybersecurity and assist you in browsing online safely.");
                        break;


                    case "password safety":
                    case "password safety?":
                        TextEffect("Bot: Try to use long, unique passwords to reduce password theft and enable two-factor authentication to enhance your password security.");
                        break;


                    case "phishing":
                    case "phishing?":
                        TextEffect("Bot: Be cautious of any unsolicited messages that are sent directly to you. Avoid clicking on any suspicious links.");
                        break;


                    case "safe browsing":
                    case "safe browsing?":
                        TextEffect("Bot: Regularly update your web browser with new patches and avoid browsing through unfamiliar/untrusted websites.");
                        break;


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        TextEffect("Bot: I didn't quite understand that. Could you rephrase?");
                        break;
                }
                Console.ResetColor();
            }
        }

        static void PrintDivider()
        {
            Console.WriteLine(new string('=', 60));
        }

        // Method to allow the text to run automatically
        static void TextEffect(string message, int delay = 30)
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
