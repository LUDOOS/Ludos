using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;

[FirestoreData]
public struct Children
{
    [FirestoreProperty]
    public int  ID { get; set; }
    //Firestore Property to store Name
    [FirestoreProperty]
    public object Avatar { get; set; }
    //Firestore Property to store Name
    [FirestoreProperty]
    public string Name { get; set; }
    //Firestore Property to store age
    [FirestoreProperty]
    public int Age { get; set; }

    //Firestore Property to store total_stars
    [FirestoreProperty]
    public int Total_stars { get; set; }
    //Firestore Property to store Achievements 
    [FirestoreProperty]
    public IList Achievements { get; set; }
    //Firestore Property to store store_Items 
    [FirestoreProperty]
    public IList StoreItems { get; set; }
    //Firestore Property to store Math 
    [FirestoreProperty]
    public IList Math { get; set; }
    //Firestore Property to store TimeAndDate 
    [FirestoreProperty]
    public IList TimeAndDate { get; set; }
    //Firestore Property to store Animals 
    [FirestoreProperty]
    public IList Animals { get; set; }


    public Children(int ID,object Avatar, string Name, int Age, int Total_stars, IList Achievements, IList StoreItems, IList Math, IList TimeAndDate, IList Animals) {
        this.ID = ID;
        this.Avatar = Avatar;
        this.Name = Name;
        this.Age = Age;
        this.Total_stars = Total_stars;
        this.Achievements = Achievements;
        this.StoreItems = StoreItems;
        this.Math = Math;
        
        this.TimeAndDate = TimeAndDate;
        this.Animals = Animals;
    }
    public int getTotalstars(IList game)
    {
        int total = 0;
        for (int i = 1; i < game.Count; i++)
        {
            if (game[i] != null)
            {
                total += (int)game[i];
            }
            else
            {
                return total;
            }
        }
        return total;
    }
}