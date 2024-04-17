using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string RequestUri = "https://www.themealdb.com/api/json/v1/1/";
            Console.WriteLine("Jak chcesz zanajeśc przepis 1-Po nazwie, 2-Po głuwnym składniku, 3-Random");
            int Input;
            if (!int.TryParse(Console.ReadLine(), out Input))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            if (Input == 1)
            {
                Console.WriteLine("Podaj nazwe:");
                string a = Console.ReadLine();
                RequestUri += $"search.php?s={a}";
            }
            else if (Input == 2)
            {
                Console.WriteLine("Podaj składnik(po ang):");
                string a = Console.ReadLine();
                RequestUri += $"search.php?i={a}";
            }
            else if (Input == 3)
            {
                RequestUri += "random.php";
            }
            else
            {
                Console.WriteLine("Wpisz poprawnie");
                return;
            }

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(RequestUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<MealResponse>(responseBody, options);

            if (result != null && result.Meals != null && result.Meals.Length > 0)
            {
                var meal = result.Meals[0];
                Console.WriteLine("Składniki:");
                for (int i = 1; i <= 20; i++)
                {
                    var ingredient = meal.GetType().GetProperty($"StrIngredient{i}").GetValue(meal);
                    var measure = meal.GetType().GetProperty($"StrMeasure{i}").GetValue(meal);
                    if (ingredient != null && !string.IsNullOrWhiteSpace(ingredient.ToString()))
                    {
                        Console.WriteLine($"{measure} {ingredient}");
                    }
                }

                Console.WriteLine("\nPrzygotowanie:");
                Console.WriteLine(meal.StrInstructions);
            }
            else
            {
                Console.WriteLine("Nie znaleziono przepisu.");
            }
        }
    }

    public class MealResponse
    {
        public Meal[] Meals { get; set; }
    }

    public class Meal
    {
        public string StrInstructions { get; set; }
        public string StrIngredient1 { get; set; }
        public string StrIngredient2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrIngredient4 { get; set; }
        public string StrIngredient5 { get; set; }
        public string StrIngredient6 { get; set; }
        public string StrIngredient7 { get; set; }
        public string StrIngredient8 { get; set; }
        public string StrIngredient9 { get; set; }
        public string StrIngredient10 { get; set; }
        public string StrIngredient11 { get; set; }
        public string StrIngredient12 { get; set; }
        public string StrIngredient13 { get; set; }
        public string StrIngredient14 { get; set; }
        public string StrIngredient15 { get; set; }
        public string StrIngredient16 { get; set; }
        public string StrIngredient17 { get; set; }
        public string StrIngredient18 { get; set; }
        public string StrIngredient19 { get; set; }
        public string StrIngredient20 { get; set; }
        public string StrMeasure1 { get; set; }
        public string StrMeasure2 { get; set; }
        public string StrMeasure3 { get; set; }
        public string StrMeasure4 { get; set; }
        public string StrMeasure5 { get; set; }
        public string StrMeasure6 { get; set; }
        public string StrMeasure7 { get; set; }
        public string StrMeasure8 { get; set; }
        public string StrMeasure9 { get; set; }
        public string StrMeasure10 { get; set; }
        public string StrMeasure11 { get; set; }
        public string StrMeasure12 { get; set; }
        public string StrMeasure13 { get; set; }
        public string StrMeasure14 { get; set; }
        public string StrMeasure15 { get; set; }
        public string StrMeasure16 { get; set; }
        public string StrMeasure17 { get; set; }
        public string StrMeasure18 { get; set; }
        public string StrMeasure19 { get; set; }
        public string StrMeasure20 { get; set; }
    }
}
