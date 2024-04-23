namespace Module_5
{
    internal class Program
    {
        static (string Name, string LastName, int Age, string[] NamePets, string[] FavColors) EnterUser()
        {
            (string Name, string LastName, int Age, string[] NamePets, string[] FavColors) User;
            string name;
            do
            {
                Console.Write("Введите имя пользователя: ");
                name = Console.ReadLine();
            } while (CheckWord(name));//Ввод имени
            User.Name = name;
            string lastname;
            do
            {
                Console.Write("Введите фамилию пользователя: ");
                lastname = Console.ReadLine();
            } while (CheckWord(lastname));//Ввод фамилии
            User.LastName = lastname;
            string age;
            int intage;
            do
            {
                Console.Write("Введите возраст пользователя: ");
                age = Console.ReadLine();
            } while (CheckNumber(age, out intage));//Ввод возраста 
            User.Age = intage;
            string count;
            int intcount;
            do
            {
                Console.Write("Введите количество питомцев: ");
                count = Console.ReadLine(); 
            } while (CheckNumber(count, out intcount));//Ввод количества питомцев
            Console.WriteLine("Введите клички животных");
            User.NamePets = GetArray(intcount);//Заполнение массива кличками питомцев
            do
            {
                Console.Write("Введите количество любимых цветов: ");
                count = Console.ReadLine();
            } while (CheckNumber(count, out intcount));//Ввод количество цветов
            Console.WriteLine("Введите любимые цвета");
            User.FavColors = GetArray(intcount);//Заполнение массива любимыми цветами
            return User;
        }
        static bool CheckWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                Console.WriteLine("Данные некорректны!");
                return true;
            }
            {
                return false;
            }
        }//Проверка значения типа string
        static bool CheckNumber(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnumber))
            {
                if (intnumber > 0)
                {
                    corrnumber = intnumber;
                    return false;
                }
            }
            {
                Console.WriteLine("Данные некорректны!");
                corrnumber = 0;
                return true;
            }
        }//Проверка значений типа int
        static string[] GetArray(int count)
        {
            string[] array = new string[count];
            string _word;
            for (int i = 0; i < count; i++)
            {
                do
                {
                    Console.WriteLine("Значение {0}: ", i + 1);
                    _word = Console.ReadLine();
                } while (CheckWord(_word));
                array[i] = _word;
            }
            return array;
        }//Заполнение массива
        static void ShowArray(string[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);   
            }
        }
        static void ShowUser((string Name, string LastName, int Age, string[] NamePets, string[] FavColors) User)
        {
            Console.WriteLine("Имя пользователя {0}", User.Name);
            Console.WriteLine("Фамилия пользователя {0}", User.LastName);
            Console.WriteLine("Возраст пользователя {0}", User.Age);
            Console.WriteLine("Клички животный");
            ShowArray(User.NamePets);
            Console.WriteLine("Любимые цвета");
            ShowArray(User.FavColors);
            
        }
        static void Main(string[] args)
        {
            var User = EnterUser();
            ShowUser(User);
        }
    }
}
