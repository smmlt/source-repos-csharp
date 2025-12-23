#include <iostream>
#include <string>
#include <initializer_list>
using namespace std;

template <typename T>
class Stack
{    
    size_t size;
    size_t capacity;
    T* mas;

public:

    Stack(size_t _capacity) : size{ 0 }, capacity{ _capacity }, mas{ new T[capacity]{} } {}
    Stack() : Stack(10) {}
    ~Stack() { delete[] mas; }

    bool is_full() const { return size == capacity; }
    bool is_empty() const { return size == 0; }
    size_t get_size() const { return size; }
    void clear() 
    {
        size = 0;
        capacity = 10;
        delete[] mas;
        mas = new T[capacity]{};
    }

    void show()
    {
        for (int i = 0; i < size; i++)
        {
            cout << mas[i] << " ";
        }
        cout << endl;
    }

    void push(T element)
    {
        if (is_full())
        {
            capacity += 10;
            T* temp = new T[capacity];
            for (int i = 0; i < size; i++)
            {
                temp[i] = mas[i];
            }
            delete[] mas;
            mas = temp;
        }
        mas[size] = element;
        size++;
    }

    void pop()
    {
        if (!is_empty())
            size--;
    }
      
    T top()
    {
        if (!is_empty())
            return mas[size - 1];
    }


    Stack(const initializer_list<T>& list) : size{ list.size() }, capacity{ size + 10 }, mas{ new T[capacity]{} }
    {
        int i = 0;

        for (auto element : list)
        {
            mas[i] = element;
            i++;
        }
    }
};

int main()
{
    Stack<int> st({ 2, 43, 6, 45, -5, 4 });
    st.show();
    
    st.push(5);
    st.show();
   
    st.pop();
    st.show();

    st.push(2);
    st.show();

    st.top();
    st.show();

    st.clear();
}

