namespace Decorator
{
    //D:\\Навчання\\Круш\\Декоратор\\Заготовка.png;
    //D:\\Навчання\\Круш\\Декоратор\\ЗаготовкаСир.png;
    //D:\\Навчання\\Круш\\Декоратор\\ЗаготовкаПепероні.png;
    //D:\\Навчання\\Круш\\Декоратор\\ЗаготовкаСирПепероні.png;

    // Базовий інтерфейс Піци
    public interface IPizza
    {
        string WhatYouHave();
    }

    // Базовий клас Заготовки Піци
    public class PrepOfPizza : IPizza
    {
        public string WhatYouHave()
        {
            return "Заготовка піци";
        }
    }

    // Декоратор Піци
    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual string WhatYouHave()
        {
            return _pizza.WhatYouHave();
        }

    }

    // Додаткові інгредієнти для Піци
    public class Cheese : PizzaDecorator
    {
        public Cheese(IPizza pizza) : base(pizza)
        {
        }

        public override string WhatYouHave()
        {
            return $"{_pizza.WhatYouHave()}, сир";
        }

    }
    public class Tomatoes : PizzaDecorator
    {
        public Tomatoes(IPizza pizza) : base(pizza)
        {
        }

        public override string WhatYouHave()
        {
            return $"{_pizza.WhatYouHave()}, помідори";
        }

    }

    public class Pepperoni : PizzaDecorator
    {
        public Pepperoni(IPizza pizza) : base(pizza)
        {
        }

        public override string WhatYouHave()
        {
            return $"{_pizza.WhatYouHave()}, пепероні";
        }
    }

}
