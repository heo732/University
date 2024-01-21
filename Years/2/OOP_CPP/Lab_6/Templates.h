 //---------------------------------------------------------------------------
#ifndef TemplatesH
#define TemplatesH
//---------------------------------------------------------------------------
#include <cmath>
//---------------------------------------------------------------------------
long round(double value)
{
        if(value > 0)
                return ((int)(value*10) % 10 >= 5) ? (long) std::ceil(value) : std::floor(value);
        if(value < 0)
                return ((int)(value*10) % 10 >= 5) ? (long) std::floor(value) : std::ceil(value);
        return 0;
}
//---------------------------------------------------------------------------
template <class T>
T average(T* array, unsigned int size)
{
        T sum = array[0];
        for(unsigned int i = 1; i < size; i++)
                sum += array[i];
        return sum / size;
}
//---------------------------------------------------------------------------
char average(char* array, unsigned int size)
{
        int sum = array[0];
        for(unsigned int i = 1; i < size; i++)
                sum += array[i];
        return (char) round((double)sum / size);
}
//---------------------------------------------------------------------------
template <class T>
void sortSelection(T*& array, unsigned int length)
{
        unsigned int iMin;
        for(unsigned int i = 0; i < length-1; i++)
    	{
    	       	iMin = i;
    		for(unsigned int j = i+1; j < length; j++)
                        if(array[iMin] > array[j])  //if(array[iMin] < array[j])
                                iMin = j;
    		T temp = array[iMin];
    		array[iMin] = array[i];
    		array[i] = temp;
    	}
}
//---------------------------------------------------------------------------
void sortSelection(char*& array, unsigned int length)
{
        unsigned int iMin;
        for(unsigned int i = 0; i < length-1; i++)
    	{
    	       	iMin = i;
    		for(unsigned int j = i+1; j < length; j++)
                        if(array[iMin] > array[j])  //if(array[iMin] < array[j])
                                iMin = j;
    		char temp = array[iMin];
    		array[iMin] = array[i];
    		array[i] = temp;
    	}
}
//---------------------------------------------------------------------------
template <class T>
class CyclicQueue
{
protected:

        struct Node
        {
                T data;
                Node* next;
                Node* prev;
        };

        Node* _head;

public:

        CyclicQueue() : _head(NULL) {}

        ~CyclicQueue()
        {
                clear();
        }

        CyclicQueue(T data, unsigned int count = 1)
        {
                _head = NULL;
                push(data, count);
        }

        void push(T data, unsigned int count = 1)
        {
                if(_head)
                {
                        for(unsigned int i = 0; i < count; i++)
                        {
                                Node* temp = new Node;
                                temp->data = data;
                                temp->next = _head;
                                temp->prev = _head->prev;
                                _head->prev->next = temp;
                                _head->prev = temp;
                        }
                }
                else
                {
                        _head = new Node;
                        _head->data = data;
                        _head->next = _head;
                        _head->prev = _head;

                        for(unsigned int i = 1; i < count; i++)
                        {
                                Node* temp = new Node;
                                temp->data = data;
                                temp->next = _head;
                                temp->prev = _head->prev;
                                _head->prev->next = temp;
                                _head->prev = temp;
                        }
                }
        }

        void pop(unsigned int count = 1)
        {
                unsigned int z = 0;
                while(z < count && length() > 1)
                {
                        _head->prev->next = _head->next;
                        _head->next->prev = _head->prev;
                        Node* temp = _head;
                        _head = _head->next;
                        delete temp;
                        z++;
                }
                if(z < count-1)
                {
                        delete _head;
                        _head = NULL;
                }
        }

        unsigned int length()
        {
                unsigned int count = 0;
                if(_head)
                {
                        Node* temp = _head;
                        count++;
                        temp = temp->next;
                        while(temp != _head)
                        {
                                count++;
                                temp = temp->next;
                        }
                }
                return count;
        }

        void clear()
        {
                pop(length());
        }

        T get()
        {
                return _head->data;
        }

        void next()
        {
                _head = _head->next;
        }

        void prev()
        {
                _head = _head->prev;
        }

