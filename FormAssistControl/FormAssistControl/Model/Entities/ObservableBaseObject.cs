using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FormAssistControl
{
	public class ObservableBaseObject:INotifyPropertyChanged
	{
		public ObservableBaseObject()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate {
			
		};

		public void OnPropertyChaged([CallerMemberName] string name="")
		{
			if (PropertyChanged == null) {
				return;
			}
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
