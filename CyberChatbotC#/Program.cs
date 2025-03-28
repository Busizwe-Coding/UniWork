// See https://aka.ms/new-console-template for more information
//Creating a SIMPLE chatbot that only answers cybersecurity related questions
using System;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Collections.Generic;

namespace simpleChatbot
{
    //A namespace in C# is like a folder
    public class chatBot
    {
        // we make a dictionary for simplicity and cleanliness
        private Dictionary<string, string> _securityResponses = new Dictionary <string, string>
        {
            // Malware related
            { "virus", "Viruses are malicious programs that can replicate and spread to other computers. Use antivirus software and avoid suspicious downloads." },
            { "malware", "Malware refers to any malicious software. Protect yourself by keeping your software updated and using security tools." },
            { "ransomware", "Ransomware encrypts your files and demands payment for their release. Regular backups are your best protection." },
            
            // Network security
            { "firewall", "Firewalls monitor and control incoming and outgoing network traffic. They're essential for network security." },
            { "vpn", "VPNs (Virtual Private Networks) encrypt your internet connection to protect your privacy and security when online." },
            { "wifi", "Secure your WiFi with strong encryption (WPA3 if possible), a unique password, and by disabling remote administration." },
            
            // Authentication
            { "password", "Use strong, unique passwords for each account and consider a password manager to keep track of them." },
            { "2fa", "Two-factor authentication adds an extra security layer by requiring something you know and something you have." },
            { "authentication", "Authentication verifies who you are. Always use strong methods like MFA when available." },
            
            // General security
            { "phishing", "Phishing attacks trick you into revealing sensitive information. Always verify the sender before clicking links or providing data." },
            { "encryption", "Encryption protects data by converting it into a code that only authorized parties can read." },
            { "backup", "Regular backups protect your data from loss due to attacks or hardware failure. Follow the 3-2-1 backup rule." }

        }; // we close dictionaries idk y


        //next we will check for the keyword and return a relevant response
        //this is a response method so we'll call it public string
        public string getResponses(string userInput)
        {
            //case insensitive
            string input = userInput.ToLower();

            // check for nulls
            if (string.IsNullOrWhiteSpace(input))
                return "Hmm... It seems you haven't typed anything. Please ask a cybersecurity question.";

            //we will create responses for generic questions "how are you?"|"what is your purpose?"|"what can i ask you?"
            if (input == "how are you?")
                return "I am well.";

            if (input == "what is your purpose?")
                return "I answer questions about cyber security.";

            if (input == "what can i ask you?")
                return "Anything about cyber security.";
             

            //iterate through the input for a key term
            foreach (var keyword in _securityResponses.Keys)
            {
                if (input.Contains(keyword))
                    return _securityResponses[keyword];
            }

            //default response
            return "I only answer cyber security related questions.";
        }
    }
  
