using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decorator
{
    public partial class Form1 : Form
    {
        private IPizza _pizza; // додано змінну для зберігання піци
        private List<PizzaDecorator> _decorators = new List<PizzaDecorator>();
        private CheckBox CheeseCheckBox;
        private CheckBox TomatoCheckBox;
        private Dictionary<string, string> _pizzaImages = new Dictionary<string, string>
        {
            { "None", "D:\\Навчання\\Круш\\Декоратор\\Заготовка.png" },
            { "Cheese", "D:\\Навчання\\Круш\\Декоратор\\ЗаготовкаСир.png" },
            { "Tomatoes", "D:\\Навчання\\Круш\\Декоратор\\ЗаготовкаТомати.png" },
            { "CheeseAndTomatoes", "D:\\Навчання\\Круш\\Декоратор\\ЗаготовкаСирТомати.png" }
        };

        public Form1()
        {
            InitializeComponent();
            _pizza = new PrepOfPizza(); // ініціалізуємо піцу
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Додати елементи CheckBox для вибору декораторів
            CheeseCheckBox = new CheckBox()
            {
                Text = "Cheese",
                Location = new Point(10, 100)
            };
            CheeseCheckBox.CheckedChanged += CheeseCheckBox_CheckedChanged;
            this.Controls.Add(CheeseCheckBox);

            TomatoCheckBox = new CheckBox()
            {
                Text = "Tomatoes",
                Location = new Point(10, 130)
            };
            TomatoCheckBox.CheckedChanged += TomatoCheckBox_CheckedChanged;
            this.Controls.Add(TomatoCheckBox);

            // Додати кнопку "Замовити"
            var orderButton = new Button()
            {
                Text = "Order",
                Location = new Point(10, 170)
            };
            orderButton.Click += button4_Click;
            this.Controls.Add(orderButton);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void CheeseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                var decorator = new Cheese(_pizza);
                _decorators.Add(decorator);
                _pizza = decorator;
            }
            else
            {
                var decorator = _decorators.Find(d => d.GetType() == typeof(Cheese));
                if (decorator != null)
                {
                    _decorators.Remove(decorator);
                    _pizza = _decorators.Count > 0 ? _decorators.Last() : (IPizza)new PrepOfPizza();
                }
            }
        }

        public void TomatoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                var decorator = new Tomatoes(_pizza);
                _decorators.Add(decorator);
                _pizza = decorator;
            }
            else
            {
                var decorator = _decorators.Find(d => d.GetType() == typeof(Tomatoes));
                if (decorator != null)
                {
                    _decorators.Remove(decorator);
                    _pizza = _decorators.Count > 0 ? _decorators.Last() : (IPizza)new PrepOfPizza();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = _pizza.WhatYouHave();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            // Отримати шлях до загального зображення піци
            string imagePath = _pizzaImages["None"];

            // Додати до шляху зображення декораторів, якщо вони були вибрані
            if (CheeseCheckBox.Checked)
            {
                imagePath = _pizzaImages["Cheese"];
            }
            if (TomatoCheckBox.Checked)
            {
                imagePath = _pizzaImages["Tomatoes"];
            }
            if (CheeseCheckBox.Checked && TomatoCheckBox.Checked)
            {
                imagePath =_pizzaImages["CheeseAndTomatoes"];
            }    

            // Встановити властивість ImageLocation елемента pictureBox1 на оновлений шлях до зображення піци
            pictureBox1.ImageLocation = imagePath;
        }
    }
}
