using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorks
{
    public class SingleLinkedList
    {
        private SingleNode head;
        private int size;
        public SingleLinkedList()
        {
            head = null;
            size = 0;
        }

        /// <summary>
        /// Конструктор. Создает SingleArrayList, заполняя его заданным массивом значений
        /// </summary>
        /// <param name="values">Массив значений для заполнения</param>
        public SingleLinkedList(int[] values)
        {
            if (values.Length == 0) return;
            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i]);
            }
        }

        /// <summary>
        /// Добавить значение в конец SingleArrayList
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        public void AddLast(int value)
        {
            SingleNode newNode = new SingleNode(value);
            if (head == null)//список пустой-добавляем первый элемент
            {
                head = newNode;
            }
            else
            {
                //список не пустой-надо пройтись по списку до последнего, затем добавить новый элемент
                SingleNode curentNode = head;
                while (curentNode.Next != null)
                {
                    curentNode = curentNode.Next;
                }
                curentNode.Next = newNode;
            }
            size += 1;
        }

        /// <summary>
        /// Вставить элемент в позицию
        /// </summary>
        /// <param name="index">позиция</param>
        /// <param name="value">элемент для вставки</param>
        public void AddAt(int index, int value)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentException("Неверное значение index");
            }
            if (index == 0)
            {
                SingleNode newNode = new SingleNode(value);
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                SingleNode curentNode = head;
                for (int i = 0; i < index - 1; i++)
                {
                    curentNode = curentNode.Next;
                }

                SingleNode newNode = new SingleNode(value);
                newNode.Next = curentNode.Next;
                curentNode.Next = newNode;
            }
            size += 1;
        }

        /// <summary>
        /// Преобразует SingleArrayList в одномерный массив значений
        /// </summary>
        /// <returns>Значения SingleArrayList в виде одномерного массива</returns>
        public int[] ToArray()
        {
            if (size == 0)
            {
                return new int[] { };
            }
            else
            {
                int[] result = new int[size];
                SingleNode nextNode = head;
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = nextNode.Value;
                    nextNode = nextNode.Next;
                }

                return result;
            }

        }

        /// <summary>
        /// Размер SingleArrayList
        /// </summary>
        /// <returns>Размер SingleArrayList</returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// Значение элемента списка по индексу index
        /// </summary>
        /// <param name="index">индекс элемента</param>
        /// <returns></returns>
        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentException("Неверное значение index");
            }
            SingleNode curentNode = head;
            for (int i = 0; i < index; i++)
            {
                curentNode = curentNode.Next;
            }
            return curentNode.Value;
        }

        /// <summary>
        /// Добавить массив элементов в конец
        /// </summary>
        /// <param name="values">Массив добавляемых элементов</param>
        public void AddLast(int[] values)
        {
            SingleNode curentNode = head;
            if (head == null)
            {
                if (values.Length > 0)
                {
                    SingleNode newNode = new SingleNode(values[0]);
                    head = newNode;
                    size++;
                    for (int i = 1; i < values.Length; i++)
                    {
                        newNode = new SingleNode(values[i]);
                        curentNode.Next = newNode;
                        curentNode = curentNode.Next;
                        size++;
                    }
                }

            }
            else
            {

                while (curentNode.Next != null)
                {
                    curentNode = curentNode.Next;
                }

                for (int i = 0; i < values.Length; i++)
                {
                    SingleNode newNode = new SingleNode(values[i]);
                    curentNode.Next = newNode;
                    curentNode = curentNode.Next;
                    size++;
                }
            }
        }


        /// <summary>
        /// Добавить массив элементов в позицию index со сдвигом оставшихся элементов вправо
        /// </summary>
        /// <param name="index">Позиция, на которую добавляем элменты</param>
        /// <param name="values">Массив добавляемых элементов</param>
        public void AddAt(int index, int[] values)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentException("Неверное значение index");
            }
            SingleNode curentNode = head;

            if (index >= 0 && index < size && size > 0)
            {
                for (int i = 0; i < index - 1 && curentNode.Next != null; i++)
                {
                    curentNode = curentNode.Next;
                }
                SingleNode rightPartNode = curentNode.Next;

                if (index == 0)
                {
                    rightPartNode = curentNode;
                    SingleNode startLeftNode = new SingleNode(values[0]);
                    SingleNode node = startLeftNode;
                    size++;
                    for (int i = 1; i < values.Length; i++)
                    {
                        SingleNode newNode = new SingleNode(values[i]);
                        node.Next = newNode;
                        node = node.Next;
                    }
                    node.Next = rightPartNode;
                    head = startLeftNode;
                }
                else
                {
                    rightPartNode = curentNode.Next;
                    for (int i = 0; i < values.Length; i++)
                    {
                        SingleNode newNode = new SingleNode(values[i]);
                        curentNode.Next = newNode;
                        curentNode = curentNode.Next;
                        size++;
                    }

                    curentNode.Next = rightPartNode;
                }


            }
        }
        /// <summary>
        /// Опередляет присутствует ли элемент в SingleLinkedList
        /// </summary>
        /// <param name="value">Элемент для поиска</param>
        /// <returns>true- элемент присутствует, false - элемент отсутствует</returns>
        public bool Contains(int value)
        {
            SingleNode curentNode = head;
            for (int i = 0; i < size; i++)
            {
                if (curentNode.Value == value)
                {
                    return true;
                }
                else
                {
                    curentNode = curentNode.Next;
                }

            }
            return false;
        }

        /// <summary>
        /// Индекс первого вхождения элемента
        /// </summary>
        /// <param name="value">Элемент</param>
        /// <returns>Индекс первого вхождения элемента value или -1 если элемента нет в SingleArrayList</returns>
        public int IndexOf(int value)
        {
            SingleNode curentNode = head;
            for (int i = 0; i < size; i++)
            {
                if (curentNode.Value == value)
                {
                    return i;
                }
                else
                {
                    curentNode = curentNode.Next;
                }

            }
            return -1;
        }

        /// <summary>
        /// Поменять значние элемента с указанным индексом
        /// </summary>
        /// <param name="idx">Индекс элемента</param>
        /// <param name="val">Новое значение элемента</param>
        public void Set(int idx, int val)
        {
            if (idx < 0 || idx >= size)
            {
                throw new ArgumentException("Неверное значение index");
            }

            SingleNode curentNode = head;
            for (int i = 0; i < idx; i++)
            {
                curentNode = curentNode.Next;
            }
            curentNode.Value = val;

        }

        /// <summary>
        /// Значение первого элемента списка
        /// </summary>
        /// <returns>Значение первого элемента списка</returns>
        public int GetFirst()
        {
            if (size == 0)
            {
                throw new NullReferenceException("Список пуст");
            }

            return head.Value;

        }

        /// <summary>
        /// Значение последнего элемента списка
        /// </summary>
        /// <returns>Значение последнего элемента списка</returns>
        public int GetLast()
        {
            if (size == 0)
            {
                throw new NullReferenceException("Список пуст");
            }

            SingleNode curentNode = head;
            while (curentNode.Next != null)
            {
                curentNode = curentNode.Next;
            }

            return curentNode.Value;

        }

        /// <summary>
        /// Добавление элемента в начало списка
        /// </summary>
        /// <param name="val">элемент для добавления</param>
        public void AddFirst(int val)
        {
            SingleNode newNode = new SingleNode(val);
            newNode.Next = head;
            head = newNode;
            size++;
        }

        /// <summary>
        /// Добавить массив значений в начало списка
        /// </summary>
        /// <param name="vals">Массив добавляемых значений</param>
        public void AddFirst(int[] vals)
        {
            if (vals.Length == 0) return;

            SingleNode newNode = new SingleNode(vals[0]);
            SingleNode start = newNode;
            for (int i = 1; i < vals.Length; i++)
            {
                SingleNode node = new SingleNode(vals[i]);
                newNode.Next = node;
                newNode = newNode.Next;
            }

            newNode.Next = head;
            head = start;
            size += vals.Length;
        }

        /// <summary>
        /// Удаление первого элемента списка
        /// </summary>
        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
                size--;
            }

        }

        /// <summary>
        /// Удалеие последнего элемента
        /// </summary>
        public void RemoveLast()
        {
            if (head != null)
            {
                SingleNode curentNode = head;
                for (int i = 1; i < size - 1; i++)
                {
                    curentNode = curentNode.Next;
                }
                curentNode.Next = null;
                size--;
            }
        }

        /// <summary>
        /// Удаление элемента по индексу
        /// </summary>
        /// <param name="idx">Индекс удаляемого элемента</param>
        public void RemoveAt(int idx)
        {
            if (idx < 0 || idx >= size)
            {
                throw new ArgumentException("Неверное значение index");
            }
            if (head == null) return;

            if (idx > 0)
            {
                SingleNode curentNode = head;
                for (int i = 0; i < idx - 1; i++)
                {
                    curentNode = curentNode.Next;
                }
                curentNode.Next = curentNode.Next.Next;
                size--;
            }
            else
            {
                head = head.Next;
                size--;
            }
        }

        /// <summary>
        /// Удалить все вхождения элемента
        /// </summary>
        /// <param name="val">Значение элемента, который надо удалить</param>
        public void RemoveAll(int val)
        {
            SingleNode curentNode = head;

            while (curentNode.Next != null)
            {
                if (curentNode.Next.Value == val)
                {
                    curentNode.Next = curentNode.Next.Next;
                    size--;
                }
                else
                {
                    curentNode = curentNode.Next;
                }
            }

            if (head.Value == val)
            {
                head = head.Next;
                size--;
            }
        }

        /// <summary>
        /// Изменение порядка элементов списка на обратный
        /// </summary>
        public void Reverse()
        {
            if (size > 0)
            {
                SingleNode prevNode = null, curentNode = head, nextNode = head.Next;

                while (nextNode != null)
                {
                    curentNode.Next = prevNode;
                    prevNode = curentNode;
                    curentNode = nextNode;
                    nextNode = curentNode.Next;
                }
                curentNode.Next = prevNode;
                head = curentNode;
            }

        }

        /// <summary>
        /// Изменение порядка элементов списка на обратный
        /// </summary>
        public void ReveseMaximVariant()
        {
            if (head == null) return;

            SingleNode tmp = head;
            while (tmp.Next != null)
            {
                SingleNode tmp1 = tmp.Next;
                tmp.Next = tmp.Next.Next;
                tmp1.Next = head;
                head = tmp1;
            }
        }
    }
}
