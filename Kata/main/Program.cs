using System;
using Model;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IItem normal = new Item("item1" , 40, new DateTime(2018, 09, 02, 0, 0, 0), 33);
            normal.UpdateValues();
            normal.Print();
            IItem conjured = new ConjuredItem( "item2",  40, new DateTime(2018, 09, 02, 0, 0, 0), 33);
            conjured.UpdateValues();
            conjured.Print();
        }
    }
}
