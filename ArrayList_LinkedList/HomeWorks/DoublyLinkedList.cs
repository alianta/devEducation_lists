using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorks
{
    public class DoublyLinkedList
    {
        private DoublyNode head;
        private int size;
        public DoublyLinkedList()
        {
            head = null;
            size = 0;
        }

        /// <summary>
        /// Конструктор. Создает DoublyLinkedList, заполняя его заданным массивом значений
        /// </summary>
        /// <param name="values">Массив значений для заполнения</param>
        public DoublyLinkedList(int[] values)
        {
            if (values.Length == 0) return;
            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i]);
            }
        }

        /// <summary>
        /// Добавить значение в конец DoublyLinkedList
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        public void AddLast(int value)
        {
            DoublyNode newNode = new DoublyNode(value);
            if (head == null)//список пустой-добавляем первый элемент
            {
                head = newNode;
            }
            else
            {
                //список не пустой-надо пройтись по списку до последнего, затем добавить новый элемент
                DoublyNode curentNode = head;
                while (curentNode.Next != null)
                {
                    curentNode = curentNode.Next;
                }
                newNode.Prev = curentNode;
                curentNode.Next = newNode;
            }
            size++;
        }

        /// <summary>
        /// Удаление первого элемента списка
        /// </summary>
        public void RemoveFirst()
        {
            if (head != null)
            {
                head.Prev = null;
                head = head.Next;
                size--;
            }
        }


        /// <summary>
        /// Преобразует DoublyLinkedList в одномерный массив значений
        /// </summary>
        /// <returns>Значения DoublyLinkedList в виде одномерного массива</returns>
        public int[] ToArray()
        {
            if (size == 0)
            {
                return new int[] { };
            }
            else
            {
                int[] result = new int[size];
                DoublyNode nextNode = head;
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = nextNode.Value;
                    nextNode = nextNode.Next;
                }

                return result;
            }

        }
        /// <summary>
        /// Преобразует DoublyLinkedList в одномерный массив значений в оратном порядке
        /// </summary>
        /// <returns>Значения DoublyLinkedList в виде одномерного массива</returns>
        public int[] ToArrayReverse()
        {
            if (size == 0)
            {
                return new int[] { };
            }else if (size == 1)
            {
                return new int[] { head.Value};
            }
            else
            {
                int[] result = new int[size];
                //проходим до конца
                DoublyNode curentNode = head;
                for (int i = 1; i < size - 1; i++)
                {
                    curentNode = curentNode.Next;
                }
                DoublyNode nextNode = curentNode.Next;
                for (int i = 0; i < size; i++)
                {
                    result[i] = nextNode.Value;
                    nextNode = nextNode.Prev;
                }

                return result;
            }

        }


        /// <summary>
        /// Размер DoublyLinkedList
        /// </summary>
        /// <returns>Размер DoublyLinkedList</returns>
        public int GetSize()
        {
            return size;
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
            DoublyNode curentNode = head;
            for (int i = 0; i < idx; i++)
            {
                curentNode = curentNode.Next;
            }
            curentNode.Value = val;
        }

        /// <summary>
        /// Удалеие последнего элемента
        /// </summary>
        public void RemoveLast()
        {
            if (head != null)
            {
                DoublyNode curentNode = head;
                for (int i = 1; i < size - 1; i++)
                {
                    curentNode = curentNode.Next;
                }
                curentNode.Next = null;
                size--;
            }
        }

        /// <summary>
        /// Опередляет присутствует ли элемент в DoublyLinkedList
        /// </summary>
        /// <param name="value">Элемент для поиска</param>
        /// <returns>true- элемент присутствует, false - элемент отсутствует</returns>
        public bool Contains(int value)
        {
            DoublyNode curentNode = head;
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
            DoublyNode curentNode = head;
            for (int i = 0; i < index; i++)
            {
                curentNode = curentNode.Next;
            }
            return curentNode.Value;
        }


        /// <summary>
        /// Индекс первого вхождения элемента
        /// </summary>
        /// <param name="value">Элемент</param>
        /// <returns>Индекс первого вхождения элемента value или -1 если элемента нет в DoublyArrayList</returns>
        public int IndexOf(int value)
        {
            DoublyNode curentNode = head;
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

            DoublyNode curentNode = head;
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
            DoublyNode newNode = new DoublyNode(val);
            if (head != null)
            {
                newNode.Next = head;
                head.Prev = newNode;
            }
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

            DoublyNode newNode = new DoublyNode(vals[0]);
            DoublyNode start = newNode;
            for (int i = 1; i < vals.Length; i++)
            {
                DoublyNode node = new DoublyNode(vals[i]);
                node.Prev = newNode;
                newNode.Next = node;
                newNode = newNode.Next;
            }
            if (head != null) head.Prev = newNode;
            newNode.Next = head;
            head = start;
            size += vals.Length;

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
            if (head != null)
            {
                if (idx > 0)
                {
                    DoublyNode curentNode = head;
                    for (int i = 0; i < idx - 1; i++)
                    {
                        curentNode = curentNode.Next;
                    }
                    DoublyNode rightPart = curentNode.Next.Next;
                    curentNode.Next = rightPart;
                    if (rightPart != null)
                    {
                        rightPart.Prev = curentNode;
                    }
                    size--;
                }
                else
                {
                    //idx==0
                    head = head.Next;
                    if (head != null) head.Prev = null;
                    size--;
                }

            }
        }

        /// <summary>
        /// Удалить все вхождения элемента
        /// </summary>
        /// <param name="val">Значение элемента, который надо удалить</param>
        public void RemoveAll(int val)
        {
            DoublyNode curentNode = head;

            while (curentNode.Next != null)
            {

                if (curentNode.Next.Value == val)
                {
                    DoublyNode nextNode = curentNode.Next.Next;
                    if (nextNode != null) nextNode.Prev = curentNode;
                    curentNode.Next = nextNode;
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
        /// Добавить значение в конец списка
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        public void AddLast(int[] values)
        {
            if (values.Length == 0) return;
            DoublyNode curentNode = head;
            if (head == null)
            {
                //список пуст,добавляем элементы с начала
                if (values.Length > 0)
                {
                    DoublyNode newNode = new DoublyNode(values[0]);
                    head = newNode;
                    size++;
                    for (int i = 1; i < values.Length; i++)
                    {
                        newNode = new DoublyNode(values[i]);
                        newNode.Prev = curentNode;
                        curentNode.Next = newNode;
                        curentNode = curentNode.Next;
                        size++;
                    }
                }

            }
            else
            {
                //список не пуст-идем до конца списка
                while (curentNode.Next != null)
                {
                    curentNode = curentNode.Next;
                }
                //добавляем в конец списка
                for (int i = 0; i < values.Length; i++)
                {
                    DoublyNode newNode = new DoublyNode(values[i]);
                    newNode.Prev = curentNode;
                    curentNode.Next = newNode;
                    curentNode = curentNode.Next;
                    size++;
                }
            }
        }

        /// <summary>
        /// Изменение порядка элементов списка на обратный
        /// </summary>
        public void Reverse()
        {
            if (size <= 1) return;

          
            if (size > 0)
            {
                 DoublyNode prevNode = null, curentNode = head, nextNode = head.Next;

                 while (nextNode != null)
                 {
                     if (prevNode != null) prevNode.Prev = curentNode;
                     curentNode.Next = prevNode;
                     prevNode = curentNode;
                     curentNode = nextNode;
                     nextNode = curentNode.Next;
                 }
                 if (prevNode != null) prevNode.Prev = curentNode;
                 curentNode.Next = prevNode;
                 head = curentNode;
               
            }

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
                DoublyNode newNode = new DoublyNode(value);
                if (head != null) head.Prev = newNode;
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                DoublyNode curentNode = head;
                for (int i = 0; i < index - 1; i++)
                {
                    curentNode = curentNode.Next;
                }

                DoublyNode newNode = new DoublyNode(value);
                curentNode.Next.Prev = newNode;
                newNode.Prev = curentNode;
                newNode.Next = curentNode.Next;
                curentNode.Next = newNode;
            }
            size += 1;
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

            if (values.Length == 0) return;

            DoublyNode curentNode = head;

            for (int i = 0; i < index - 1 && curentNode.Next != null; i++)
            {
                curentNode = curentNode.Next;
            }
            DoublyNode rightPartNode;
            if (index == 0)
            {
                rightPartNode = curentNode;
                DoublyNode startLeftNode = new DoublyNode(values[0]);
                DoublyNode node = startLeftNode;
                size++;
                for (int i = 1; i < values.Length; i++)
                {
                    DoublyNode newNode = new DoublyNode(values[i]);
                    newNode.Prev = node;
                    node.Next = newNode;
                    node = node.Next;
                }
                rightPartNode.Prev = node;
                node.Next  =rightPartNode;
                head = startLeftNode;
            }
            else
            {
                rightPartNode = curentNode.Next;
                for (int i = 0; i < values.Length; i++)
                {
                    DoublyNode newNode = new DoublyNode(values[i]);
                    newNode.Prev = curentNode;
                    curentNode.Next = newNode;
                    curentNode = curentNode.Next;
                    size++;
                }
                rightPartNode.Prev = curentNode;
                curentNode.Next = rightPartNode;
            }
        }
    }
}
