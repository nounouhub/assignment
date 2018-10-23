using System;
namespace Model{
public class ConjuredItem: Item, IItem{
    
    // Conjured:  items degrade in Quality twice as fast as normal items
    public ConjuredItem(string name,  int quality, DateTime startDate, int selIn): base(name,  quality,  startDate, selIn){

    }

    public override int UpdateValues(){
            int diff = (DateTime.Now-this.startDate).Days;;
            
            //  StartDate is earlier than the currentDate.
            if ( DateTime.Compare(this.startDate, DateTime.Now)==-1){
                
                // If sell by date has not  passed yet, then  both  Quality decrease twice as fast.
                if (DateTime.Compare(this.sellByDate, DateTime.Now)==1)   
                        this.quality -= 2*diff;   

                // If sell by date has already passed, then  Quality degrades  2*2 as fast.
                else if(DateTime.Compare(this.sellByDate, DateTime.Now)==-1){
                    if(!this.SpecialItems.Contains(name))
                        this.quality -= 4* diff;
                }

                // The Quality of an item is never negative.
                if (this.quality <0) this.quality=0;
            }
        return this.quality;
    }
    
}
}



