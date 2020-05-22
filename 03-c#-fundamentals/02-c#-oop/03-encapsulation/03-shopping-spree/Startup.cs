namespace _03_shopping_spree
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            var personByName = new Dictionary<string, Person>();
            var productByName = new Dictionary<string, Product>();

            var peopleData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                PopulatePeople(personByName, peopleData);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return;
            }

            var productsData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                PopulateProducts(productByName, productsData);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);

                return;
            }

            var input = Console.ReadLine();
            while (input != "END")
            {
                try
                {
                    var data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var personName = data[0];
                    var productName = data[1];

                    var person = personByName[personName];
                    var product = productByName[productName];
                    var result = person.Buy(product);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var person in personByName)
            {
                Console.WriteLine(person.Value);
            }
        }

        private static void PopulateProducts(Dictionary<string, Product> productByName, string[] productsData)
        {
            foreach (var productData in productsData)
            {
                var data = productData.Split('=', StringSplitOptions.RemoveEmptyEntries);
                var name = data[0];
                var cost = decimal.Parse(data[1]);

                var product = new Product(name, cost);

                productByName[name] = product;
            }
        }

        private static void PopulatePeople(Dictionary<string, Person> personByName, string[] peopleData)
        {
            foreach (var personData in peopleData)
            {
                var data = personData.Split('=', StringSplitOptions.RemoveEmptyEntries);
                var name = data[0];
                var money = decimal.Parse(data[1]);

                var person = new Person(name, money);

                personByName[name] = person;
            }
        }
    }
}
/*

Pesho=11;Gosho=4
Bread=10;Milk=2;
Pesho Bread
Gosho Milk
Gosho Milk
Pesho Milk
END

Mimi=0
Kafence=2
Mimi Kafence
END

Jeko=-3
Chushki=1;
Jeko Chushki
END

*/
