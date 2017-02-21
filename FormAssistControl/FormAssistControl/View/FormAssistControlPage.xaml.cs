using Xamarin.Forms;

namespace FormAssistControl
{
	public partial class FormAssistControlPage : ContentPage
	{
		public FormAssistControlPage()
		{
			InitializeComponent();
			this.BindingContext = new StudentDirectoryVM();
			lvStudents.ItemSelected += LvStudents_ItemSelected;
		}

		void LvStudents_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Student selected = (Student)e.SelectedItem;
			if (selected == null)
				return;

			Navigation.PushAsync(new StudentsDetailPage(selected));
			lvStudents.SelectedItem = null;
		}
	}
}
