namespace Aula4.Models
{
    public class Person
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public static List<Person> Lista
        {
            get
            {
                var lista = new List<Person>();
                lista.Add(new Person { Nome = "Lisa", Idade = 17 });
                lista.Add(new Person { Nome = "LiKaDuo", Idade = 17 });
                lista.Add(new Person { Nome = "Juan", Idade = 16 });

                return lista;
            }
        }
    }
}
