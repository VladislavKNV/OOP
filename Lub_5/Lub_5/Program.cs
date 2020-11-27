using System;
using System.Runtime.CompilerServices;

namespace Lab5
{
	interface ICar
	{
		void move();
		void stop();
	
	}



	abstract class Railway_carriage
	{
		public int number_r { get; set; }


		public abstract void move();
		public abstract void stop();
		
	}

	class Train : Railway_carriage, ICar
	{
		public int number{ get; set; }
		public string direction { get; set; }
		public Train(int _number, string _direction, int _number_r)
		{
			number = _number;
			direction = _direction;
			number_r = _number_r;
		}
		public override string ToString()
		{
			return "number: " + number + '\n' + "direction: " + direction + '\n' + "Number railway_carriage:" + number_r + '\n';
		}


		public override void move()
		{
			Console.WriteLine("Human moves");
		}
		public override void stop()
		{
			Console.WriteLine("Human stopes");
		}
	


	}
		abstract class Vehicle
	{
		public int max_speed { get; set; }
		public int power { get; set; }

	}
	class Car : Vehicle, ICar
	{ 
		public string brand { get; set; }
		public string model { get; set; }
		public int year { get; set; }
		public Car(string _brand, string _model, int _year, int _max_speed, int _power)
		{
			brand = _brand;
			model = _model;
			year = _year;
			max_speed = _max_speed;
			power = _power;
		}

		public override string ToString()
		{
			return "Brand: " + brand + '\n' + "model: " + model + '\n' + "year:" + year + '\n' + "Max speed:" + max_speed + '\n' + "power:" + power + '\n';
		}


		void ICar.move()
		{
			Console.WriteLine("Car moves(interface)");
		}
		public void stop()
		{
			Console.WriteLine("Сar stopes");
		}
		public void open_door()
		{
			Console.WriteLine("Car opens door");
		}


	}
	class Printer
	{
		public void iAmPrinting(ICar obj)
		{
			Console.WriteLine(obj.GetType());
			Console.WriteLine(obj.ToString());
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Car car = new Car("BMW", "sedan", 5, 250,220);
			Train train = new Train(5, "Minsk", 13);

			Console.WriteLine(car.ToString());
			Console.WriteLine(train.ToString());

			Boolean test = car is Car;
			Console.WriteLine(test);

			ICar[] arr = { car, train };
			Printer printer = new Printer();
			for (int i = 0; i < arr.Length; i++)
			{
				printer.iAmPrinting(arr[i]);
			}
		}
	}
}