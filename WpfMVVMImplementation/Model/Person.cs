using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMImplementation.Model
{
    public class Person : INotifyPropertyChanged   //implement the INotifyPropertycahanged interface
    {
        private string fName;
        private string lName;
        private string fullName;

        public string Fname
        {
            get { return fName; }
            set
            {
                fName = value;
               // onPropertyChange("Fname");
            }
        }
        public string Lname
        {
            get { return lName; }
            set
            {
                                lName = value;
               // onPropertyChange("Lname");
            }
        }
        public string FullName
        {
            get { return fullName= fName+" "+lName; }
            set
            {
                if(fullName!= value)
                fullName = value;
            }
        }

        public DateTime dateAdded { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        //generate a method for propetychanged event

        private void onPropertyChange(string property)
        {
            //invoke the propertychangeEvent with this property
            //check if it is null
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