        CyclicQueue& operator ++()
        {
                next();
                return *this;
        }

        CyclicQueue& operator ++(int)
        {
                next();
                return *this;
        }

        CyclicQueue& operator --()
        {
                prev();
                return *this;
        }

        CyclicQueue& operator --(int)
        {
                prev();
                return *this;
        }

};
//---------------------------------------------------------------------------
template<class T>
class Iterator
{
private:

        T* _current;

public:

        Iterator(T* curr) : _current(curr)
        {
        }

        Iterator& operator =(const Iterator& in)
        {
                if(this != &in)
                        _current = in._current;
                return *this;
        }

        Iterator& operator ++()
        {
                _current++;
                return *this;
        }

        Iterator& operator ++(int)
        {
                _current++;
                return *this;
        }

        T& operator *()
        {
                return *_current;
        }

        T* operator ->()
        {
                return _current;
        }

        bool operator ==(const Iterator& in)
        {
                return _current == in._current;
        }

        bool operator !=(const Iterator& in)
        {
                return !(*this == in);
        }

};
//---------------------------------------------------------------------------
template<class T>
class Array
{
private:

        T* _array;
        unsigned int _length;

public:

        typedef Iterator<T> iterator;

        Array() : _array(NULL), _length(0) {}

        Array(unsigned int length) : _array(new T[length]), _length(length) {}

        ~Array()
        {
                if(_array)
                        delete _array;
        }

        void clear()
        {
                if(_array)
                        delete _array;
                _array = NULL;
        }

        void resize(unsigned int size)
        {
                if(_array)
                        delete _array;
                _array = new T[size];
                _length = size;
        }

        unsigned int length()
        {
                return _length;
        }

        Array& operator = (Array arr)
        {
                if(arr._array)
                {
                        resize(arr.length());
                        for(unsigned int i = 0; i < _length; i++)
                                _array[i] = arr._array[i];
                }
                else
                        clear();
                return *this;
        }

        T& operator [] (unsigned int index)
        {
                if(_array)
                        if(index < _length)
                                return _array[index];
                        else
                                return _array[0];
                return *(new T(0));
        }

        void pushBack(T node)
        {
                if(_array)
                {
                        Array<T> temp;
                        temp = *this;
                        resize(_length+1);
                        for(unsigned int i = 0; i < temp.length(); i++)
                                _array[i] = temp[i];
                        _array[_length-1] = node;
                }
                else
                {
                        _array = new T[1];
                        _array[0] = node;
                        _length = 1;
                }
        }

        void pushFront(T node)
        {
                if(_array)
                {
                        Array<T> temp;
                        temp = *this;
                        resize(_length+1);
                        for(unsigned int i = 0; i < temp.length(); i++)
                                _array[i+1] = temp[i];
                        _array[0] = node;
                }
                else
                {
                        _array = new T[1];
                        _array[0] = node;
                        _length = 1;
                }
        }

        void popBack()
        {
                if(_array)
                {
                        if(_length == 1)
                                clear();
                        else
                        {
                                Array<T> temp;
                                temp = *this;
                                resize(_length-1);
                                for(unsigned int i = 0; i < _length; i++)
                                        _array[i] = temp[i];
                        }
                }
        }

        void popFront()
        {
                if(_array)
                {
                        if(_length == 1)
                                clear();
                        else
                        {
                                Array<T> temp;
                                temp = *this;
                                resize(_length-1);
                                for(unsigned int i = 0; i < _length; i++)
                                        _array[i] = temp[i+1];
                        }
                }
        }

        void sort()
        {
                if(_array && _length>1)
                        sortSelection<T>(_array, _length);
        }

        void reverse()
        {
                if(_array && _length>1)
                {
                        Array<T> temp;
                        temp = *this;
                        for(unsigned int a = 0, unsigned int t = _length-1; a < _length, t >= 0; a++, t--)
                                _array[a] = temp[t];
                }
        }

        Iterator<T> begin()
        {
                return Iterator<T>(_array);
        }

        Iterator<T> end()
        {
                return Iterator<T>(_array + _length);
        }
};
//---------------------------------------------------------------------------
#endif

