namespace Example
{
    internal class lambdaEx
    {
        public static void test()
        {
            //Старое
            Func<string, int> parseold = s => int.Parse(s);

            //Новое
            var parsenew = (string s) => int.Parse(s);

            //явный тип возвращаемого значения
            var choose = decimal (bool b) => b ? 1 : 2; 
            var choose2 = object (bool b) => b ? 1 : "two";

            parsenew = ([ExAttr]string s) => int.Parse(s);
        }

        public class ExAttr : Attribute
        {

        }
    }
}
