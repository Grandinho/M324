using System.Text.Json;
using System;
using AutocompleteWithContextSearch;

public class Programm {
    public static void Main(string[] args) {
        string prefix;
        if (args.Length > 0) {
            prefix = args[0];
        }
        else {
            Console.WriteLine("Bitte geben Sie ein Prefix ein:");
            prefix = Console.ReadLine() ?? "";
        }

        try {
            string text = File.ReadAllText(@"C:\Projects\School\M324\devops_programming_exercise_1\AutocompleteWithContextSearch\AutocompleteWithContextSearch\data\class.json");
            List<Student> allStudents = JsonSerializer.Deserialize<List<Student>>(text);

            var result = SearchWithNextChar(allStudents, prefix);

            Console.WriteLine($"\nSuche nach: '{prefix}'");
            Console.WriteLine($"Gefundene Namen:");
            foreach (var student in result.MatchingStudents) {
                Console.WriteLine($"- {student.name}");
            }

            if (result.NextCharCount > 0) {
                Console.WriteLine($"\nDer häufigste nächste Buchstabe nach '{prefix}' ist '{result.MostCommonNextChar}' " +
                                $"(kommt {result.NextCharCount} mal vor)");
            }
            else {
                Console.WriteLine("\nKein häufiger nächster Buchstabe gefunden.");
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
        }

        Console.WriteLine("\nDrücken Sie eine Taste zum Beenden...");
        Console.ReadKey();
    }
    public static SerachResult SearchWithNextChar(List<Student> students, string prefix) {
        if (string.IsNullOrEmpty(prefix))
            return new SerachResult {
                MatchingStudents = students,
                MostCommonNextChar = ' ',
                NextCharCount = 0
            };

        var matchingStudents = students
            .Where(s => s.name.Contains(prefix, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (!matchingStudents.Any())
            return new SerachResult {
                MatchingStudents = new List<Student>(),
                MostCommonNextChar = ' ',
                NextCharCount = 0
            };

        var nextCharFrequency = matchingStudents
            .SelectMany(s => {
                var name = s.name.ToLower();
                var prefixLower = prefix.ToLower();
                var prefixChars = prefixLower.ToCharArray();

                return name
                    .Where(c => !prefixChars.Contains(c)); 
            })
            .GroupBy(c => c)
            .Select(g => new { Char = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .FirstOrDefault();


        return new SerachResult {
            MatchingStudents = matchingStudents,
            MostCommonNextChar = nextCharFrequency?.Char ?? ' ',
            NextCharCount = nextCharFrequency?.Count ?? 0
        };
    }
    }

