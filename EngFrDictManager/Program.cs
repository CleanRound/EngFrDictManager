class EnglishFrenchDictionaryApp
{
    private static Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nEnglish-French Dictionary Management System");
            Console.WriteLine("1. Add Word and Translation Options");
            Console.WriteLine("2. Remove Word");
            Console.WriteLine("3. Remove Translation Option");
            Console.WriteLine("4. Change Word");
            Console.WriteLine("5. Change Translation Option");
            Console.WriteLine("6. Search for the Translation of a Word");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddWordAndTranslations();
                    break;
                case "2":
                    RemoveWord();
                    break;
                case "3":
                    RemoveTranslationOption();
                    break;
                case "4":
                    ChangeWord();
                    break;
                case "5":
                    ChangeTranslationOption();
                    break;
                case "6":
                    SearchTranslation();
                    break;
                case "7":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddWordAndTranslations()
    {
        Console.Write("Enter the English word: ");
        string englishWord = Console.ReadLine();

        if (dictionary.ContainsKey(englishWord))
        {
            Console.WriteLine("Word already exists. Add translations instead.");
            return;
        }

        List<string> translations = new List<string>();
        Console.WriteLine("Enter the French translations (enter 'done' to finish): ");
        while (true)
        {
            string translation = Console.ReadLine();
            if (translation.ToLower() == "done")
                break;
            translations.Add(translation);
        }

        dictionary.Add(englishWord, translations);
        Console.WriteLine("Word and translations added successfully.");
    }

    static void RemoveWord()
    {
        Console.Write("Enter the English word to remove: ");
        string englishWord = Console.ReadLine();
        if (dictionary.Remove(englishWord))
        {
            Console.WriteLine("Word removed successfully.");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    static void RemoveTranslationOption()
    {
        Console.Write("Enter the English word: ");
        string englishWord = Console.ReadLine();
        if (dictionary.TryGetValue(englishWord, out List<string> translations))
        {
            Console.WriteLine("Enter the translation option to remove: ");
            string translation = Console.ReadLine();
            if (translations.Remove(translation))
            {
                Console.WriteLine("Translation removed successfully.");
            }
            else
            {
                Console.WriteLine("Translation option not found.");
            }
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    static void ChangeWord()
    {
        Console.Write("Enter the English word to change: ");
        string oldWord = Console.ReadLine();
        if (dictionary.TryGetValue(oldWord, out List<string> translations))
        {
            Console.Write("Enter the new English word: ");
            string newWord = Console.ReadLine();
            dictionary.Remove(oldWord);
            dictionary.Add(newWord, translations);
            Console.WriteLine("Word changed successfully.");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    static void ChangeTranslationOption()
    {
        Console.Write("Enter the English word: ");
        string englishWord = Console.ReadLine();
        if (dictionary.TryGetValue(englishWord, out List<string> translations))
        {
            Console.WriteLine("Enter the translation option to change: ");
            string oldTranslation = Console.ReadLine();
            if (translations.Contains(oldTranslation))
            {
                Console.Write("Enter the new translation: ");
                string newTranslation = Console.ReadLine();
                int index = translations.IndexOf(oldTranslation);
                translations[index] = newTranslation;
                Console.WriteLine("Translation changed successfully.");
            }
            else
            {
                Console.WriteLine("Translation option not found.");
            }
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }

    static void SearchTranslation()
    {
        Console.Write("Enter the English word to search for: ");
        string englishWord = Console.ReadLine();
        if (dictionary.TryGetValue(englishWord, out List<string> translations))
        {
            Console.WriteLine($"Translations for '{englishWord}': {string.Join(", ", translations)}");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
    }
}
