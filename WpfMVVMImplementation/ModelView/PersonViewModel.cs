using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;  //use this namespace to access the model
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMImplementation.Command;
using WpfMVVMImplementation.Model;

namespace WpfMVVMImplementation.ModelView
{
    public class PersonViewModel :INotifyPropertyChanged   //we are using a collection class which need this interface
    {
        //make a proprty of type person which will talk with view to present the data of model
        private Person pobj;

        public Person Pobj
        {
            get { return pobj; }
            set
            {
                pobj =value;
                //notify the UI if this change
                onPropertyChange("Pobj");

            }
        }
        public PersonViewModel()
        {
            this.pobj = new Person();
            this._personList = new ObservableCollection<Person>();
        }﻿
        //to add alll the person in the list
        private ObservableCollection<Person> _personList;
        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            set { _personList = value;
            onPropertyChange("PersonList");
            }

        }

        private RelayCommand _submitCommand;
        public RelayCommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new RelayCommand(submitAction, canSumit, false);
                }
                return _submitCommand;
        }
            
        }

        private void submitAction(object parameter)
        {
            PersonList.Add(Pobj);
        }
        private bool canSumit(object parameter)
        {
            //if (string.IsNullOrEmpty(Pobj.Fname) || string.IsNullOrEmpty(Pobj.Lname))
            //{
            //    return false;
            //}
            //else { return true; }
           return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
