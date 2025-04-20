using System;
using System.Media;
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
            AudioGreeting();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Cybersecurity Awareness Bot Active.");
            Console.ResetColor();

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
    }
}
