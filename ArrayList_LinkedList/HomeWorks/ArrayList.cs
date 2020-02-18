using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorks
{
    public class ArrayList
    {
        private int reallength;
        private int[] array;

        //конструктор
        public ArrayList()
        {
            array = new int[10];
            reallength = 0;
        }
        //конструктор
        public ArrayList(int[] array)
        {
            this.array = new int[(array.Length < 10) ? 10 : array.Length];
            int i;
            for (i = 0; i < array.Length; i++)
            {
                this.array[i] = array[i];
            }
            reallength = array.Length;
        }
        /// <summary>
        /// Количество элементов в ArrayList
        /// </summary>
        /// <returns>Длина ArrayList</returns>
        public int Size()
        {
            return reallength;
        }
        /// <summary>
        /// Увеличение длины массива (внутренний закрытый метод)
        /// </summary>
        private void IncreaseArray()
        {
            //увеличиваем длину массива
            int[] newArray = new int[reallength * 3 / 2 + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        /// <summary>
        ///  Увеличение длины массива (внутренний закрытый метод)
        /// </summary>
        /// <param name="increaseCount">количество новых элеиентов, которое необходимо добавить в Array</param>
        private void IncreaseArray(int increaseCount)
        {
            if (increaseCount < 1)
            {
                throw new ArgumentException("Количество элементов < 1");
            }
            //увеличиваем длину массива
            int[] newArray = new int[(reallength + increaseCount) * 3 / 2 + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
        /// <summary>
        /// Добавление элемента в конец ArrayList
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        public void Add(int value)
        {
            if (reallength == array.Length)
            {
                //увеличиваем длину массива
                IncreaseArray();
            }

            array[reallength] = value;
            reallength++;
        }
        /// <summary>
        /// Добавление элемента на конкретную позицию (элементы после позиции сдвигаются вправо на 1)
        /// </summary>
        /// <param name="index">Позиция, на которую добавить элемент</param>
        /// <param name="value">Добавляемое значение в позицию index</param>
        public void Add(int index, int value)
        {
            if (index < reallength && index >= 0)
            {
                if (reallength == array.Length)
                {
                    //увеличиваем длину массива
                    IncreaseArray();
                }
                //т.к. вставляем новый элемент то реальная длина массива увеличится на 1
                reallength++;

                for (int i = reallength - 1; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
                array[index] = value;
            }
            else
            {
                throw new ArgumentException("Неверное значение индекса.");
            }

        }

        /// <summary>
        /// Замена элемента в позиции
        /// </summary>
        /// <param name="index">Позиция в который надо поменять элемент</param>
        /// <param name="value">Новое значение элемента  в позиции index</param>
        public void Set(int index, int value)
        {
            if (index < 0 || index >= reallength)
            {
                throw new ArgumentException("Неверное значение индекса.");
            }
            array[index] = value;
        }
        /// <summary>
        /// Массив элементов ArrayList
        /// </summary>
        /// <returns>Массив элементов ArrayList</returns>
        public int[] GetArrayList()
        {
            int[] result = new int[reallength];
            for (int i = 0; i < reallength; i++)
            {
                result[i] = array[i];
            }
            return result;
            //верусть массив от 0 до reallength
        }

        /// <summary>
        /// Возвращает значение элемента по индексу
        /// </summary>
        /// <param name="index">Индекс возвращаемого элемента</param>
        /// <returns>значение элемента по индексу index</returns>
        public int Get(int index)
        {
            if (index < 0 || index >= reallength)
            {
                throw new ArgumentException("Неверное значение индекса.");
            }
            return array[index];
        }

        /// <summary>
        /// Присутствует ли элемент в ArrayList
        /// </summary>
        /// <param name="val">Значение, которое ищем</param>
        /// <returns>true - val присутствует в ArrayList, false - val отсутствует в ArrayList</returns>
        public bool Contains(int val)
        {
            for (int i = 0; i < reallength; i++)
            {
                if (array[i] == val) return true;
            }
            return false;
        }

        /// <summary>
        /// Индекс первого вхождения элемента
        /// </summary>
        /// <param name="val">Элемент для посика</param>
        /// <returns>Индекс первого найденного элемента val или -1 если val не найден в ArrayList</returns>
        public int IndexOf(int val)
        {
            for (int i = 0; i < reallength; i++)
            {
                if (array[i] == val) return i;
            }
            return -1;
        }

        /// <summary>
        /// Массив индексов всех вхождений элемента
        /// </summary>
        /// <param name="val">Элемент для поиска в ArrayList</param>
        /// <returns>Массив индексов всех вхождений val или пустоф массив если элемента нет в ArrayList</returns>
        public int[] Search(int val)
        {
            int counter = 0;
            //считаем кол-во лементов val в LrrayList, чтобы можно было создать массив
            for (int i = 0; i < reallength; i++)
            {
                if (array[i] == val) counter++;
            }
            //создаем массив и копируем в него индексы
            int[] result = new int[counter];
            int j = 0;
            for (int i = 0; i < reallength; i++)
            {
                if (array[i] == val)
                {
                    result[j] = i;
                    j++;
                }
            }

            return result;
        }

        /// <summary>
        /// Добавляет массив элементов в конец
        /// </summary>
        /// <param name="vals">Массив добавляемых элементов</param>
        public void AddAll(int[] vals)
        {
            if (vals.Length == 0) return;
            int newRealLength = reallength + vals.Length;
            if (newRealLength > array.Length)
            {
                //увеличиваем array, т.к. не хватит
                IncreaseArray(vals.Length);
            }
            int j = 0;
            for (int i = reallength; i < newRealLength; i++, j++)
            {
                array[i] = vals[j];
            }
            reallength = newRealLength;
        }

        /// <summary>
        /// Добавляет массив элементов в нужную позицию в ArrayList (элементы справа от позиции в ArrayList сдвигаются вправо)
        /// </summary>
        /// <param name="index">позиция, в которую надо вставить массив элементов</param>
        /// <param name="vals">массив элементов, которые надо вставить в позицию index</param>
        public void AddAll(int index, int[] vals)
        {
            if (index < 0 || index > reallength)
            {
                throw new ArgumentException("Неверное значение индекса.");
            }
            if (vals.Length == 0) return;

            int newRealLength = reallength + vals.Length;

            if (newRealLength > array.Length)
            {
                //увеличиваем array, т.к. не хватит
                IncreaseArray(vals.Length);
            }
            int[] newArray = new int[array.Length];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }
            int j = 0;
            for (int i = index; i < index + vals.Length; i++)
            {
                newArray[i] = vals[j];
                j++;
            }
            for (int i = index + vals.Length; i < newRealLength; i++)
            {
                newArray[i] = array[i - vals.Length];
            }

            reallength = newRealLength;
            array = newArray;
        }

        /// <summary>
        /// Удаление значения, находящегося в позиции index
        /// </summary>
        /// <param name="index">индекс удаляемого элемента</param>
        public void RemoveIdx(int index)
        {
            if (index < 0 || index >= reallength)
            {
                throw new ArgumentException("Неверное значение индекса.");
            }
            for (int i = index; i < reallength - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[reallength - 1] = 0;
            reallength--;
        }
        /// <summary>
        /// Удалить первое вхождение элемента
        /// </summary>
        /// <param name="val">Значение элемента, которое хотим удалить</param>
        public void Remove(int val)
        {
            int index = IndexOf(val);
            if (index != -1) RemoveIdx(index);
        }
        /// <summary>
        /// Удалить все вхождения элемента
        /// </summary>
        /// <param name="val">Значение элемента, которое хотим удалить</param>
        public void RemoveAll(int val)
        {
            int[] indexes = Search(val);
            for (int i = indexes.Length - 1; i >= 0; i--)
            {
                RemoveIdx(indexes[i]);
            }

            // если слишком много пустых значений, то уменьшить массив array (пересоздать меньшего размера и переписать значения)
            if (reallength < (array.Length - 1) * 2 / 3)
            {
                int[] newArray = new int[reallength * 3 / 2 + 1];
                for (int i = 0; i < reallength; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }

        }
        /// <summary>
        /// Удалить все вхождения элемента (алгоритм работает быстрее, т.к. нет вызыва метода RemoveIdx)
        /// </summary>
        /// <param name="val">Значение элемента, которое хотим удалить</param>
        public void RemoveAllFast(int val)
        {
            int[] temp = new int[reallength];
            int j = 0;
            for (int i = 0; i < reallength; i++)
            {
                if (array[i] != val)
                {
                    temp[j] = array[i];
                    j++;
                }
            }
            array = temp;
            reallength = j;
        }
    }
}
