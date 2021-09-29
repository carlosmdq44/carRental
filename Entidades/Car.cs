using System;
using static RentCars.Program;


namespace RentCars
{
        public class Car{
        public int Id {get; set;}
        public Mark Mark { get; set; }
        public string Model { get; set; }
        public int NumberOfDoors { get; set; }
        public Colour Colour { get; set; }
        public Boolean ChangeBook { get; set; }
      
        public Car(){
        }

        public Car(Mark mark,string model,int NumberOfDoors,Colour colour,Boolean ChangeBook){
            this.Mark = mark;
            this.Model = model;
            this.NumberOfDoors = NumberOfDoors;
            this.Colour = colour;
            this.ChangeBook=ChangeBook;
        }
    }
}
