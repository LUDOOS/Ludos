using Firebase.Firestore;
using System.Collections;

[FirestoreData]
public struct Children
{
    //Firestore Property to store Name
    [FirestoreProperty]
    private object Avatar { get; set; }
    //Firestore Property to store Name
    [FirestoreProperty]
    private string Name { get; set; }
    //Firestore Property to store age
    [FirestoreProperty]
    private int Age { get; set; }

    //Firestore Property to store total_stars
    [FirestoreProperty]
    private int Total_stars { get; set; }
    //Firestore Property to store Achievements 
    [FirestoreProperty]
    private ArrayList Achievements { get; set; }
    //Firestore Property to store store_Items 
    [FirestoreProperty]
    private ArrayList StoreItems { get; set; }
    //Firestore Property to store store_Items 
    //[FirestoreProperty]
    //private System.Collections.ArrayList Ac { get; set; }
    //Firestore Property to store store_Items 
    // [[FirestoreDocumentId]]
    // private ArrayList  Games{ get; set; }
    //Firestore Property to store Math 
    [FirestoreProperty]
    private ArrayList Math { get; set; }
    //Firestore Property to store APC 
    [FirestoreProperty]
    private ArrayList APC { get; set; }
    //Firestore Property to store TimeAndDate 
    [FirestoreProperty]
    private ArrayList TimeAndDate { get; set; }
    //Firestore Property to store Animals 
    [FirestoreProperty]
    private ArrayList Animals { get; set; }


    public Children(object Avatar, string Name, int Age, int Total_stars, ArrayList Achievements, ArrayList StoreItems, ArrayList Math, ArrayList APC, ArrayList TimeAndDate, ArrayList Animals) {
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
    public ArrayList _Achievements
    {
        get { return Achievements; }
        set { Achievements = value; }
    }
    public ArrayList _StoreItems
    {
        get { return StoreItems; }
        set { StoreItems = value; }
    }
    public ArrayList _Math
    {
        get { return Math; }
        set { Math = value; }
    }
    public ArrayList _APC
    {
        get { return APC; }
        set { APC = value; }
    }
    public ArrayList _TimeAndDate
    {
        get { return TimeAndDate; }
        set { TimeAndDate = value; }
    }
    public ArrayList _Animals
    {
        get { return Animals; }
        set { Animals = value; }
    }
}