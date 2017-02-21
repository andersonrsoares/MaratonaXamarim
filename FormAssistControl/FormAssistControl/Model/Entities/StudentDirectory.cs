using System;
using System.Collections.ObjectModel;
namespace FormAssistControl
{
	public class StudentDirectory:ObservableBaseObject
	{
		private ObservableCollection<Student> students = new ObservableCollection<Student>();

		public ObservableCollection<Student> Students
		{
			get { return students; }
			set { students = value; OnPropertyChaged();}
		}

		public StudentDirectory()
		{
		}
	}
}
