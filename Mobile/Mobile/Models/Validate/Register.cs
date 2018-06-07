using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mobile.Models.Validate
{
    public class Register : INotifyPropertyChanged
    {
        public Field IsCreated { get; set; } = new Field();
        public event PropertyChangedEventHandler PropertyChanged;
        public Field UserId { get; set; } = new Field();
        public Field Password { get; set; } = new Field();
        public Field Status { get; set; } = new Field();
        public Field Role { get; set; } = new Field();
        public Field Name { get; set; } = new Field();
        public Field Position { get; set; } = new Field();
        public Field BloodType { get; set; } = new Field();
        public Field DesktopPhone { get; set; } = new Field();
        public Field CellPhone { get; set; } = new Field();
        public Field Gender { get; set; } = new Field();
        public Field ObjectId { get; set; } = new Field();
        public Field SecretCode { get; set; } = new Field();
        public Field DayOfBirth { get; set; } = new Field();
        public Field LocationId { get; set; } = new Field();
    }

    public class Field : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool IsNotValid { get; set; }
        public string NotValidMessageError { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Field()
        {
        }
    }
}
