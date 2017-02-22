using System;

namespace FormAssistControl
{
	public class Student:ObservableBaseObject,IKeyObject
	{
		public string Key
		{
			get;
			set;
		}

		public Student()
		{
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChaged(); }
		}

		private string lastName;

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; OnPropertyChaged();}
		}

		private string group;

		public string Group
		{
			get { return group; }
			set { group = value; OnPropertyChaged();}
		}

		private string studentNumber;

		public string StudentNumber
		{
			get { return studentNumber; }
			set { studentNumber = value; OnPropertyChaged();}
		}

		private double average;

		public double Average
		{
			get { return average; }
			set { average = value; OnPropertyChaged();}
		}


	}
}
