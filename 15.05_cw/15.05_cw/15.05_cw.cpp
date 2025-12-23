#include <iostream>
using namespace std;

template<typename T>
class Vector
{

	size_t length;
	T* data;
	static const size_t MAX_SIZE = 9000;

public:

	Vector() : length(0), data(nullptr) {}
	Vector(size_t size) : length(size), data(new T[size]{}) {}
	Vector(const Vector& other) : length(other.length), data(new T[length]{})
	{
		for (int i = 0; i < length; i++)
		{
			data[i] = other.data[i];
		}
	}

	~Vector() { delete[] data; }

	void push_back(T value)
	{
		T* new_data = new T[length + 1];

		for (int i = 0; i < length; i++)
		{
			new_data[i] = data[i];
		}

		new_data[length] = value;
		delete[] data;
		data = new_data;
		length++;

	}

	void pop_back()
	{
		T* new_data = new T[length - 1];

		for (int i = 0; i < length - 1; i++)
		{
			new_data[i] = data[i];
		}

		delete[] data;
		data = new_data;
		length--;
	}

	void insert(int pos, T element)
	{
		if (pos < length)
		{
			T* new_data = new T[length + 1];

			for (int i = 0; i < pos; i++)
			{
				new_data[i] = data[i];

			}

			new_data[pos] = element;

			for (int i = pos + 1; i < length; i++)
			{
				new_data[i] = data[i - 1];
			}

			delete[] data;
			data = new_data;
			length++;
		}
		else
		{
			cout << "Error" << endl;
		}
	}

	void insert(int pos, int num, T element)
	{
		if (pos <= length)
		{
			T* new_data = new T[length + num];
			for (int i = 0; i < pos; i++)
			{
				new_data[i] = data[i];

			}

			for (int i = pos; i < pos + num; i++)
			{
				new_data[i] = element;
			}

			for (int i = pos + num; i < length; i++)
			{
				new_data[i] = data[i - num];
			}

			delete[] data;
			data = new_data;
			length += num;
		}
		else
		{
			cout << "Error" << endl;
		}
	}

	void erase(int pos)
	{
		if (pos < length)
		{
			T* new_data = new T[length - 1];
			for (int i = 0; i < pos; i++)
			{
				new_data[i] = data[i];

			}

			for (int i = pos; i < length - 1; i++)
			{
				new_data[i] = data[i + 1];

			}

			delete[] data;
			data = new_data;
			length--;
		}
		else
		{
			cout << "Error" << endl;
		}
	}

	void clear()
	{
		length = 0;
		delete[] data;
		data = new T[length];
	}

	bool empty() { return length == 0; }

	size_t size() const { return length; }

	static size_t max_size() { return MAX_SIZE; }

	void swap(Vector<T>& other)
	{
		swap(data, other.data);
		swap(length, other.length);
	}

	friend ostream& operator<< (ostream& OUT, const Vector& _Vector)
	{
		for (int i = 0; i < _Vector.length; i++)
		{
			OUT << _Vector.data[i] << " ";
		}
			
		return OUT;
	}
};

int main()
{
	Vector<int> vec(4);
	cout << vec << endl;

	vec.clear();
	cout << vec << "clear complete" << endl;

	cout << boolalpha << vec.empty() << endl;

	vec.push_back(10);
	cout << vec << endl;

	vec.push_back(7);
	cout << vec << endl;

	vec.pop_back();
	cout << vec << endl;

	vec.insert(0, 3);
	cout << vec << endl;
	vec.insert(1, 3, 4);
	cout << vec << endl;

	vec.erase(3);
	cout << vec << endl;

	vec.clear();
	cout << vec << "clear complete" << endl;

}
