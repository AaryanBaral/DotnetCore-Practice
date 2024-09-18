
using Controller.Models;

namespace Controller.Services
{
    public class PizzaService
    {
        static List<Pizza> pizzas = new(){
            new(){Id = 1, IsGlutenfree=false, Name="Cheese"},
            new(){Id = 2, IsGlutenfree=true, Name="Chicken"},
            new(){Id = 3, IsGlutenfree=true, Name="Meat Lover"},
            new(){Id = 4, IsGlutenfree=false, Name="Mushroom"},
        };

        public static List<Pizza> GetAll()=> pizzas;
        public static Pizza? Get(int id)
        {
            return pizzas.Find(pizza => pizza.Id == id);
        }

        public static bool Delete(int id)
        {
            Pizza? pizza = Get(id);
            if (pizza is null)
            {
                return false;
            }
            pizzas.Remove(pizza);
            return true;
        }

        public static bool Create(Pizza pizza){
            pizza.Id = pizzas.Max(pizza=>pizza.Id)+1;
            pizzas.Add(pizza);
            return true;
        }
        public static bool Update(Pizza pizza){
            int index = pizzas.FindIndex(p=> p.Id == pizza.Id);
            if(index==-1){
                return false ;
            }
            pizzas[index] = pizza;
            return true;
        }
    }

}