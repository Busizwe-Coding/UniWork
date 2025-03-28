﻿// See https://aka.ms/new-console-template for more information
//Creating a SIMPLE chatbot that only answers cybersecurity related questions
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
                return "I am well. Do you have anymore questions?";

            if (input == "what is your purpose?")
                return "I answer questions about cyber security. Do you have anymore questions?";

            if (input == "what can i ask you?")
                return "Anything about cyber security. Do you have anymore questions?";
             

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
        // we run everything from the main class
        static void Main (string[] args)
        {
            //make a bot object 
            chatBot bot = new chatBot();

            Console.WriteLine("Hello I am the cyber security chatbot! How may i assist you today?");
            Console.WriteLine();
            string input = Console.ReadLine();
            Console.WriteLine();

            string response = bot.getResponses(input);
            Console.WriteLine(response);
        }
    }
}