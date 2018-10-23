using System;
namespace Model{
    public partial class Item{
    //****** Methods ******//
    //UpdateValues:  At the end of each day our system lowers both values for every item.
    //output: Item's quality.
        public virtual int  UpdateValues(){

            //diff: denote the number of date between the current date and the start Date of sale.
            int diff = (DateTime.Now-this.startDate).Days;;
            
            // "Sulfuras": is a legendary item, can not  be sold or decreases in Quality.
            //  StartDate is earlier than the currentDate.
            if ( this.name != "Sulfuras" && DateTime.Compare(this.startDate, DateTime.Now)==-1){
                
                // If sell by date has not  passed yet, then  both values Quality and SelIn decrease by 1 each day has passed.
                if (DateTime.Compare(this.sellByDate, DateTime.Now)==1){   

                    // The item is not special.
                    if(!this.SpecialItems.Contains(name)){
                        this.selIn -= diff;
                        this.quality -= diff;
                    }

                    // The item is  special increases in Quality as its SellIn value approaches;
                    else{
                            // remainingDays: denote the number of day remains to the sellByDate.
                            int remainingDays = (this.sellByDate - DateTime.Now).Days;

                            // There are 10 days or less 
                            if ( remainingDays> 5 && remainingDays <= 10)
                                this.quality += 2;

                            // There are 5 days or less 
                            else if(remainingDays <= 5 && diff > 0)
                                this.quality += 3;

                            //Quality drops to 0 after the concert.
                            else if( remainingDays <=0)
                                this.quality=0;

                            //The Quality of an item is never more than 50.
                            if (this.quality > 50)
                                this.quality=50;
                    }    
                } 

                // If sell by date has already passed, then  Quality degrades twice as fast.
                else if(DateTime.Compare(this.sellByDate, DateTime.Now)==-1){
                    if(!this.SpecialItems.Contains(name))
                        this.quality -= 2* diff;
                }

                // The Quality of an item is never negative.
                if (this.quality <0) this.quality=0;
            }
        return this.quality;
        }
        public void Print(){
            Console.WriteLine( "{0} {1} {2} {3} {4} {5} {6} {7}", "Name: ", this.name, " ,Quality:" , this.quality, " ,StartDate:  ",
             this.startDate, " ,SellByDate: ", this.sellByDate );
        }
    }
}