    public class Program
    { 
        static void welcomeDisplay()
        {
            //change colour of diplay
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"                                  
                                                                          
                       nYmvvvvvvvvvvvvvvvvvvvvvvvt03z                     
                      gdz                          wX                     
                      5s     wieeeeeeeeeeeeeeiu     5s                    
                      5s    0cu              uc9    5s                    
                      5s   s5                  5s   5s                    
                      5s   s5                  5s   5s                    
                      5s   s5                  5s   5s                    
                      5s   s5                  5s   5s                    
                      5s   s5                  5s   5s                    
                sacilljklllkjlllllllllllllllllljkllljklkid0r              
              x7gy                                        zi7u            
              4r                                            xX            
              X         zwwz                    zwwz         X            
              X       v1BAAD5w                w5DAAB1u       X            
              X      wAAAAAAAE                EAAAAAAAw      X            
              X      sAAAAAAABx              xBAAAAAAAs      X            
              X       lPAAAASp      vccv      pSAAAAPl       X            
              X         wqrw       sEAAEr       wrqw         X            
              X                    tHAAHt                    X            
              X                    rFAAIv                    X            
              X                   wIAAAANx                   X            
              X                   OAAAAAAV                   X            
              X                  zvvvvvvvv                   X            
              X                                              X            
              X                                              X            
              4s            7DDDDDDDDDDDDDDDDDDDe           xY            
              x5jy                                        yl5t            
                t58kssssssssssssssssssssssssssssssssssssk93q              
                                                                                                     
                                                                                                    
              
 /$$        /$$$$$$   /$$$$$$  /$$   /$$       /$$     /$$ /$$$$$$  /$$   /$$ /$$$$$$$        /$$$$$$$   /$$$$$$   /$$$$$$  /$$   /$$ /$$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$$   /$$$$$$ 
| $$       /$$__  $$ /$$__  $$| $$  /$$/      |  $$   /$$//$$__  $$| $$  | $$| $$__  $$      | $$__  $$ /$$__  $$ /$$__  $$| $$  /$$/| $$__  $$ /$$__  $$ /$$__  $$| $$__  $$ /$$__  $$
| $$      | $$  \ $$| $$  \__/| $$ /$$/        \  $$ /$$/| $$  \ $$| $$  | $$| $$  \ $$      | $$  \ $$| $$  \ $$| $$  \__/| $$ /$$/ | $$  \ $$| $$  \ $$| $$  \ $$| $$  \ $$| $$  \__/
| $$      | $$  | $$| $$      | $$$$$/          \  $$$$/ | $$  | $$| $$  | $$| $$$$$$$/      | $$$$$$$ | $$$$$$$$| $$      | $$$$$/  | $$  | $$| $$  | $$| $$  | $$| $$$$$$$/|  $$$$$$ 
| $$      | $$  | $$| $$      | $$  $$           \  $$/  | $$  | $$| $$  | $$| $$__  $$      | $$__  $$| $$__  $$| $$      | $$  $$  | $$  | $$| $$  | $$| $$  | $$| $$__  $$ \____  $$
| $$      | $$  | $$| $$    $$| $$\  $$           | $$   | $$  | $$| $$  | $$| $$  \ $$      | $$  \ $$| $$  | $$| $$    $$| $$\  $$ | $$  | $$| $$  | $$| $$  | $$| $$  \ $$ /$$  \ $$
| $$$$$$$$|  $$$$$$/|  $$$$$$/| $$ \  $$          | $$   |  $$$$$$/|  $$$$$$/| $$  | $$      | $$$$$$$/| $$  | $$|  $$$$$$/| $$ \  $$| $$$$$$$/|  $$$$$$/|  $$$$$$/| $$  | $$|  $$$$$$/
|________/ \______/  \______/ |__/  \__/          |__/    \______/  \______/ |__/  |__/      |_______/ |__/  |__/ \______/ |__/  \__/|_______/  \______/  \______/ |__/  |__/ \______/ 
                 
        ");

            //formatting
            Console.WriteLine("Welcome to the LYD Cybersecurtiy Chatbot!");
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine();
            Console.ResetColor();
        }

        //we have a welcome voice
        static void playGreeting()
        {
            //try catch for errors
            try
            {
                //finds the file
                string soundFilePah = "C:\\Users\\me\\source\\repos\\CyberChatbotC#\\CHATBOTMEDIA\\welcomeMan.wav";

                using(SoundPlayer player = new SoundPlayer(soundFilePah))
                {
                    //plays audio
                    player.Play();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sound not detected. {ex.Message}");
            }
        }

        // we run everything from the main class
        static void Main (string[] args)
        {
            //begin
            playGreeting();
            welcomeDisplay();

            //make a bot object 
            chatBot bot = new chatBot();

            //ask for a name
            Console.Write("Hi there can i get your name? Name: ");
            string user= Console.ReadLine();
            Console.WriteLine();

            //loop until name is given

            while (string.IsNullOrEmpty(user))
            {
                Console.WriteLine();
                Console.WriteLine("Hmm... It seems you haven't said anything? Please tell me your name.");
                Console.WriteLine();

                //loop starts here
                user = Console.ReadLine()?.Trim();
                Console.WriteLine();
                
            }

            //formatting
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine("Hello, " + user + "! I am the cyber security chatbot! How may i assist you today?");
            Console.WriteLine();

            Console.WriteLine("Type 'exit' to end convo.");
            Console.WriteLine();

            //make a while 'true' loop so the console doesn't auto close
            while (true)
            {
                //set user reponse colour to blue
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(">");

                string input = Console.ReadLine();
                Console.WriteLine();

                if (input == "exit")
                {
                    break;
                }

                //Reset bot response colour
                Console.ResetColor();

                //read and fetch response
                string response = bot.getResponses(input);
                Console.WriteLine("Well "+ user+ ", "+response);

                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------");

                Console.WriteLine();
                Console.WriteLine("Any more questions?");
                Console.WriteLine();
            }
             
        }
    }
}