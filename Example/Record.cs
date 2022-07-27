namespace Example;

internal class Record
    {
        //Ссылочный
        public record Personbyref(string FirstName, string LastName);

        //Значимый
        public record struct Personbyval(string FirstName, string LastName);

        public static void Test()
        {
            var byref1 = new Personbyref("Петр", "Петров" );
            var byref2 = new Personbyref("Петр", "Петров" );

            var byval1 = new Personbyval { FirstName = "Петр", LastName = "Петров" };
            var byval2 = new Personbyval { FirstName = "Петр", LastName = "Петров" };

            //Так нельзя менять свойства
            //byref1.FirstName = "Иван";//

            //Зато можно для значимых
            byval1.FirstName = "Иван";
        }
    }

