//using System;
//using System.Text.Json;

//public class Persons {
//    public required List<Person> People { get; set; }
//    public static async Task<Persons> LoadFromFileAsync() {
//        var filePath = "Components/Persons.json";
//        var json = await File.ReadAllTextAsync(filePath);
//        var options = new JsonSerializerOptions {
//            PropertyNameCaseInsensitive = true,
//            ReadCommentHandling = JsonCommentHandling.Skip,
//            AllowTrailingCommas = true
//        };
//        var people = JsonSerializer.Deserialize<List<Person>>(json, options);
//        return new Persons { People = people ?? new List<Person>() };
//    }
//}

//public class Person {
//    public int Age { get; set; }
//    public string Name { get; set; }
//}

//using System;

//@code {
//    private List<Person>? people;
//private List<Person>? filteredPeople;
//private string searchQuery = string.Empty;

//protected override async Task OnInitializedAsync() {
//    var persons = await Persons.LoadFromFileAsync();
//    people = persons.People;
//    filteredPeople = people;
//}

//private void FilterPeople() {
//    if (string.IsNullOrWhiteSpace(searchQuery)) {
//        filteredPeople = people;
//    }
//    else {
//        filteredPeople = people?.Where(p => p.Name.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
//    }
//}

//private string SearchQuery {
//    get => searchQuery;
//    set {
//        if (searchQuery != value) {
//            searchQuery = value;
//            FilterPeople();
//        }
//    }
//}
//}