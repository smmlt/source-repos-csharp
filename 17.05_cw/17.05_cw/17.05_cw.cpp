#include <iostream>
using namespace std;

template<typename T>
class PriorityQueue
{
    int size;
    int capacity;
    int* q;
    int* priority;

public:
    PriorityQueue(int _capacity)
        : size{ 0 }, capacity{ _capacity }, q{ new T[capacity] {} }, priority{ new T[capacity] {} } {}
    ~PriorityQueue()
    {
        delete[] q;
        delete[] priority;
    }

    void clear()
    {
        size = 0;
        capacity = 10;
        delete[] q;
        delete[] priority;
        q = new T[capacity] {};
        priority = new T[capacity] {};
    }
    bool is_empty() const { return size == 0; }
    bool is_full() const { return size == capacity; }
    int get_size() const { return size; }

    void show() const
    {
        for (int i = 0; i < size; i++)
        {
            cout << "Value: " << q[i] << " | Priority: " << priority[i] << endl;
        }
        cout << endl;
    }

    void push(T element, T pr)
    {
        if (!is_full())
        {
            q[size] = element;
            priority[size] = pr;

            size++;
        }
    }

    void pop()
    {
        if (!is_empty())
        {
            int max_priority_element = priority[0];
            int max_priority_index = 0;

            for (int i = 0; i < size; i++)
            {
                if (max_priority_element < priority[i])
                {
                    max_priority_element = priority[i];
                    max_priority_index = i;
                }
            }

            for (int i = max_priority_index; i < size - 1; i++)
            {
                q[i] = q[i + 1];
                priority[i] = priority[i + 1];
            }

            size--;
        }
    }

    int top() const 
    {
        if (!is_empty()) 
        {
            int max_priority_index = 0;
            for (int i = 1; i < size; i++) 
            {
                if (priority[i] > priority[max_priority_index]) 
                {
                    max_priority_index = i;
                }
            }
            return q[max_priority_index];
        }
    }

    void swapq(PriorityQueue& other)
    {
        swap(size, other.size);
        swap(capacity, other.capacity);
        swap(q, other.q);
        swap(priority, other.priority);
    }
};

int main()
{
    srand(time(0));

    PriorityQueue<int> pq(10);

    pq.push(10, 3);
    pq.push(15, 1);
    pq.push(18, 5);
    pq.push(7, 10);
    pq.push(3, 8);

    pq.show();
    cout << "Top: " << pq.top() << endl;

    pq.pop();
    pq.show();
    cout << "Top: " << pq.top() << endl;

    pq.pop();
    pq.show();
    cout << "Top: " << pq.top() << endl;

    pq.clear();
    pq.show();
}