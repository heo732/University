//---------------------------------------------------------------------------
#pragma hdrstop
#include "Unit1.h"
#pragma package(smart_init)
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
/*char average(char* array, unsigned int size)
{
        int sum = array[0];
        for(unsigned int i = 1; i < size; i++)
                sum += array[i];
        return (char) round((double)sum / size);
}*/
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
/*void sortSelection(char*& array, unsigned int length)
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
}*/
//---------------------------------------------------------------------------
template <class T>
CyclicQueue<T>::~CyclicQueue()
{
        clear();
}

template <class T>
CyclicQueue<T>::CyclicQueue(T data, unsigned int count)
{
        _head = NULL;
        push(data, count);
}

template <class T>
void CyclicQueue<T>::push(T data, unsigned int count)
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

template <class T>
void CyclicQueue<T>::pop(unsigned int count)
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

template <class T>
unsigned int CyclicQueue<T>::length()
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

template <class T>
void CyclicQueue<T>::clear()
{
        pop(length());
}

template <class T>
T CyclicQueue<T>::get()
{
        return _head->data;
}

template <class T>
void CyclicQueue<T>::next()
{
        _head = _head->next;
}

template <class T>
void CyclicQueue<T>::prev()
{
        _head = _head->prev;
}

template <class T>
CyclicQueue<T>& CyclicQueue<T>::operator ++()
{
        next();
        return *this;
}

template <class T>
CyclicQueue<T>& CyclicQueue<T>::operator ++(int)
{
        next();
        return *this;
}

template <class T>
CyclicQueue<T>& CyclicQueue<T>::operator --()
{
        prev();
        return *this;
}

template <class T>
CyclicQueue<T>& CyclicQueue<T>::operator --(int)
{
        prev();
        return *this;
}

//---------------------------------------------------------------------------
template<class T>
Iterator<T>& Iterator<T>::operator =(const Iterator& in)
{
        if(this != &in)
                _current = in._current;
        return *this;
}

template<class T>
Iterator<T>& Iterator<T>::operator ++()
{
        _current++;
        return *this;
}

template<class T>
Iterator<T>& Iterator<T>::operator ++(int)
{
        _current++;
        return *this;
}

template<class T>
T& Iterator<T>::operator *()
{
        return *_current;
}

template<class T>
T* Iterator<T>::operator ->()
{
        return _current;
}

template<class T>
bool Iterator<T>::operator ==(const Iterator& in)
{
        return _current == in._current;
}

template<class T>
bool Iterator<T>::operator !=(const Iterator& in)
{
        return !(*this == in);
}

//---------------------------------------------------------------------------
template<class T>
Array<T>::~Array()
{
        if(_array)
                delete _array;
}

template<class T>
void Array<T>::clear()
{
        if(_array)
                delete _array;
        _array = NULL;
}

template<class T>
void Array<T>::resize(unsigned int size)
{
        if(_array)
                delete _array;
        _array = new T[size];
        _length = size;
}

template<class T>
unsigned int Array<T>::length()
{
        return _length;
}

template<class T>
Array<T>& Array<T>::operator = (Array arr)
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

template<class T>
T& Array<T>::operator [] (unsigned int index)
{
        if(_array)
                if(index < _length)
                        return _array[index];
                else
                        return _array[0];
        return *(new T(0));
}

template<class T>
void Array<T>::pushBack(T node)
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

template<class T>
void Array<T>::pushFront(T node)
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

template<class T>
void Array<T>::popBack()
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

template<class T>
void Array<T>::popFront()
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

template<class T>
void Array<T>::sort()
{
        if(_array && _length>1)
        sortSelection<T>(_array, _length);
}

template<class T>
void Array<T>::reverse()
{
        if(_array && _length>1)
        {
                Array<T> temp;
                temp = *this;
                for(unsigned int a = 0, unsigned int t = _length-1; a < _length, t >= 0; a++, t--)
                        _array[a] = temp[t];
        }
}

template<class T>
Iterator<T> Array<T>::begin()
{
        return Iterator<T>(_array);
}

template<class T>
Iterator<T> Array<T>::end()
{
        return Iterator<T>(_array + _length);
}
//---------------------------------------------------------------------------

