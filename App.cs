
using System.Text;
using System.Transactions;

namespace c_sharp_fundamentals.ConsoleApp.TrainingApp.Password_Manager
{
    public static class App
    {
        private static readonly string path = "D:\\c sharp\\C_sharp_fundamentals\\c_sharp_fundamentals.ConsoleApp\\TrainingApp\\Password Manager\\Passwords.txt";
        private static string ws = "";
        private static int re = 0;
        private static string[] Lines = File.ReadAllLines(path);
        private static readonly Dictionary<string, string> _Dict = new();
        public static void Run(string[] args)
        {
            while (true)
            {
                Lines = File.ReadAllLines(path);
                Console.WriteLine("======================");
                Console.WriteLine("[1]Add New Password\n[2]Find Password\n[3]Edit Password\n[4]Delete Password\n[5]Print All Passwords");
                Console.WriteLine("======================");
                Console.Write("Enter Your Choice : ");
                var Choice = int.Parse(Console.ReadLine());
                if (Choice == 1)
                {
                    AddPassword();
                }
                else if (Choice == 2)
                {
                    Console.Write("Enter Website Name : ");
                    ws = Console.ReadLine();
                    re = FindPassword(ws);
                    if(re != 0)
                    {
                        string _password = Lines[re - 1].Substring(Lines[re-1].IndexOf(':')+1);
                        _password = _password.Trim();
                        _password = Encryption.Decrypter(_password);
                        Console.WriteLine($"{ws} : {_password}");
                    }
                    else
                    {
                        Console.WriteLine($"No Webiste With {ws} Name Is Found");
                    }
                }
                else if (Choice == 3)
                {
                    EditPassword();
                }
                else if (Choice == 4)
                {
                    DeletePassword();
                }
                else if (Choice == 5)
                {
                    PrintAll();
                }
                else
                {
                    Console.WriteLine("Please Enter A Vaild Choice");
                }
                Lines = File.ReadAllLines(path);
                Console.WriteLine("------------------------------------");
            }
        }
        private static void AddPassword()
        {
            Console.Write("Enter Website Name : ");
            var sb = new StringBuilder();
            var Website = Console.ReadLine();
            var Password = "";
            int ret = FindPassword(Website);
            if (ret != 0)
            {
                Console.WriteLine("Error A Website With The Same Name Is Already Exisits In the Data Base :)");            
            }
            else
            {
                Console.Write("Enter The Password : ");
                Password = Console.ReadLine();
                Password = Encryption.Encrypter(Password);
                _Dict.Add(Website, Password);
                sb.Append($"{Website} : {_Dict[Website]}\n");
                File.AppendAllText(path, sb.ToString());
                _Dict.Clear();
            }

        }

        private static int FindPassword(string Website)
        {
            int ret = 0 ,count = 0;
            foreach (var line in File.ReadLines(path))
            {
                count++;
                if (!(String.IsNullOrEmpty(line)))
                {
                    string sub = line.Substring(0, line.IndexOf(':') - 1);
                    if (sub == Website)
                    {
                        ret = count;
                        break;
                    }
                    else
                    {

                    }
                }
            }
            return ret;
        }

        private static void EditPassword()
        {
            Console.Write("Enter Website Name : ");
            string s = Console.ReadLine();
            int ret = FindPassword(s);
            if(ret != 0)
            {
                string temp = "";
                temp = Lines[ret - 1].Substring((Lines[ret - 1].IndexOf(':')) + 1);
                temp = temp.Trim();
                temp = Encryption.Decrypter(temp);
                Console.WriteLine($"The Old Password [{s} : {temp}]");
                Console.Write("Enter The New Password : ");
                string NewPassword = Console.ReadLine();
                NewPassword = Encryption.Encrypter(NewPassword);
                Lines[ret - 1] = Lines[ret - 1].Remove((Lines[ret - 1].IndexOf(':')) + 1);
                Lines[ret - 1] += " ";
                Lines[ret - 1] += NewPassword;
                File.WriteAllLines(path, Lines);
            }
            else
            {
                Console.WriteLine($"No Webiste With {s} Name Is Found");
            }
        }
        private static void DeletePassword()
        {
            Console.Write("Enter Website Name : ");
            string s = Console.ReadLine();
            int ret = FindPassword(s);
            if (ret != null)
            {
                string temp = "";
                temp = Lines[ret - 1].Substring((Lines[ret - 1].IndexOf(':')) + 1);
                temp =temp.Trim();
                temp = Encryption.Decrypter(temp);
                Console.WriteLine($"Are You Sure You Want To Delete This Password [{s} : {temp}] ? (y/n)");
                char c = char.Parse(Console.ReadLine());
                c=Char.ToLower(c);  
                if(c == 'y')
                {
                    Lines[ret - 1] = "";
                    File.WriteAllLines(path, Lines);
                }
                else
                {

                }
            }
            else
            {
                Console.WriteLine($"No Webiste With {ws} Is Found");
            }
        }
        private static void PrintAll()
        {
            string temp = "";
            string s;
            foreach (string line in File.ReadLines(path))
            {
                if(String.IsNullOrEmpty(line))
                {

                }
                else
                {
                    temp = line.Substring((line.IndexOf(':')) + 1);
                    temp = temp.Trim();
                    temp = Encryption.Decrypter(temp);
                    s = line.Substring(0, line.IndexOf(":"));
                    Console.WriteLine($"{s} : {temp}");
                }
            }
        }
        
    }
}
