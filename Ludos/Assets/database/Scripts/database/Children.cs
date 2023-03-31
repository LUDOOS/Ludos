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
    //Firestore Property to store store_Items 
    //[FirestoreProperty]
    //public System.Collections.IList Ac { get; set; }
    //Firestore Property to store store_Items 
    // [[FirestoreDocumentId]]
    // public IList  Games{ get; set; }
    //Firestore Property to store Math 
    [FirestoreProperty]
    public IList Math { get; set; }
    //Firestore Property to store APC 
    [FirestoreProperty]
    public IList APC { get; set; }
    //Firestore Property to store TimeAndDate 
    [FirestoreProperty]
    public IList TimeAndDate { get; set; }
    //Firestore Property to store Animals 
    [FirestoreProperty]
    public IList Animals { get; set; }


    public Children(int ID,object Avatar, string Name, int Age, int Total_stars, IList Achievements, IList StoreItems, IList Math, IList APC, IList TimeAndDate, IList Animals) {
        this.ID = ID;
        this.Avatar = Avatar;
        this.Name = Name;
        this.Age = Age;
        this.Total_stars = Total_stars;
        this.Achievements = Achievements;
        this.StoreItems = StoreItems;
        this.Math = Math;
        this.APC = APC;
        this.TimeAndDate = TimeAndDate;
        this.Animals = Animals;
    }
    public int _ID
    {
        get { return ID; }
        set { ID = value; }
    }
    public object _Avatar
    {
        get { return Avatar; }
        set { Avatar = value; }
    }
    public string _Name
    {
        get { return Name; }
        set { Name = value; }
    }
    public int _Age
    {
        get { return Age; }
        set { Age = value; }
    }
    public int _Total_stars
    {
        get { return Total_stars; }
        set { Total_stars = value; }
    }
    public IList _Achievements
    {
        get { return Achievements; }
        set { Achievements = value; }
    }
    public IList _StoreItems
    {
        get { return StoreItems; }
        set { StoreItems = value; }
    }
    public IList _Math
    {
        get { return Math; }
        set { Math = value; }
    }
    public IList _APC
    {
        get { return APC; }
        set { APC = value; }
    }
    public IList _TimeAndDate
    {
        get { return TimeAndDate; }
        set { TimeAndDate = value; }
    }
    public IList _Animals
    {
        get { return Animals; }
        set { Animals = value; }
    }
}