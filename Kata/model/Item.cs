using System;
using System.Collections;
namespace Model{
public partial class Item : IItem {

    //****** Variables ******// 
    // name: denote the Item's name.
    // sellIn: denotes the number of days we have to sell the item.
    // quality: denotes how valuable the item is. The Quality of an item is always >0  
    // startDate:  denote the first day of sales.
    // sellByDate: denote the  end of sell.
    // SpecialItems: denote a list of item which increases in Quality as its SellIn value approaches.
    protected ArrayList  SpecialItems= new ArrayList(){ "Backstage_passes", "aged_brie"};
    protected string name;
    protected  int selIn, quality;
    protected  DateTime startDate, sellByDate;

    //****** Properties ******// 
    public string Name{
        get{
            return this.name;
        }
        set{
            this.name=value;
        }
    }
    public int SellIn{
        get
        {
            return this.selIn;
        }
        set
        {
            this.selIn = value;
        }
    }
    public int Quality{
        get
        {
            return this.quality;
        }
        set
        {
            if (value >50 && name !="Sulfuras") this.quality=50;
            else if (value <0)  this.quality=0;
            else this.quality =  value;
        }
    }
    public DateTime StartDate{
        get
        {
            return this.startDate;
        }
        set
        {
            this.startDate = value;
        }
    }
    public DateTime SellByDate{
        get
        {
            return this.sellByDate;
        }
        set
        {
            this.sellByDate = value;
        }
    }
       
    //****** Constructor ******// 
    public Item (string name,  int quality, DateTime startDate, int selIn){
        this.name = name;
        this.quality= quality;
        if (this.quality>50 && this.name !="Sulfuras") this.quality=50;
        this.startDate= startDate;
        this.selIn = selIn;
        this.sellByDate= this.startDate.AddDays(this.selIn);
    }
}
}