//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H

//---------------------------------------------------------------------------
long round(double value);
//---------------------------------------------------------------------------
template <class T>
T average(T* array, unsigned int size);
//---------------------------------------------------------------------------
//char average(char* array, unsigned int size);
//---------------------------------------------------------------------------
template <class T>
void sortSelection(T*& array, unsigned int length);
//---------------------------------------------------------------------------
//void sortSelection(char*& array, unsigned int length);
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

        ~CyclicQueue();

        CyclicQueue(T data, unsigned int count = 1);

        void push(T data, unsigned int count = 1);

        void pop(unsigned int count = 1);

        unsigned int length();

        void clear();

        T get();

        void next();

        void prev();

        CyclicQueue& operator ++();

        CyclicQueue& operator ++(int);

        CyclicQueue& operator --();

        CyclicQueue& operator --(int);

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

        Iterator& operator =(const Iterator& in);

        Iterator& operator ++();

        Iterator& operator ++(int);

        T& operator *();

        T* operator ->();

        bool operator ==(const Iterator& in);

        bool operator !=(const Iterator& in);

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

        ~Array();

        void clear();

        void resize(unsigned int size);

        unsigned int length();

        Array& operator = (Array arr);

        T& operator [] (unsigned int index);

        void pushBack(T node);

        void pushFront(T node);

        void popBack();

        void popFront();

        void sort();

        void reverse();

        Iterator<T> begin();

        Iterator<T> end();
        
};
//---------------------------------------------------------------------------
#endif


