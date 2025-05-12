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
            "viruses are malicious programs that replicate and spread. Use antivirus software and avoid suspicious downloads.",
            "a virus can corrupt files or steal data. Regularly scan your system and keep backups.",
            "never open email attachments from unknown senders—they might contain viruses."
        }
    },
    {
        "malware",
        new List<string>()
        {
            "malware is any malicious software (e.g., viruses, spyware). Use trusted security tools to block infections.",
            "keep your OS and apps updated to patch malware vulnerabilities.",
            "avoid pirated software—it often contains hidden malware."
        }
    },
    {
        "ransomware",
        new List<string>()
        {
            "ransomware encrypts files and demands payment. Backup data offline to recover without paying.",
            "never pay ransoms—it funds criminals and doesn’t guarantee file recovery.",
            "use endpoint protection tools to detect ransomware before it executes."
        }
    },
    {
        "antivirus",
        new List<string>()
        {
            "antivirus software scans for and removes malware. Enable real-time protection for active threats.",
            "free antivirus tools like Avast or AVG offer basic protection; paid versions add firewalls and phishing guards.",
            "schedule weekly antivirus scans to catch hidden threats."
        }
    },

    // Network Security
    {
        "firewall",
        new List<string>()
        {
            "firewalls block unauthorized network access. Enable both hardware (router) and software firewalls.",
            "configure firewall rules to restrict unnecessary inbound/outbound traffic.",
            "firewalls can’t stop all threats—pair them with antivirus and VPNs for layered security."
        }
    },
    {
        "vpn",
        new List<string>()
        {
            "VPNs encrypt your internet traffic, hiding it from ISPs and hackers. Use them on public WiFi!",
            "choose a no-logs VPN provider (e.g., NordVPN, ProtonVPN) for maximum privacy.",
            "VPNs can slow your connection but are essential for secure remote work."
        }
    },
    {
        "wifi",
        new List<string>()
        {
            "secure WiFi with WPA3 encryption, a strong password, and disable WPS (it’s easily hacked).",
            "public WiFi is risky—always use a VPN to prevent snooping.",
            "rename your home WiFi network to avoid revealing your router model (helps deter targeted attacks)."
        }
    },
    {
        "ddos",
        new List<string>()
        {
            "DDoS attacks overwhelm servers with traffic. Use cloud-based mitigation services (e.g., Cloudflare).",
            "enable rate limiting on your network to reduce DDoS impact.",
            "DDoS protection requires scalable infrastructure—small sites should rely on hosting providers."
        }
    },

    // Authentication
    {
        "password",
        new List<string>()
        {
            "use 12+ character passwords with numbers, symbols, and uppercase/lowercase letters.",
            "password managers (e.g., Bitwarden, 1Password) generate and store strong passwords securely.",
            "never reuse passwords—a breach on one site compromises all accounts."
        }
    },
    {
        "factor",
        new List<string>()
        {
            "two-factor authentication (2FA) requires a password + a second factor (e.g., SMS, authenticator app).",
            "avoid SMS-based 2FA if possible—use app-based (Google Authenticator) or hardware keys (YubiKey).",
            "multi-factor authentication (MFA) is even stronger, combining multiple verification methods."
        }
    },
    {
        "authentication",
        new List<string>()
        {
            "authentication proves your identity. Use biometrics (fingerprint) + passwords for high-security accounts.",
            "single Sign-On (SSO) simplifies authentication but relies on your provider’s security.",
            "oAuth and OpenID Connect are secure protocols for third-party logins (e.g., 'Sign in with Google')."
        }
    },

    // General Security
    {
        "phishing",
        new List<string>()
        {
            "phishing emails mimic trusted brands. Hover over links to check URLs before clicking.",
            "never share passwords via email—legitimate companies will never ask for them.",
            "report phishing attempts to your IT team or email provider (e.g., Gmail’s 'Report Phishing' button)."
        }
    },
    {
        "encryption",
        new List<string>()
        {
            "encryption scrambles data so only authorized parties can read it. Use TLS (HTTPS) for websites.",
            "full-disk encryption (e.g., BitLocker, FileVault) protects devices if stolen.",
            "end-to-end encryption (E2EE) ensures only you and the recipient can read messages (e.g., Signal)."
        }
    },
    {
        "backup",
        new List<string>()
        {
            "follow the 3-2-1 backup rule: 3 copies, 2 local (different devices), 1 offsite (e.g., cloud).",
            "test backups regularly—corrupted backups are worse than none.",
            "ransomware can encrypt backups too—use immutable/air-gapped backups for critical data."
        }
    },
    {
        "patch",
        new List<string>()
        {
            "patch management fixes security flaws. Enable auto-updates for OS and apps.",
            "zero-day exploits target unpatched systems—update immediately when patches are released.",
            "enterprise patch tools (e.g., WSUS, SCCM) automate updates across large networks."
        }
    },
    {
        "scam",
        new List<string>()
        {
            "scams rely on urgency ('Your account is locked!'). Verify claims via official channels.",
            "tech support scams pretend to be from Microsoft/Apple. Hang up and call the company directly.",
            "if it sounds too good to be true (free gifts, unexpected prizes), it’s a scam."
        }
    },
    {
        "honeypot",
        new List<string>()
        {
            "honeypots are decoy systems that attract hackers to study their tactics.",
            "security teams use honeypots to detect attacks early without risking real systems.",
            "honeytokens (fake credentials/data) can also lure attackers and trigger alerts."
        }
    },
    {
        "spyware",
        new List<string>()
        {
            "spyware secretly monitors your activity (keystrokes, screenshots). Use anti-spyware tools to remove it.",
            "avoid illegal software cracks—they often bundle spyware.",
            "mobile spyware (e.g., Pegasus) requires zero-click exploits. Keep devices updated."
        }
    }
}; // we close dictionaries


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
                if (input.Contains(keyword.ToLower()))
                {
                    List<string> responses = _securityResponses[keyword];
                    Random rand = new Random();
                    return responses[rand.Next(responses.Count)]; // Return random response
                }
              
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

            while (string.IsNullOrEmpty(user))
            {
                Console.WriteLine();
                Console.WriteLine("Hmm... It seems you haven't said anything? Please tell me your name.");
                Console.WriteLine();
                //loop starts here
                user = Console.ReadLine()?.Trim();
                Console.WriteLine();
                
            }

            while (user.All(char.IsDigit))
            {
                //colour error red
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("(Error: Name cannot be a number.)");
                Console.ResetColor();
                user = Console.ReadLine();
            }

            //formatting
            Console.WriteLine();
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
                Console.WriteLine($"Well {user}, {response}");

                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------");

                Console.WriteLine();
                Console.WriteLine("Any more questions?");
                Console.WriteLine();
            }
             
        }
    }
}