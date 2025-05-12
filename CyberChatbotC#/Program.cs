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
        //update
        private Dictionary<string, List<string>> _securityResponses = new Dictionary<string, List<string>>()
{
    // Malware Related
    {
        "virus",
        new List<string>()
        {
            "Viruses are malicious programs that replicate and spread. Use antivirus software and avoid suspicious downloads.",
            "A virus can corrupt files or steal data. Regularly scan your system and keep backups.",
            "never open email attachments from unknown senders—they might contain viruses."
        }
    },
    {
        "malware",
        new List<string>()
        {
            "Malware is any malicious software (e.g., viruses, spyware). Use trusted security tools to block infections.",
            "Keep your OS and apps updated to patch malware vulnerabilities.",
            "Avoid pirated software—it often contains hidden malware."
        }
    },
    {
        "ransomware",
        new List<string>()
        {
            "Ransomware encrypts files and demands payment. Backup data offline to recover without paying.",
            "Never pay ransoms—it funds criminals and doesn’t guarantee file recovery.",
            "Use endpoint protection tools to detect ransomware before it executes."
        }
    },
    {
        "antivirus",
        new List<string>()
        {
            "Antivirus software scans for and removes malware. Enable real-time protection for active threats.",
            "Free antivirus tools like Avast or AVG offer basic protection; paid versions add firewalls and phishing guards.",
            "Schedule weekly antivirus scans to catch hidden threats."
        }
    },

    // Network Security
    {
        "firewall",
        new List<string>()
        {
            "Firewalls block unauthorized network access. Enable both hardware (router) and software firewalls.",
            "Configure firewall rules to restrict unnecessary inbound/outbound traffic.",
            "Firewalls can’t stop all threats—pair them with antivirus and VPNs for layered security."
        }
    },
    {
        "vpn",
        new List<string>()
        {
            "VPNs encrypt your internet traffic, hiding it from ISPs and hackers. Use them on public WiFi!",
            "Choose a no-logs VPN provider (e.g., NordVPN, ProtonVPN) for maximum privacy.",
            "VPNs can slow your connection but are essential for secure remote work."
        }
    },
    {
        "wifi",
        new List<string>()
        {
            "Secure WiFi with WPA3 encryption, a strong password, and disable WPS (it’s easily hacked).",
            "Public WiFi is risky—always use a VPN to prevent snooping.",
            "Rename your home WiFi network to avoid revealing your router model (helps deter targeted attacks)."
        }
    },
    {
        "ddos",
        new List<string>()
        {
            "DDoS attacks overwhelm servers with traffic. Use cloud-based mitigation services (e.g., Cloudflare).",
            "Enable rate limiting on your network to reduce DDoS impact.",
            "DDoS protection requires scalable infrastructure—small sites should rely on hosting providers."
        }
    },

    // Authentication
    {
        "password",
        new List<string>()
        {
            "Use 12+ character passwords with numbers, symbols, and uppercase/lowercase letters.",
            "Password managers (e.g., Bitwarden, 1Password) generate and store strong passwords securely.",
            "Never reuse passwords—a breach on one site compromises all accounts."
        }
    },
    {
        "factor",
        new List<string>()
        {
            "Two-factor authentication (2FA) requires a password + a second factor (e.g., SMS, authenticator app).",
            "Avoid SMS-based 2FA if possible—use app-based (Google Authenticator) or hardware keys (YubiKey).",
            "Multi-factor authentication (MFA) is even stronger, combining multiple verification methods."
        }
    },
    {
        "authentication",
        new List<string>()
        {
            "Authentication proves your identity. Use biometrics (fingerprint) + passwords for high-security accounts.",
            "Single Sign-On (SSO) simplifies authentication but relies on your provider’s security.",
            "oAuth and OpenID Connect are secure protocols for third-party logins (e.g., 'Sign in with Google')."
        }
    },

    // General Security
    {
        "phishing",
        new List<string>()
        {
            "Phishing emails mimic trusted brands. Hover over links to check URLs before clicking.",
            "Never share passwords via email—legitimate companies will never ask for them.",
            "Report phishing attempts to your IT team or email provider (e.g., Gmail’s 'Report Phishing' button)."
        }
    },
    {
        "encryption",
        new List<string>()
        {
            "encryption scrambles data so only authorized parties can read it. Use TLS (HTTPS) for websites.",
            "Full-disk encryption (e.g., BitLocker, FileVault) protects devices if stolen.",
            "End-to-end encryption (E2EE) ensures only you and the recipient can read messages (e.g., Signal)."
        }
    },
    {
        "backup",
        new List<string>()
        {
            "Follow the 3-2-1 backup rule: 3 copies, 2 local (different devices), 1 offsite (e.g., cloud).",
            "Test backups regularly—corrupted backups are worse than none.",
            "Ransomware can encrypt backups too—use immutable/air-gapped backups for critical data."
        }
    },
    {
        "patch",
        new List<string>()
        {
            "Patch management fixes security flaws. Enable auto-updates for OS and apps.",
            "Zero-day exploits target unpatched systems—update immediately when patches are released.",
            "Enterprise patch tools (e.g., WSUS, SCCM) automate updates across large networks."
        }
    },
    {
        "scam",
        new List<string>()
        {
            "Scams rely on urgency ('Your account is locked!'). Verify claims via official channels.",
            "Tech support scams pretend to be from Microsoft/Apple. Hang up and call the company directly.",
            "If it sounds too good to be true (free gifts, unexpected prizes), it’s a scam."
        }
    },
    {
        "honeypot",
        new List<string>()
        {
            "Honeypots are decoy systems that attract hackers to study their tactics.",
            "Security teams use honeypots to detect attacks early without risking real systems.",
            "Honeytokens (fake credentials/data) can also lure attackers and trigger alerts."
        }
    },
    {
        "spyware",
        new List<string>()
        {
            "Spyware secretly monitors your activity (keystrokes, screenshots). Use anti-spyware tools to remove it.",
            "Avoid illegal software cracks—they often bundle spyware.",
            "Mobile spyware (e.g., Pegasus) requires zero-click exploits. Keep devices updated."
        }
    }
}; // we close dictionaries

        // Dictionary with sentimental responses
        private Dictionary<string,string> _sentimentalResponses = new Dictionary<string,string>
        {
            //worried
            {"worried","It's normal to be worried. A lot of people feel the same, here's a solution: "},
            {"curious","It's good to be curious about cyber security! "},
            {"frustrated","I understand being frustrated when it comes to cyber security. How about this: "}

        };


        //next we will check for the keyword and return a relevant response
        //this is a response method so we'll call it public string
        public string getResponses(string userInput)
        {
            //case insensitive
            string input = userInput.ToLower();
            string sentimentFound = null;
            string keywordFound = null;

            //check for sentimental words
            foreach (var sentiment in _sentimentalResponses)
            {
                string sentimentKey = sentiment.Key;
                if (input.Contains(sentimentKey))
                {
                    sentimentFound =sentiment.Value;
                    break;
                }

            }
            //check for security words
            foreach (var keyword in _securityResponses)
            {
                string keywordKey = keyword.Key;
                if (input.Contains(keywordKey))
                {
                    Random rand = new Random();
                    List<string> response = keyword.Value;
                    keywordFound = response[rand.Next(response.Count)];
                    break;
                }

            }
             
            //combined response
            if (sentimentFound != null&&keywordFound != null)
            {
                return $"{sentimentFound}{keywordFound}";
                
            }
            else if (sentimentFound != null) //random tips
            {
                Random rand = new Random();
                var allTips = _securityResponses.Values.SelectMany(x => x).ToList();
                string randomTip = allTips[rand.Next(allTips.Count)];
                return $"{sentimentFound}{randomTip}";
            }
            else if (keywordFound != null)
            {
                return $"{keywordFound}";
            }

            else if (input.Contains("how are you"))
            {
                return "I am well. Thank you for asking";
            }
            else if (input.Contains("what are you"))
            {
                return "I am a cyber security chatbot.";
            }
            else if (input.Contains("what do you do"))
            {
                return "I answer cyber security related questions.";
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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
            Console.ForegroundColor = ConsoleColor.Yellow;
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
            Console.Write("Hi there can i get your name? Name:> ");
            string user= Console.ReadLine();
            Console.WriteLine();

            //loop until name is given

            while (string.IsNullOrEmpty(user) || user.All(char.IsDigit))
            {
                if (string.IsNullOrEmpty(user))
                {
                    Console.WriteLine();
                    Console.WriteLine("Hmm... It seems you haven't said anything? Please tell me your name.");
                    Console.WriteLine();
                }
                else if (user.All(char.IsDigit))
                {
                    // Color error message in red
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("(Error: Name cannot be a number.)");
                    Console.ResetColor();
                    Console.WriteLine();
                }

                // Get user input and trim whitespace
                user = Console.ReadLine()?.Trim();
                Console.WriteLine();
            }

            //formatting
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
            Console.WriteLine($"Hello, { user }! I am the cyber security chatbot! How may i assist you today?");
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
                Console.WriteLine($"{response}");

                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------");

                Console.WriteLine();
                Console.WriteLine($"Any more questions {user}?");
                Console.WriteLine();
            }
             
        }
    }
}