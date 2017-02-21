using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormAssistControl
{
	public partial class StudentsDetailPage : ContentPage
	{

		public Student SelectedStudent
		{
			get;
			set;
		}

		public StudentsDetailPage(Student selectedStudent)
		{
			InitializeComponent();
			SelectedStudent = selectedStudent;
			this.BindingContext = SelectedStudent;
		}
	}
}
