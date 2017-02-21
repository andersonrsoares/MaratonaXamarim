using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormAssistControl
{
	public class StudentDirectoryVM:ObservableBaseObject
	{

		public ObservableCollection<Student> Students { get; set; }

		bool isBusy = false;

		public bool IsBusy 
		{ 
			get { return isBusy;}
			set {
				isBusy = value;
				OnPropertyChaged();
			}
		}

		public Command LoadDirectoryCommand 
		{
			get;
			set;
		}

		public StudentDirectoryVM()
		{
			Debug.WriteLine("StudentDirectoryVM");
			Students = new ObservableCollection<Student>();
			IsBusy = false;
			LoadDirectoryCommand = new Command((obj) => LoadDirectory());
		}

		async void LoadDirectory()
		{
			Debug.WriteLine("LoadDirectory");
			if (!IsBusy) {
				IsBusy = true;

				await Task.Delay(3000);

				var loadDirectory = StudentDirectoryService.LoadStudentDirectory();

				foreach (var studant in loadDirectory.Students)
				{
					Students.Add(studant);
				}
				IsBusy = false;
			}
		}


	}
}
