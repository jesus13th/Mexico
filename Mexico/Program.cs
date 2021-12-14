using System;
using System.Collections.Generic;
using System.Linq;

namespace Mexico {
    public class Program {
        public static void Main() {
            Dictionary<string, string> data = (Dictionary<string, string>)Data().Shuffle();
            Console.WriteLine("Bienvenido a el juego de los estados :D, selecciona el inciso correspondiente a la capital de dicho estado, suerte :D");
            char[] incisos = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm' };
            int counter = 0;
            int respuestas = 5;//incisos.Length;
            int success = 0;

            while (counter < data.Count) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"¿Cual es la capital de {data.ElementAt(counter).Key}:");
                List<string> answers = new List<string>(){
                    data.ElementAt(counter).Value
                };
                List<int> numbers = RandomNumbers(counter, respuestas, data.Count);
                for (int i = 1; i < respuestas; i++) {
                    answers.Add(data.ElementAt(numbers[i]).Value);
                }
                answers = answers.Randomize().ToList();
                for (int i = 0; i < respuestas; i++) {
                    Console.WriteLine($"{incisos[i]}) { answers[i]}");
                }
                char c = Console.ReadKey().KeyChar;
                int index = Array.IndexOf(incisos, c);
                Console.Clear();
                if (index != -1 && answers[index] == data.ElementAt(counter).Value) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tu respuesta es correcta!!");
                    success++;
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Tu respuesta es incorrecta :( la respuesta correcta es: { data.ElementAt(counter).Value }");
                }
                counter++;
            }
            Console.Clear();
            Console.WriteLine($"Fin del juego, puntuacion {success}/{data.Count}");
        }
        private static List<int> RandomNumbers(int value, int length, int max) {
            Random rand = new Random();
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < length; i++) {
                do {
                    number = rand.Next(1, max);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            return listNumbers;
        }
        public static Dictionary<string, string> Data() {
            Dictionary<string, string> result = new Dictionary<string, string>(){
                {"Aguascalientes","Aguascalientes"},
                {"Baja California", "Mexicali"},
                {"Baja California Sur", "La Paz"},
                {"Campeche", "San Francisco de Campeche o Campeche"},
                {"Chiapas", "Tuxtla Gutiérrez"},
                {"Chihuahua", "Chihuahua"},
                {"Coahuila de Zaragoza", "Saltillo"},
                {"Colima", "Colima"},
                {"Durango", "Victoria de Durango o Durango"},
                {"Estado de México", "Toluca de Lerdo"},
                {"Guanajuato", "Guanajuato"},
                {"Guerrero", "Chilpancingo de Bravo"},
                {"Hidalgo", "Pachuca de Soto"},
                {"Jalisco", "Guadalajara"},
                {"Michoacán de Ocampo", "Morelia"},
                {"Nayarit", "Tepic"},
                {"Nuevo León", "Monterrey"},
                {"Oaxaca", "Oaxaca de Juárez"},
                {"Puebla", "Puebla de Zaragoza"},
                {"Querétaro", "Santiago de Querétaro"},
                {"Quintana Roo", "Chetumal"},
                {"San Luis Potosí", "San Luis Potosí"},
                {"Sinaloa", "Culiacán Rosales"},
                {"Sonora", "Hermosillo"},
                {"Tabasco", "Villahermosa"},
                {"Tamaulipas", "Ciudad Victoria"},
                {"Tlaxcala", "Tlaxcala de Xicohténcatl"},
                {"Veracruz de Ignacio de la Llave", "Xalapa-Enríquez"},
                {"Yucatán", "Mérida"},
                {"Zacatecas", "Zacatecas"}
            };
            return result;
        }
    }
    public static class Extensions {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source) {
            Random rnd = new Random();
            source = source.OrderBy((item) => rnd.Next());
            return source;
        }
        public static Dictionary<TKey, TValue> Shuffle<TKey, TValue>(this Dictionary<TKey, TValue> source) {
            Random r = new Random();
            return source.OrderBy(x => r.Next())
               .ToDictionary(item => item.Key, item => item.Value);
        }
    }
}
