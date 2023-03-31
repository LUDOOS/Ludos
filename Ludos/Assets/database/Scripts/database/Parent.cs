using Firebase.Firestore;

[FirestoreData]
public struct Parent
{
    //Firestore Property to store Name
    [FirestoreProperty]
    public string Name { get; set; }
    //Firestore Property to store age
    [FirestoreProperty]
    public int NoChildren { get; set; }

    [FirestoreProperty]
    public string Email { get; set; }
    public Parent(string Name, int NoChildren, string Email)
    {
        this.Name = Name;
        this.NoChildren = NoChildren;
        this.Email = Email;
    }
    public string _Name
    {
        get { return Name; }
        set { Name = value; }
    }
    public int _NoChildren
    {
        get { return NoChildren; }
        set { NoChildren = value; }
    }
    public string _Email
    {
        get { return Email; }
        set { Email = value; }
    }
}