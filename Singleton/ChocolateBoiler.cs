using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// бойлер для нагрева шоколадной смеси
    /// </summary>
    class ChocolateBoiler
    {

        /// <summary>
        /// пустой ли бойлер
        /// </summary>
        private static bool empty;

        /// <summary>
        /// нагрета ли смесь
        /// </summary>
        private static bool boiled;

        /// <summary>
        /// Уникальный экземпляр класса
        /// </summary>
        private static ChocolateBoiler uniqueInstance;

        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        ///<summary>
        /// Получить экземпляр класса
        /// </summary>
        public static ChocolateBoiler GetInstance()
        {
            if (uniqueInstance is null)
                uniqueInstance = new ChocolateBoiler();
            return uniqueInstance;
        }

        /// <summary>
        /// наполнение бойлера смесью
        /// </summary>
        /// <remarks>
        /// перед наполнением мы проверяем, что нагреватель пуст,
        /// а после наполнения устанавливаем флаги empty и boiled
        /// </remarks>
        public void fill()
        {
            if (isEmpty())
            {
                empty = false;
                boiled = false;
                Console.WriteLine("Заполнение нагревателя молочно-шоколадной смесью");
            }
        }

        /// <summary>
        /// сливает готовую смесь
        /// </summary>
        /// <remarks>
        /// чтобы слить содержимое, мы проверяем, что нагреватель не пуст,
        /// а смесь доведена до кипения.
        /// После слива флагу empty снова присваивается true
        /// </remarks>
        public void drain()
        {
            if (!isEmpty() && isBoiled())
            {
                Console.WriteLine("Слить нагретое молоко и шоколад"); 
                empty = true;
            }
        }

        /// <summary>
        /// нагревание бойлера
        /// </summary>
        /// <remarks>
        /// чтобы вскипятить смесь, мы проверяем, что нагреватель
        /// полон, но ещё не нагрет. После нагревания флагу
        /// boiled присваивается true
        /// </remarks>
        public void boil()
        {
            if (!isEmpty() && !isBoiled())
            {
                Console.WriteLine("Довести содержимое до кипения");
                boiled = true;
            }
        }

        /// <summary>
        /// Determines whether this instance is boiled.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is boiled; otherwise, <c>false</c>.
        /// </returns>
        public bool isBoiled()
        {
            return boiled;
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool isEmpty()
        {
            return empty;
        }
    }
}
